using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask BallMask;

    [SerializeField]
    private GameManager gameManager;

    

    // [SerializeField]
    // private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //void OnTriggerEnter(Collider other) {
    //    if ((BallMask.value & (1 << other.gameObject.layer)) > 0) {
    //        Destroy(other.gameObject);
    //        gameManager.StartGame();
    //    }
    //}

    public void OnCollisionEnter(Collision collision) {
        if ((BallMask.value & (1 << collision.gameObject.layer)) > 0) { 
            Destroy(collision.gameObject);
            gameManager.Goal(gameObject.tag);
        }
    }
}
