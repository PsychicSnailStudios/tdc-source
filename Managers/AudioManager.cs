using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// Handles the games audio
    /// </summary>
    public static class AudioManager
    {
        #region Fields

        // singleton support
        static bool isInitialised = false;

        // audio sources to play from
        static AudioSource masterAudioSource;
        static AudioSource playerAudioSource;
        static AudioSource hostileAudioSource;
        static AudioSource effectsAudioSource;
        static AudioSource musicAudioSource;

        // the audio files in the game
        static Dictionary<AudioFile, AudioClip> audioClips = new Dictionary<AudioFile, AudioClip>();

        #endregion

        #region Properties

        /// <summary>
        /// Weather or not the audio source has already been initialized
        /// </summary>
        public static bool IsInitialised
        {
            get { return isInitialised; }
            set { isInitialised = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the audio manager
        /// </summary>
        /// <param name="sources">the audio sources to use</param>
        public static void Initialize(Dictionary<AudioTrack, AudioSource> sources)
        {
            // set the sources
            foreach (KeyValuePair<AudioTrack, AudioSource> entry in sources)
            {
                // run through the dictionary and set the sources appropriately
                switch (entry.Key)
                {
                    case AudioTrack.Master:
                        masterAudioSource = entry.Value;
                        break;
                    case AudioTrack.Player:
                        playerAudioSource = entry.Value;
                        break;
                    case AudioTrack.Hostile:
                        hostileAudioSource = entry.Value;
                        break;
                    case AudioTrack.SFX:
                        effectsAudioSource = entry.Value;
                        break;
                    case AudioTrack.Music:
                        musicAudioSource = entry.Value;
                        break;
                    default:
                        // default to master
                        masterAudioSource = entry.Value;
                        break;
                }
            }

            // make sure the list is clear
            audioClips.Clear();

            // --> add clips <--
            audioClips.Add(AudioFile.Death, Resources.Load("Audio/boom") as AudioClip);
            audioClips.Add(AudioFile.EnemyFire, Resources.Load("Audio/fire1") as AudioClip);
            audioClips.Add(AudioFile.PlayerFire, Resources.Load("Audio/fire1") as AudioClip);
            audioClips.Add(AudioFile.PlayerHum, Resources.Load("Audio/PlayerHum") as AudioClip);
            audioClips.Add(AudioFile.PlayerShield, Resources.Load("Audio/shield") as AudioClip);
            audioClips.Add(AudioFile.Ricochet, Resources.Load("Audio/ricochet") as AudioClip);
            audioClips.Add(AudioFile.Gameover1, Resources.Load("Audio/gameover") as AudioClip);
            audioClips.Add(AudioFile.Gameover2, Resources.Load("Audio/gameover_layer") as AudioClip);

        // set the initialization flag
        isInitialised = true;
        }

        /// <summary>
        /// Plays the given audio clip
        /// </summary>
        /// <param name="name">name of the audio clip to play</param>
        /// <param name="track">the track to play in</param>
        public static void Play(AudioFile name, AudioTrack track)
        {
            // play in appropriate track
			switch (track)
			{
				case AudioTrack.Master:
                    masterAudioSource.PlayOneShot(audioClips[name]);
                    break;
				case AudioTrack.Player:
                    playerAudioSource.PlayOneShot(audioClips[name]);
                    break;
				case AudioTrack.Hostile:
                    hostileAudioSource.PlayOneShot(audioClips[name]);
                    break;
				case AudioTrack.SFX:
                    effectsAudioSource.PlayOneShot(audioClips[name]);
                    break;
				case AudioTrack.Music:
                    musicAudioSource.PlayOneShot(audioClips[name]);
                    break;
				default:
                    // default to master
                    masterAudioSource.PlayOneShot(audioClips[name]);
                    break;
			}
        }

        /// <summary>
        /// Sets the pitch of the source
        /// </summary>
        /// <param name="pitch">the new pitch to play at</param>
        /// <param name="track">the track to edit</param>
        public static void SetPitch(float pitch, AudioTrack track)
        {
            // edit the appropriate track
            switch (track)
            {
                case AudioTrack.Master:
                    masterAudioSource.pitch = pitch;
                    break;
                case AudioTrack.Player:
                    playerAudioSource.pitch = pitch;
                    break;
                case AudioTrack.Hostile:
                    hostileAudioSource.pitch = pitch;
                    break;
                case AudioTrack.SFX:
                    effectsAudioSource.pitch = pitch;
                    break;
                case AudioTrack.Music:
                    musicAudioSource.pitch = pitch;
                    break;
                default:
                    // default to master
                    masterAudioSource.pitch = pitch;
                    break;
            }
        }

        /// <summary>
        /// Sets the volume of the source
        /// </summary>
        /// <param name="volume">the new volume to play at</param>
        /// <param name="track">the track edit</param>
        public static void SetVolume(float volume, AudioTrack track)
        {
            // edit the appropriate track
            switch (track)
            {
                case AudioTrack.Master:
                    masterAudioSource.volume = volume;
                    break;
                case AudioTrack.Player:
                    playerAudioSource.volume = volume;
                    break;
                case AudioTrack.Hostile:
                    hostileAudioSource.volume = volume;
                    break;
                case AudioTrack.SFX:
                    effectsAudioSource.volume = volume;
                    break;
                case AudioTrack.Music:
                    musicAudioSource.volume = volume;
                    break;
                default:
                    // default to master
                    masterAudioSource.volume = volume;
                    break;
            }
        }

        #endregion
    }