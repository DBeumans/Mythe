using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAudio : MonoBehaviour {

    /// <summary>
    /// List array for audio clips to play randomly.
    /// </summary>
    [SerializeField]private List<AudioClip> clips = new List<AudioClip>();

    /// <summary>
    /// Reference to the AudioManager script.
    /// </summary>
    private AudioManager audioManager;

    /// <summary>
    /// Speech interval.
    /// </summary>
    [SerializeField]private float inverval;

    private void Start()
    {
        audioManager = GetComponent<AudioManager>();
    }

    /// <summary>
    /// Starts the random audio.
    /// </summary>
    public void StartRandomAudio()
    {
        if (clips.Count <= 0)
            return;

        StartCoroutine(randomAudio(clips));
    }

    /// <summary>
    /// The logic for the random audio you hear while playing.
    /// </summary>
    /// <param name="clips"></param>
    /// <returns></returns>
    private IEnumerator randomAudio(List<AudioClip>clips)
    {
        AudioClip currentClip;
        currentClip = clips[Random.Range(0, clips.Count)];

        while(clips.Count > 0)
        {
            audioManager.PlayAudioOneShot(currentClip);
            currentClip = clips[Random.Range(0, clips.Count)];
            yield return new WaitForSeconds(currentClip.length + inverval);
        }
        // Stopping the coroutine to save performance if by anychance the audioclip list(array) get empty.
        StopCoroutine(randomAudio(clips));
        yield return null;
    }

}
