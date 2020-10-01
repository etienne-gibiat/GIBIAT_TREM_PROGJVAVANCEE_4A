using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    GameObject menuObject;
    private bool isActive = false;

    // Update is called once per frame
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
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            RESUME_BUTTON();
        }
    }

    public void RESUME_BUTTON()
    {
        isActive = !isActive;
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
