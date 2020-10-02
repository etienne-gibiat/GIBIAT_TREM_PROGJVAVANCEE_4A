using UnityEngine;
using System.Collections;

public class MenuButtonsScript : MonoBehaviour
{

    [System.Obsolete]
    void OnGUI()
    {
        
        if (GUI.Button(new Rect(Screen.width / 2 - 225, Screen.height / 2 -150, 480, 120), "Play"))
        {
            Application.LoadLevel("MenuDiff");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 225, Screen.height / 2 + 25, 480, 120), "Option"))
        {
            Application.LoadLevel("MenuOption");
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 225, Screen.height / 2 + 200, 480, 120), "Quit"))
        {
            Application.Quit();
        }

        
    }

    
}