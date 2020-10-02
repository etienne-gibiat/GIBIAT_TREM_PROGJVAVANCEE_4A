using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeplacementScript : MonoBehaviour
{

    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private LayerMask WallMask;

    [SerializeField]
    private LayerMask PlayerMask;

    [SerializeField]
    private LayerMask GoalMask;

    [SerializeField]
    public PlayerDeplacementScript joueur1;

    [SerializeField]
    public PlayerDeplacementScript joueur2;

    private Vector3 Direction = Vector3.left;

    public bool estIA;


    public bool attrapedroite = false;

    public bool attrapegauche = false;

    private bool isInLoopCoroutineTirer = false;

    private bool isInLoopCoroutineTirerZigZag = false;

    private float yDirection = 0.0f;

    private int montee1descend2static0 = 0;

    private bool entraindetirer = false;

    public AudioSource source;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        //joueur1 = GameObject.Find("Player gauche");
        //joueur2 = GameObject.Find("Player droite");
        float xDirection = Random.Range(-0.5f, 0.5f);
        float zDirection = Random.Range(-0.5f, 0.5f);
        Direction = new Vector3(xDirection, 0.0f, zDirection);
        Direction.Normalize();
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.velocity = Vector3.zero;
        if (!attrapedroite && !attrapegauche) {
            //    Direction.Normalize();
            
            gameObject.transform.position += Direction * Time.deltaTime * speed;
        }
        else if (attrapedroite && !isInLoopCoroutineTirer && !estIA) {
            Transform joueur = joueur1.gameObject.transform;
            StartCoroutine(nextTir());
            source.Play();
            //Tirer(true);
            //gameObject.transform.parent = joueur1.gameObject.transform;
        }
        else if (attrapegauche) {
            
            //gameObject.transform.parent = joueur2.gameObject.transform;
        }

        if (Input.GetAxisRaw("Fire1Sec") > 0 && attrapedroite) {
            
            Tirer(true);
            source.Play();
        }

        if (Input.GetAxisRaw("Fire1") > 0 && attrapegauche) {
            
            Tirer(false);
            source.Play();
        }

        if (Input.GetAxisRaw("Fire2") > 0 && attrapegauche && !isInLoopCoroutineTirerZigZag)
        {
            Debug.Log(isInLoopCoroutineTirerZigZag);
            StartCoroutine(nextDirectionTir());
            source.Play();
        }

/*        if (Input.GetAxisRaw("escape") > 0)
        {
            Debug.Log("echap");
            Application.LoadLevel("Menu");
        }*/
    }
       

    IEnumerator nextTir()
    {
        isInLoopCoroutineTirer = true;
        yield return new WaitForSeconds(0.5f);
        Tirer(true);
        isInLoopCoroutineTirer = false;
    }

    IEnumerator nextDirectionTir()
    {
        isInLoopCoroutineTirerZigZag = true;
        Debug.Log(isInLoopCoroutineTirerZigZag);
        TirerZigZag(true);
        yield return new WaitForSeconds(0.1f);
        TirerZigZag(true);
        yield return new WaitForSeconds(0.1f);
        TirerZigZag(true);
        yield return new WaitForSeconds(0.1f);
        TirerZigZag(true);
        yield return new WaitForSeconds(0.1f);
        TirerZigZag(true);
        isInLoopCoroutineTirerZigZag = false;
    }



    public void Tirer(bool droite) {
        float xDirection;
        float zDirection;
        
        if (droite) {
            attrapedroite = false;
            xDirection = Random.Range(0f, 0.5f);
            zDirection = Random.Range(0f, 0.5f);
            //Debug.Log("Raquette droite entree");
        }
        else {
            //Debug.Log("Raquette gauche space");
            attrapegauche = false;
            xDirection = Random.Range(-0.5f, 0f);
            zDirection = Random.Range(-0.5f, 0f);
        }
        Direction = new Vector3(xDirection, 0.0f, -zDirection);
        //Direction = new Vector3(xDirection, Direction.y, -zDirection);
        Direction.Normalize();
    }

    public void TirerZigZag(bool droite)
    {
        float xDirection;
        float zDirection;
        

        if (droite)
        {
            attrapedroite = false;
            xDirection = Random.Range(0f, 0.5f);
            zDirection = Random.Range(0f, 0.5f);
        }
        else
        {
            attrapegauche = false;
            xDirection = Random.Range(-0.5f, 0f);
            zDirection = Random.Range(-0.5f, 0f);
        }

        Direction = Vector3.Reflect(Direction, Vector3.forward);

        //Direction = new Vector3(xDirection, Direction.y, -zDirection);
        Direction.Normalize();
    }


    //desactiver le collider au moment de lancer, iskinematic, 


    public void OnCollisionEnter(Collision collision) {
        if ((WallMask.value & (1 << collision.gameObject.layer)) > 0) {
            //Debug.Log("WallColision");

            //Direction = new Vector3(Direction.x, Direction.y, -Direction.z);
            Direction = Vector3.Reflect(Direction, Vector3.forward);
            speed += 1.5f;
            source.Play();
        }
        else if ((PlayerMask.value & (1 << collision.gameObject.layer)) > 0) {
            if (collision.gameObject.tag == "Raquette droite") {
                //Debug.Log("Raquette droite att");
                attrapedroite = true;
            }
            else if (collision.gameObject.tag == "Raquette gauche") {
                //Debug.Log("Raquette droite att");
                attrapegauche = true;
            }

            //Direction = new Vector3(-Direction.x, Direction.y, Direction.z);
            Direction = Vector3.Reflect(Direction, Vector3.right);
            Direction.Normalize();
            speed += 1f;
            //gameObject.transform.position = joueur.gameObject.transform.position;
        }

    }
}
