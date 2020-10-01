﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public bool peutmarcher = true;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = Vector3.zero;
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


        if (Input.GetAxisRaw(AxisFire1Name) > 0 && m_isAxisInUse == false)
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
        
    }

    IEnumerator nextDash()
    {
        yield return new WaitForSeconds(1.5f);
        m_isAxisInUse = false;
    }

}
