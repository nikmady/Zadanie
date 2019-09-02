using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroWait : MonoBehaviour
{
    IEnumerator Waits(float timewait)
    {
        yield return new WaitForSeconds(timewait);
        GameObject.Find("CameraFadeInOut").GetComponent<CameraFadeControl>().CameraFadeIn = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        StartCoroutine(Waits(3f));
    }
}
