using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject BallPrefab;

    [SerializeField]
    private Text textScoreJ1;

    [SerializeField]
    private Text textScoreJ2;

    [SerializeField]
    private Text textTimer;

    [SerializeField]
    private Text textWinner;

    [SerializeField]
    private NavMeshAgent agent;


    private GameObject ball;

    [SerializeField]
    private PlayerDeplacementScript joueur1;

    [SerializeField]
    private PlayerDeplacementScript joueur2;

    public int scoreJ1 = 0;

    public int scoreJ2 = 0;

    public int timer = 60;

    // Start is called before the first frame update
    void Start()
    {
        textWinner.gameObject.SetActive(false);
        StartGame();
        StartCoroutine(Timer());
        //ballDeplacementScript = ball.GetComponent<BallDeplacementScript>();
        //playerDeplacementScript.ballDeplacementScript = ballDeplacementScript;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(ball.transform.position);
        //ballDeplacementScript = ball.GetComponent<BallDeplacementScript>();
        //playerDeplacementScript.ballDeplacementScript = ballDeplacementScript;
        if (agent.remainingDistance != Mathf.Infinity && agent.remainingDistance <= agent.stoppingDistance) {
            //Debug.Log("getball");
            //ballDeplacementScript.Tirer(true);
        }

        if(ball.GetComponent<BallDeplacementScript>().attrapegauche)
        {
            joueur1.peutmarcher = false;
        }
        else
        {
            joueur1.peutmarcher = true;
        }

    }

    public void StartGame() {
        ball = Instantiate<GameObject>(BallPrefab, new Vector3(-5.5f, 0.75f, 0f), Quaternion.identity) as GameObject;
        agent.SetDestination(ball.transform.position);
        BallDeplacementScript ballDeplacementScript = ball.GetComponent<BallDeplacementScript>();
    }

    public void Goal(string goal) {
        if(goal == "GoalJ2") {
            scoreJ1 += 1;
            textScoreJ1.text = scoreJ1.ToString();
        }
        else {
            scoreJ2 += 1;
            textScoreJ2.text = scoreJ2.ToString();
        }
        StartGame();
    }

    private IEnumerator Timer() {
        while (timer > 0) {

            yield return new WaitForSeconds(1);
            timer--;
            textTimer.text = timer.ToString();
        }
        Time.timeScale = 0;
        if(scoreJ1 > scoreJ2) {
            textWinner.text += "Winner J1";
        }
        else if(scoreJ1 < scoreJ2) {
            textWinner.text += "Winner J2";
        }
        else {
            textWinner.text = "tie";
        }
        
        textWinner.gameObject.SetActive(true);
    }
}
