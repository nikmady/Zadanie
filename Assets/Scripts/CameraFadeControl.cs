using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFadeControl : MonoBehaviour
{
    public GameObject m_FadeCamera = null; // - Here we are put the Main Camera
    public GameObject m_BlackImage = null; // - Here we are put a black(Alpha) UI Image

    public bool CameraFadeOut = false; // Check Camera Fade Out 
    public bool CameraFadeIn = false; // Check Camera Fade In 

    private void Awake()
    {
        m_FadeCamera = GameObject.FindGameObjectWithTag("MainCamera").gameObject;
        m_BlackImage = GameObject.Find("FadeInOut").gameObject;
        Time.timeScale = 1f;
    }

    #region myCounters
    private int counterClick = 1;
    private int counterClick2 = 1;
    #endregion

    IEnumerator Pauses(float waits)
    {
        yield return new WaitForSeconds(waits);
        CameraFadeIn = false;
        CameraFadeOut = false;
    } // Game wait

    void FadeMethod() 
    {
        if (CameraFadeOut)
        {
            if (counterClick == 1)
            {
                m_BlackImage.GetComponent<Animator>().SetBool("FadeOut", true);
                m_BlackImage.GetComponent<Animator>().SetBool("FadeIn", false);
                counterClick = 2;
                counterClick2 = 1;
                StartCoroutine(Pauses(1f));
            }
            
        }
        if (CameraFadeIn)
        {
            if (counterClick2 == 1)
            {
                m_BlackImage.GetComponent<Animator>().SetBool("FadeOut", false);
                m_BlackImage.GetComponent<Animator>().SetBool("FadeIn", true);
                counterClick = 1;
                counterClick2 = 2;
                StartCoroutine(Pauses(1f));
            }
            
        }
    }   // Fade In/Fade OUT Methods

    void Update()
    {
        FadeMethod();
    }
}
