using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemAudioLogic : MonoBehaviour {
    
    /// <summary>
    /// Reference to the Audio Manager script.
    /// </summary>
    private AudioManager manager;

    /// <summary>
    /// Reference to the SeeingObject script.
    /// </summary>
    private SeeingObject seeingObject;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]private bool trigger;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]private string audioVoiceCharacter ; // who is speaking ?

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]private int audioFileInt; // what is he / she saying ?

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<AudioManager>();
        seeingObject = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SeeingObject>();
    }

    /// <summary>
    /// Plays the sound.
    /// </summary>
    public void PlaySound()
    {
        manager.PlayAudio((AudioClip)manager.AudioList[audioVoiceCharacter][audioFileInt]);
        return;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(trigger)
        {
            PlaySound();
            return;
        }
    }
}
