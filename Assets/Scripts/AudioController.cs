using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class AudioController : MonoBehaviour
{
    AudioSource audio2;
    public GameManager gm;
    public PauseMenu pm;
    // Start is called before the first frame update
    void Start()
    {
        audio2 = GetComponent<AudioSource>();
        audio2.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.GameIsPaused || gm.gameOver)
        {
            // If game is paused, pause the audio
            if (audio2.isPlaying)
            {
                audio2.Pause();
            }
        }
        else
        {
            // If game is not paused, unpause the audio if it was paused
            if (!audio2.isPlaying)
            {
                audio2.UnPause();
            }
        }

        if (audio2 != null && !audio2.isPlaying)
        {
            audio2.Play(); // Restart the audio
        }
    }
}
