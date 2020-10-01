﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerDeplacementScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    private float dash = 5;

    [SerializeField]
    private string AxisVerticalName;
    [SerializeField]
    private string AxisHorizontalName;

    [SerializeField]
    private string AxisFire1Name;

    [SerializeField]
    private string AxisFire2Name;

    public GameManager gamemanager;

    /*[SerializeField]
    Rigidbody rb;*/
    private bool m_isAxisInUse = false;
    private bool inputDash = false;

    private Vector3 direction;


    public bool peutmarcher = true;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
        direction = Vector3.zero;
        //Debug.Log(ballDeplacementScript.attrapegauche);
        //if (gamemanager.GetComponent<GameManager>().) 
        //if(gamemanager.GetComponent<BallDeplacementScript>().attrapegauche)
        if(peutmarcher)
        { 
            if (Input.GetAxisRaw(AxisHorizontalName) < 0) {
                direction += Vector3.right;
            }

            if (Input.GetAxisRaw(AxisHorizontalName) > 0) {
                direction += Vector3.left;
            }
            if (Input.GetAxisRaw(AxisVerticalName) < 0) {
                direction += Vector3.forward;
            }

            if (Input.GetAxisRaw(AxisVerticalName) > 0) {
                direction += Vector3.back;
            }
        }

        inputDash = Input.GetAxis(AxisFire1Name) > 0 && m_isAxisInUse == false;
        Debug.Log(direction);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (inputDash)
        {
             gameObject.transform.position += direction * Time.deltaTime * speed * dash;
            //rb.velocity = direction * speed * dash;
            // Call your event function here.
            m_isAxisInUse = true;
            StartCoroutine(nextDash());
        }
        else{
            direction.Normalize();
            //rb.velocity = direction * speed;
            gameObject.transform.position += direction * Time.deltaTime * speed;
        }
        //Debug.Log(direction);

    }

    //public void OnCollisionEnter(Collision collision) {
    //    if ((WallMask.value & (1 << collision.gameObject.layer)) > 0) {
           
    //    }
    //}

    IEnumerator nextDash()
    {
        yield return new WaitForSeconds(1.5f);
        m_isAxisInUse = false;
    }



}
