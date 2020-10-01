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

    public GameManager gamemanager;

    static int UP = 4;
    static int DOWN = 2;
    static int RIGHT = 1;
    static int LEFT = 3;



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
        }

        if (Input.GetAxis(AxisFire1Name) > 0 && m_isAxisInUse == false) {
            gameObject.transform.position += direction * Time.deltaTime * speed * dash;
            m_isAxisInUse = true;
            StartCoroutine(nextDash());
        }
        else {
            direction.Normalize();
            gameObject.transform.position += direction * Time.deltaTime * speed;
        }
    }

    public void Deplacement(int mouvement) {

        switch (mouvement) {
            case 1:
                direction += Vector3.right;
                break;
            case 2:
                direction += Vector3.back;
                break;
            case 3:
                direction += Vector3.left;
                break;
            case 4:
                direction += Vector3.forward;
                break;
            default:
                break;
        }

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
