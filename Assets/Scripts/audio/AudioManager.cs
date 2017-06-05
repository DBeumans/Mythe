using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    /// <summary>
    /// Reference to the audio source.
    /// </summary>
    private AudioSource source;
    /// <summary>
    /// Getter for AudioSource so other script can use it.
    /// </summary>
    public AudioSource Source { get { return source; } }

    /// <summary>
    /// Dictionary reference, used to store the audio clips
    /// </summary>
    private Dictionary<string, List<AudioClip>> audio_list = new Dictionary<string, List<AudioClip>>();
    /// <summary>
    /// public get, used to access the dictionary outside this script.
    /// </summary>
    public Dictionary<string, List<AudioClip>> AudioList { get { return audio_list; } }

    /// <summary>
    /// public delegate to let other script, if needed , know that the audio in row is done playing.
    /// </summary>
    public delegate void SoundCompletedEvent();
    public SoundCompletedEvent SoundCompleted;
    
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        constructAudioArray();
    }

    /// <summary>
    /// Construct the audio files from the resource folder into a dictionary.
    /// </summary>
    private void constructAudioArray()
    {
        Object[] audioFiles = Resources.LoadAll("Audio/");
        for (int i = 0; i < audioFiles.Length; i++)
        {
            if (audioFiles[i].name.Contains("Blauwbaard"))
            {
                if (!audio_list.ContainsKey("Blauwbaard"))
                    audio_list.Add("Blauwbaard", new List<AudioClip>());

                audio_list["Blauwbaard"].Add((AudioClip)audioFiles[i]);
                continue;
            }
            if (audioFiles[i].name.Contains("Ghost"))
            {
                if (!audio_list.ContainsKey("Ghost"))
                    audio_list.Add("Ghost", new List<AudioClip>());

                audio_list["Ghost"].Add((AudioClip)audioFiles[i]);
                continue;
            }
            if (audioFiles[i].name.Contains("Sophia"))
            {
                if (!audio_list.ContainsKey("Sophia"))
                    audio_list.Add("Sophia", new List<AudioClip>());

                audio_list["Sophia"].Add((AudioClip)audioFiles[i]);
                continue;
            }
        }
        audioFiles = new Object[0];
    }

    /// <summary>
    /// Plays audio once, does not stop when other audio files are playing.
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="volume"></param>
    /// <param name="_source"></param>
    public void PlayAudioOneShot(AudioClip clip, float volume = 1)
    {
        source.volume = volume;
        source.PlayOneShot(clip);
    }

    /// <summary>
    /// Plays audio but stop the current audio playing.
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="volume"></param>
    public void PlayAudio(AudioClip clip , float volume =1)
    {
        source.volume = volume;
        source.clip = clip;
        source.Play();
    }

    /// <summary>
    /// Plays audio clips in row.
    /// </summary>
    /// <param name="clips"></param>
    /// <param name="volume"></param>
    public void PlayAudioInRow(List<AudioClip> clips, float volume =1)
    {
        source.volume = volume;
        StartCoroutine(audioSequence(clips));
    }

    /// <summary>
    /// Stops the current audio playing.
    /// </summary>
    /// <param name="source"></param>
    public void StopAudio(AudioSource source)
    {
        source.Stop();
    }
    /// <summary>
    ///  This function lets the clips plays after each other and delete the current playing ( from local array )
    ///  Call PlayAudioInRow(List<AudioClip> clips, float volume =1) to use this function.
    /// </summary>
    /// <param name="clips"></param>
    /// <returns></returns>
    private IEnumerator audioSequence(List<AudioClip>clips)
    {
        AudioClip currClip = clips[0];

        while (clips.Count > 0)
        {
            if(!source.isPlaying)
            {
                PlayAudio(currClip);
                clips.RemoveAt(0);

                if (clips.Count > 0)
                    currClip = clips[0];

                yield return new WaitForSeconds(source.clip.length + 0.5f);
            }
        }
        SoundCompleted();
        StopCoroutine(audioSequence(clips));
        yield return null; 
    }
}
