using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayerDeplacementScript : MonoBehaviour
{
    [SerializeField]
    private float Speed = 1.0f;

    [SerializeField]
    private string AxisName;


    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;
        if(Input.GetAxis(AxisName) > 0)
        {
            direction += Vector3.left;
        }
        if (Input.GetAxis(AxisName) < 0)
        {
            direction += Vector3.right;
        }


        gameObject.transform.position += direction * Time.deltaTime * Speed;
    }
}
