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

    //[SerializeField]
    //public PlayerDeplacementScript joueur1;

    //[SerializeField]
    //public PlayerDeplacementScript joueur2;

    private Vector3 Direction = Vector3.left;


    //private bool attrapedroite = false;

    //private bool attrapegauche = false;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        float xDirection = Random.Range(-0.5f, 0.5f);
        float zDirection = Random.Range(-0.5f, 0.5f);
        Direction = new Vector3(xDirection, 0.0f, zDirection);

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (!attrapedroite && !attrapegauche) {
        Direction.Normalize();
        rb.velocity = Direction * speed;
        //gameObject.transform.position += Direction * Time.deltaTime * speed;
        //}
        //else if (attrapedroite) {
        //    Transform joueur = joueur1.gameObject.transform;
        //    gameObject.transform.position = new Vector3(joueur.position.x, joueur.position.y, joueur.position.z); 
        //    //gameObject.transform.position.z = joueur1.gameObject.transform.position.z - 5;
        //}
        //else if (attrapegauche) {
        //    Transform joueur = joueur2.gameObject.transform;
        //    gameObject.transform.position = new Vector3(joueur.position.x, joueur.position.y, joueur.position.z);
        //    //gameObject.transform.position.z = joueur1.gameObject.transform.position.z - 5;
        //}

        //if (Input.GetAxisRaw("Fire1") > 0 && attrapedroite) {
        //    Debug.Log("Raquette droite entree");
        //    Direction = new Vector3(-Direction.x, Direction.y, Direction.z);
        //    attrapedroite = false;
        //}

        //if (Input.GetAxisRaw("Fire1Sec") > 0 && attrapegauche) {
        //    Debug.Log("Raquette gauche space");
        //    Direction = new Vector3(-Direction.x, Direction.y, Direction.z);
        //    attrapegauche = false;
        //}
    }

    public void OnCollisionEnter(Collision collision) {
        if ((WallMask.value & (1 << collision.gameObject.layer)) > 0) {
            Debug.Log("WallColision");

            Direction = new Vector3(Direction.x, Direction.y, -Direction.z);
            speed += 1.5f;
        }
        else if ((PlayerMask.value & (1 << collision.gameObject.layer)) > 0) {
            //if (collision.gameObject.tag == "Raquette droite")
            //    attrapedroite = true;
            //else if (collision.gameObject.tag == "Raquette gauche")
            //    attrapegauche = true;

            Direction = new Vector3(-Direction.x, Direction.y, Direction.z);
            speed += 1f;
            //gameObject.transform.position = joueur.gameObject.transform.position;
        }
    }
}
