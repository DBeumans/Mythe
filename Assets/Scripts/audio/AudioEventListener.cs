using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventListener : MonoBehaviour {

    /// <summary>
    /// Reference to the AudioManager script to use the delegate 'SoundCompleted'.
    /// </summary>
    private AudioManager audioManager;

    /// <summary>
    /// Reference to the ScreenFader script.
    /// </summary>
    private ScreenFader screenFader;

    /// <summary>
    /// Reference to the PlayRandomAudio script.
    /// </summary>
    private PlayRandomAudio randomAudio;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        audioManager = GetComponent<AudioManager>();
        screenFader = GetComponent<ScreenFader>();
        randomAudio = GetComponent<PlayRandomAudio>();

        audioManager.SoundCompleted += screenFadeOut;
        audioManager.SoundCompleted += playRandomAudio;
    }

    /// <summary>
    /// Starts the screen fadeout.
    /// </summary>
    private void screenFadeOut()
    {
        if (audioManager.SoundCompleted == null)
            return;

        screenFader.ScreenFadeOut();
    }

    private void playRandomAudio()
    {
        if (audioManager.SoundCompleted == null)
            return;

        randomAudio.StartRandomAudio();
    }
}
