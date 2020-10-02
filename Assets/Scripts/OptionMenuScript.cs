using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenuScript : MonoBehaviour
{

    bool isFullScreen = true;

    
    void Update()
    {
        
    }

    public void SetFullScreen(Toggle fullScreen) {
        isFullScreen = fullScreen.isOn;
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, isFullScreen);
    }

        public void SELECT_RESOLUTION(Dropdown resolution) {

        switch (resolution.value) {
            case 0:
                Screen.SetResolution(1920, 1080, isFullScreen);
                break;
            case 1:
                Screen.SetResolution(1600, 1200, isFullScreen);
                break;
            case 2:
                Screen.SetResolution(1600, 900, isFullScreen);
                break;
            case 3:
                Screen.SetResolution(1440, 1080, isFullScreen);
                break;
            case 4:
                Screen.SetResolution(1366, 768, isFullScreen);
                break;
            case 5:
                Screen.SetResolution(1280, 960, isFullScreen);
                break;
            case 6:
                Screen.SetResolution(1280, 720, isFullScreen);
                break;
            case 7:
                Screen.SetResolution(800, 600, isFullScreen);
                break;
            default:
                Screen.SetResolution(1280, 720, isFullScreen);
                break;
        }

    }


    public void BACK_OPTION_BUTTON()
    {
        Application.LoadLevel("Menu");
    }
}
