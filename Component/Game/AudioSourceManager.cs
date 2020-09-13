using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// The audio source for the entire game
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioSourceManager : MonoBehaviour
{
    [SerializeField] AudioMixerGroup sxfMixGroup;

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    void Awake()
    {
        // initialize audio manager
        if (AudioManager.IsInitialised)
        {
            // if there is already an audio source then destroy this one
            Destroy(gameObject);
        }
        else
        {
            // create the audio sources
            Dictionary<AudioTrack, AudioSource> audioSources = new Dictionary<AudioTrack, AudioSource>();

            foreach (AudioTrack track in Enum.GetValues(typeof(AudioTrack)))
            {
                AudioSource source = gameObject.AddComponent<AudioSource>();
                //source.outputAudioMixerGroup = sxfMixGroup;
                audioSources.Add(track, source);
            }

            // initialize the sources with the audio manager
            AudioManager.Initialize(audioSources);
            // make sure this persists between scenes
            DontDestroyOnLoad(gameObject);
        }
    }
}
