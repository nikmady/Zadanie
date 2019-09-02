using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayMenu : MonoBehaviour
{
    [Header("Our Player")]
    public GameObject PointsHUD = null; // UI Points
    public int PointsCounts = 0; // Player's point couunt
    public GameObject GeneralPlayerScript = null; // turn off PlayerController Script
    
    [Header("UI Canvases")]
    public GameObject CanvasWinGame; // UI Canvas Win-Game Scenario
    public GameObject m_CanvasPause; // UI Canvas Pause-Game Scenario
    public GameObject m_CanvasGameOver; // UI Canvas Gameover Scenario

    private void Awake()
    {
        Time.timeScale = 1f;
        m_CanvasGameOver.SetActive(false);
        m_CanvasPause.SetActive(false);
    } // Cheker (needs to setup a correct Time.timscale)

    public void WinGame()
    {
        Time.timeScale = 0f;
        CanvasWinGame.SetActive(true);
    }  // Win-Game scenario (means it will open Canvas Win Game)
    
    //___________________________________________Point's count Method____________________________
    private int callcounter = 1;
    public void PointsCountMethod()
    {

        if (callcounter == 1)
        {
            IEnumerator Waits (float speed)
            {
                PointsCounts += 1;
                yield return new WaitForSeconds(speed);
                callcounter = 1;
            }
            callcounter = 2;
            StartCoroutine(Waits(0.25f));
        }
    } // Points Count Method
    //___________________________________________________________________________________________

    public void GameOver()
    {
        Time.timeScale = 0f;
        m_CanvasGameOver.SetActive(true);
        GeneralPlayerScript.SetActive(false);
    } // Gameover scenario (means it will open Canvas Gameover)

    
    public void PauseGame()
    {
        Time.timeScale = 0f;
        m_CanvasPause.SetActive(true);
        GeneralPlayerScript.SetActive(false);

    } // Pause-Game scenario (means it will open Canvas Pause)

    public void ContinueGame()
    {
        Time.timeScale = 1f;
        m_CanvasGameOver.SetActive(false);
        m_CanvasPause.SetActive(false);
        GeneralPlayerScript.SetActive(true);
        Debug.Log("Continue game");
    } // Continue-Game scenario (means it will open Canvas Continue)
    
    //___________________________________________Restart All Parameters__________________________
    public void Again()
    {
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    } 
    //___________________________________________________________________________________________

    public void ExitGame()
    {
        SceneManager.LoadScene(1);
    } // Exit-Game method to Main Menu

    //___________________________________________General Exit for PC/Android_____________________
    public void ExitMethod()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    //___________________________________________________________________________________________

    //___________________________________________Update Method___________________________________
    void Update()
    {
        PointsHUD.GetComponent<Text>().text = PointsCounts.ToString(); // Show the Player's Point on HUD
        ExitMethod(); // Cheker for press Escape on Android (root option)
    }

}
