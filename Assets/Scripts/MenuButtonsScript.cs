using UnityEngine;
using System.Collections;

public class MenuButtonsScript : MonoBehaviour
{

    [System.Obsolete]
    void OnGUI()
    {
        // Make a background box
        //GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 -100, 600, 600), "Fred & Jammie");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(Screen.width / 2 - 225, Screen.height / 2 -150, 480, 120), "Play"))
        {
            Application.LoadLevel("MenuDiff");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 225, Screen.height / 2 + 25, 480, 120), "Options"))
        {
            Application.LoadLevel("MenuOption");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 225, Screen.height / 2 + 200, 480, 120), "Quit"))
        {
            Application.Quit();
        }
    }

    private void Update()
    {

    }
}