using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour {

    /// <summary>
    /// A list (array) with audio clips that will be played at the start of the game.
    /// </summary>
    [SerializeField]private List<AudioClip> clips = new List<AudioClip>();

    /// <summary>
    /// Reference to the audio manager script.
    /// </summary>
    private AudioManager manager;

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        manager = GetComponent<AudioManager>();
        manager.PlayAudioInRow(clips);
    }

    
}
