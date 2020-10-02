using UnityEngine;
using System.Collections;

public class MenuButtonsDiffScript : MonoBehaviour
{

    [System.Obsolete]
    void OnGUI()
    {
        // Make a background box
        //GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 -100, 600, 600), "Fred & Jammie");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(Screen.width / 2 - 225, Screen.height / 2 -150, 480, 120), "Player vs IA"))
        {
            Application.LoadLevel("mainScene");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 225, Screen.height / 2 + 25, 480, 120), "Player vs Player"))
        {
            Application.LoadLevel("mainScene");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 225, Screen.height / 2 + 200, 480, 120), "Player vs NavMesh"))
        {
            Application.LoadLevel("mainScene");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 25, 100, 50), "Back"))
        {
            Application.LoadLevel("Menu");
        }
    }

    private void Update()
    {

    }
}