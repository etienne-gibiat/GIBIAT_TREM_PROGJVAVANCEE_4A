using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;

public class GameManagerMenu : MonoBehaviour {

    [SerializeField]
    private GameObject BallPrefab;

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private NavMeshAgent agent2;


    private GameObject ball;

    [SerializeField]
    private PlayerDeplacementScript joueur1;

    [SerializeField]
    private PlayerDeplacementScript joueur2;

    private BallDeplacementScript ballDeplacementScript;



    // Start is called before the first frame update
    void Start() {
        StartGame();
        ballDeplacementScript = ball.GetComponent<BallDeplacementScript>();
        ballDeplacementScript.estIA = true;
        ballDeplacementScript.estIA = false;
        //playerDeplacementScript.ballDeplacementScript = ballDeplacementScript;
    }

    // Update is called once per frame
    void Update() {

        agent.SetDestination(ball.transform.position);
        agent2.SetDestination(ball.transform.position);

        if (ballDeplacementScript.attrapegauche) {
            joueur1.peutmarcher = false;
        }
        else {
            joueur1.peutmarcher = true;
        }

        if (ballDeplacementScript.attrapedroite) {
            joueur2.peutmarcher = false;
        }
        else {
            joueur2.peutmarcher = true;
        }

    }

    public void StartGame() {
        ball = Instantiate<GameObject>(BallPrefab, new Vector3(0.5f, -9f, 78f), Quaternion.identity) as GameObject;
        ballDeplacementScript = ball.GetComponent<BallDeplacementScript>();
        ballDeplacementScript.estIA = true;
    }

    public void Goal(string goal) {
        StartGame();
    }

}
