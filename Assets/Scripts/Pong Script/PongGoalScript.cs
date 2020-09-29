using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongGoalScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask ballMask;
    [SerializeField]
    private GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        //Compare sur les bit et non sur la text plus rapide
        if ((ballMask.value & (1 << other.gameObject.layer)) > 0)
        {
            Debug.Log("Point");
            Destroy(other.gameObject);
            gameManager.StartGame();
        }
    }
}