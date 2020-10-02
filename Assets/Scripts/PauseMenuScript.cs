using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject menuObject;

    [SerializeField]
    Text resumeButton;

    public bool isActive = false;
    public bool isEnd = false;


    void Update()
    {
        if(isActive)
        {
            menuObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }
        else
        {
            menuObject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }

        if (isEnd) {
            resumeButton.text = "Restart";
        }
        
        if(Input.GetKeyDown(KeyCode.Escape) && !isEnd)
        {
            RESUME_BUTTON();
        }
    }

    public void RESUME_BUTTON()
    {
        if (!isEnd) {
            isActive = !isActive;
        }
        else {
            Application.LoadLevel("mainScene");
        }
    }

    public void MAIN_MENU_BUTTON()
    {
        Application.LoadLevel("Menu");
    }

    public void QUIT_BUTTON()
    {
        Application.Quit();
    }
}
