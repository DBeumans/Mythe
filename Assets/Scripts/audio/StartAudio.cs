using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAudio : MonoBehaviour {

    [SerializeField]private List<AudioClip> clips = new List<AudioClip>();

    private AudioManager manager;

    private void Start()
    {
        manager = GetComponent<AudioManager>();

        manager.PlayAudioInRow(clips);
    }
}
