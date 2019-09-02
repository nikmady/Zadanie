using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    private void Awake()
    {
        GameObject.Find("CameraFadeInOut").GetComponent<CameraFadeControl>().CameraFadeOut = true;
    }


    public void PressedExit() // Press button Exit
    {
        Application.Quit();
    }

    public void PressedStartGame() // Press button Play
    {
        SceneManager.LoadScene(2);
    }
}
