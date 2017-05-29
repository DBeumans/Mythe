using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEventListener : MonoBehaviour {

    private AudioManager audioManager;

    private ScreenFader screenFader;

    private void Start()
    {
        audioManager = GetComponent<AudioManager>();
        screenFader = GetComponent<ScreenFader>();

        audioManager.SoundCompleted += ScreenFadeOut;
    }

    private void ScreenFadeOut()
    {
        if (audioManager.SoundCompleted == null)
            return;

        screenFader.ScreenFadeOut();

    }
}
