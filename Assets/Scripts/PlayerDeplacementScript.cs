using System.Collections;
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


    const int UP = 3;
    const int DOWN = 1;
    const int RIGHT = 0;
    const int LEFT = 2;

    [SerializeField]
    bool estIA;

    [SerializeField]
    Rigidbody rb;



    
    private bool m_isAxisInUse = false;
    private bool inputDash = false;

    private Vector3 direction;


    public bool peutmarcher = true;

    
    

    void Update() {

        
            if (Input.GetAxisRaw(AxisHorizontalName) < 0) {
                Deplacement(RIGHT);
            }

            if (Input.GetAxisRaw(AxisHorizontalName) > 0) {
                Deplacement(LEFT);
            }
            if (Input.GetAxisRaw(AxisVerticalName) < 0) {
                Deplacement(UP);
            }

            if (Input.GetAxisRaw(AxisVerticalName) > 0) {
                Deplacement(DOWN);
            }
        

        if (Input.GetAxis(AxisFire1Name) > 0 && m_isAxisInUse == false) {
            gameObject.transform.position += direction * Time.deltaTime * speed * dash;
            m_isAxisInUse = true;
            StartCoroutine(nextDash());
        }
        else if (peutmarcher) {
            direction.Normalize();
            gameObject.transform.position += direction * Time.deltaTime * speed;
        }
        if (!estIA) {
            direction = Vector3.zero;
        }
    }

    public void Deplacement(int mouvement) {
        
    if (peutmarcher) {
        switch (mouvement) {
            case RIGHT:
                direction += Vector3.right;
                break;
            case DOWN:
                direction += Vector3.back;
                break;
            case LEFT:
                direction += Vector3.left;
                break;
            case UP:
                direction += Vector3.forward;
                break;
            default:
                break;
        }
    }

    }

    IEnumerator nextDash()
    {
        yield return new WaitForSeconds(1.5f);
        m_isAxisInUse = false;
    }



}
