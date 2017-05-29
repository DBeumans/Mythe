using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    private AudioSource source;

    private Dictionary<string, List<AudioClip>> audio_list = new Dictionary<string, List<AudioClip>>();
    public Dictionary<string, List<AudioClip>> AudioList { get { return audio_list; } }

    public delegate void SoundCompletedEvent();
    public SoundCompletedEvent SoundCompleted;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        constructAudioArray();
    }

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

    public void PlayAudioOneShot(AudioClip clip, float volume = 1)
    {
        StopAudio(this.source);
        source.volume = volume;
        source.PlayOneShot(clip);
        return;
    }

    public void PlayAudio(AudioClip clip , float volume =1)
    {
        source.volume = volume;
        source.clip = clip;
        source.Play();
    }

    public void PlayAudioInRow(List<AudioClip> clips, float volume =1)
    {
        source.volume = volume;
        StartCoroutine(audioSequence(clips));
    }

    public void StopAudio(AudioSource source)
    {
        source.Stop();
    }

    private IEnumerator audioSequence(List<AudioClip>clips)
    {
        AudioClip currClip = clips[0];

        while (clips.Count > 0)
        {
            if(!source.isPlaying)
            {
                source.clip = currClip;
                source.Play();
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
