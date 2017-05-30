using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemAudioLogic : MonoBehaviour {

    private AudioManager manager;
    private SeeingObject seeingObject;

    [SerializeField]private bool trigger;
    [SerializeField]private string audioVoiceCharacter ; // who is speaking ?
    [SerializeField]private int audioFileInt; // what is he / she saying ?

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<AudioManager>();
        seeingObject = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SeeingObject>();
    }

    public void PlaySound()
    {
        manager.PlayAudio((AudioClip)manager.AudioList[audioVoiceCharacter][audioFileInt]);
        return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(trigger)
        {
            PlaySound();
            return;
        }
    }
}
