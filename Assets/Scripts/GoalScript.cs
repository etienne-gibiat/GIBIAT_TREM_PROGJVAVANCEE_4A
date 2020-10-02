using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask BallMask;

    [SerializeField]
    private GameManager gameManager;

    public AudioSource source;

    

    
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

   


    

    public void OnCollisionEnter(Collision collision) {
        if ((BallMask.value & (1 << collision.gameObject.layer)) > 0) { 
            Destroy(collision.gameObject);
            gameManager.Goal(gameObject.tag);
            source.Play();
        }
    }
}
