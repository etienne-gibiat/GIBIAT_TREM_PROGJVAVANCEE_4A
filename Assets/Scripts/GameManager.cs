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

    [SerializeField]
    private PauseMenuScript pauseMenuScript;

    [SerializeField]
    private Text ResumeButton;


    private GameObject ball;

    [SerializeField]
    private PlayerDeplacementScript joueur1;

    [SerializeField]
    private PlayerDeplacementScript joueur2;

    private BallDeplacementScript ballDeplacementScript;

    public static int typeIA = 2;

    public int scoreJ1 = 0;

    public int scoreJ2 = 0;

    public int timer = 60;

    private const int BUTTONA = 5;
    private const int BUTTONB = 4;
    private const int RIGHT = 0;
    private const int DOWN = 1;
    private const int LEFT = 2;
    private const int UP = 3;
    private bool iARandomWait = false;



    
    void Start()
    {
        textWinner.gameObject.SetActive(false);
        StartGame();
        StartCoroutine(Timer());
        ballDeplacementScript = ball.GetComponent<BallDeplacementScript>();
        if(typeIA == 1) {
            ballDeplacementScript.estIA = true;
        }else if (typeIA == 2)
            ballDeplacementScript.estJoueur = true;
        
    }

    
    void Update()
    {
        if(typeIA == 0) {
            agent.SetDestination(ball.transform.position);
        }else if (typeIA == 1 && !iARandomWait) {
            agent.enabled = false;
            int randomAction = Random.Range(0, 6);
            switch (randomAction) {
                case RIGHT:
                    joueur2.Deplacement(RIGHT);
                    break;
                case DOWN:
                    joueur2.Deplacement(DOWN);
                    break;
                case LEFT:
                    joueur2.Deplacement(LEFT);
                    break;
                case UP:
                    joueur2.Deplacement(UP);
                    break;
                case BUTTONB:
                    
                    break;
                case BUTTONA:
                    if (ballDeplacementScript.attrapedroite) {
                        ballDeplacementScript.Tirer(true);
                        ballDeplacementScript.source.Play();
                    }
                    break;
                default:
                    Debug.Log("swicht");
                    break;
            }
            iARandomWait = true;
            StartCoroutine(IAWait());
        }
        else {
            agent.enabled = false;
        }
        
        if(ballDeplacementScript.attrapegauche)
        {
            joueur1.peutmarcher = false;
        }
        else
        {
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
        ball = Instantiate<GameObject>(BallPrefab, new Vector3(-5.5f, 1f, 0f), Quaternion.identity) as GameObject;
        ballDeplacementScript = ball.GetComponent<BallDeplacementScript>();
        if (typeIA == 1) {
            ballDeplacementScript.estIA = true;
        }
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

    private IEnumerator IAWait() {
        yield return new WaitForSeconds(0.2f);
        iARandomWait = false;
    }

        private IEnumerator Timer() {
        while (timer > 0) {

            yield return new WaitForSeconds(1);
            timer--;
            textTimer.text = timer.ToString();
        }
        Time.timeScale = 0;
        pauseMenuScript.isActive = true;
        pauseMenuScript.isEnd = true;
        ResumeButton.text = "Restart";
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
