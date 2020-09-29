/*using System;
using System.Collections;
using System.Collections.Generic;*/
/*using System.ComponentModel;
using System.Diagnostics;
using System.Threading;*/
using UnityEngine;

public class PongBallDeplacementScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private LayerMask WallMask;

    [SerializeField]
    private LayerMask PlayerMask;

    public Vector3 Direction = Vector3.left;

    [SerializeField]
    public PlayerDeplacementScript joueur1;

    [SerializeField]
    public PlayerDeplacementScript joueur2;

    private bool attrapedroite = false;
    private bool attrapegauche = false;


    private void Start()
    {
        float xDirection = Random.Range(0.0f, 1.0f);
        float zDirection = Random.Range(0.0f, 1.0f);
        Direction = new Vector3(xDirection, 0.0f, zDirection);

    }

    // Update is called once per frame
    void Update()
    {
        if (attrapedroite == false && attrapegauche == false)
            gameObject.transform.position += Direction * Time.deltaTime * 0.1f * speed;
        else if (attrapedroite)
        {
            gameObject.transform.parent = joueur1.gameObject.transform;
            //gameObject.transform.position.z = joueur1.gameObject.transform.position.z - 5;
        }
        else if (attrapegauche)
        {
            gameObject.transform.parent = joueur2.gameObject.transform;
            //gameObject.transform.position.z = joueur1.gameObject.transform.position.z - 5;
        }

        /* if (Input.GetKeyDown(KeyCode.Return))
         {
             Debug.Log("Return key was pressed.");
         }*/

        if (Input.GetKeyDown(KeyCode.Return) && attrapedroite)
        {
            Debug.Log("Raquette droite entree");
            Direction = new Vector3(Direction.x, Direction.y, -Direction.z);
            attrapedroite = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && attrapegauche)
        {
            Debug.Log("Raquette gauche space");
            Direction = new Vector3(Direction.x, Direction.y, -Direction.z);
            attrapegauche = false;
        }


    }

    public void OnCollisionEnter(Collision collision)
    {
        if((WallMask.value &(1 << collision.gameObject.layer)) > 0)
        {
            Direction = new Vector3(-Direction.x, Direction.y, Direction.z);

        }
        else if ((PlayerMask.value & (1 << collision.gameObject.layer)) > 0)
        {
            if(collision.gameObject.tag == "Raquette droite")
                attrapedroite = true;
            else if (collision.gameObject.tag == "Raquette gauche")
                attrapegauche = true;

            //Direction = new Vector3(Direction.x, Direction.y, -Direction.z);
            /*gameObject.transform.position = joueur.gameObject.transform.position;*/
        }
    }
}
