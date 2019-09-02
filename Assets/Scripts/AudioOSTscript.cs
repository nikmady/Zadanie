using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOSTscript : MonoBehaviour
{
    // Descriptiom: via this script we are turn on music audio

    public AudioSource m_Audio = null;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); // it need to dont destroy on Load this GameObject in the next Scenes(Level)
    }

    private void Start()
    {
        m_Audio.Play();
    }
}
