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
    public bool estJoueur;


    public bool attrapedroite = false;

    public bool attrapegauche = false;

    private bool isInLoopCoroutineTirer = false;

    private bool isInLoopCoroutineTirerZigZag = false;

    private float yDirection = 0.0f;

    private int montee1descend2static0 = 0;

    private bool entraindetirer = false;

    public AudioSource source;

    Rigidbody rb;


    
    void Start()
    {
       
        float xDirection = Random.Range(-0.5f, 0.5f);
        float zDirection = Random.Range(-0.5f, 0.5f);
        Direction = new Vector3(xDirection, 0.0f, zDirection);
        Direction.Normalize();
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
       
        if (!attrapedroite && !attrapegauche) {
           
            
            gameObject.transform.position += Direction * Time.deltaTime * speed;
        }
        else if (attrapedroite && !isInLoopCoroutineTirer && !estIA && !estJoueur) {
            Transform joueur = joueur1.gameObject.transform;
            StartCoroutine(nextTir());
            source.Play();
            
        }
        else if (attrapegauche) {
            
            
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
        }
        else {
            attrapegauche = false;
            xDirection = Random.Range(-0.5f, 0f);
            zDirection = Random.Range(-0.5f, 0f);
        }
        Direction = new Vector3(xDirection, 0.0f, -zDirection);
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
        Direction.Normalize();
    }




    public void OnCollisionEnter(Collision collision) {
        if ((WallMask.value & (1 << collision.gameObject.layer)) > 0) {
            Direction = Vector3.Reflect(Direction, Vector3.forward);
            speed += 2.5f;
            source.Play();
        }
        else if ((PlayerMask.value & (1 << collision.gameObject.layer)) > 0) {
            if (collision.gameObject.tag == "Raquette droite") {
                attrapedroite = true;
            }
            else if (collision.gameObject.tag == "Raquette gauche") {
                attrapegauche = true;
            }

            Direction = Vector3.Reflect(Direction, Vector3.right);
            Direction.Normalize();
            speed += 2f;
        }

    }
}
