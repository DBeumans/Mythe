using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputEventListener : MonoBehaviour {

    /// <summary>
    /// Reference to the Audiomanager script.
    /// </summary>
    private AudioManager audioManager;

    /// <summary>
    /// Reference to the MouseInput script.
    /// </summary>
    private MouseInput input;

    private void Start()
    {
        input = GetComponent<MouseInput>();

        audioManager = GetComponent<AudioManager>();
        audioManager.SoundCompleted += enableInput;
    }

    private void enableInput()
    {
        input.enabled = true;
    }
}
