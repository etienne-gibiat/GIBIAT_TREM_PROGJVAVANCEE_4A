using UnityEngine;
using System.Collections;

public class MenuButtonsDiffScript : MonoBehaviour
{


    [System.Obsolete]
    void OnGUI()
    {
        
        if (GUI.Button(new Rect(Screen.width / 2 - 225, Screen.height / 2 -150, 480, 120), "Player vs IA"))
        {
            GameManager.typeIA = 1;
            Application.LoadLevel("mainScene");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 225, Screen.height / 2 + 25, 480, 120), "Player vs Player"))
        {
            GameManager.typeIA = 2;
            Application.LoadLevel("mainScene");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 225, Screen.height / 2 + 200, 480, 120), "Player vs NavMesh"))
        {
            GameManager.typeIA = 0;
            Application.LoadLevel("mainScene");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 25, 100, 50), "Back"))
        {
            Application.LoadLevel("Menu");
        }
    }

   
}