using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManger
{
    // the difrents sound types we are lokking four
    public enum Sound
    {
        OnPomonEnterBattel,
        BattelAttackBtb,
        BattelSwicheButtonsBtb,
        teast
         
    }

    private static Dictionary<Sound, float> _soundTimmerDictinart;
    private static GameObject _oneShotGameObject;
    private static AudioSource _oneShotAudioSourse;

    public static void Initialize()
    {
        _soundTimmerDictinart = new Dictionary<Sound, float>();
        _soundTimmerDictinart[Sound.teast] = 0;
    }

    public static void Playsound(Sound sound, Vector3 position)
    {
        // checkes if we are alowed to play audio
        if (CanPlaySound(sound))
        {
            // adds a AudioSource to the gameobject and uses it to play sound
            GameObject soundGameObject = new GameObject("Sound");
            soundGameObject.transform.position = position;
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.clip = GetAudioClip(sound);
            audioSource.Play();

            // destorye the gameojeck if 
            Object.Destroy(soundGameObject, audioSource.clip.length);
        }
    }

    public static void Playsound(Sound sound)
    {
        // checkes if we are alowed to play audio
        if (CanPlaySound(sound))
        {
            if (_oneShotGameObject == null)
            {
                // adds a AudioSource to the gameobject and uses it to play sound
                _oneShotGameObject = new GameObject("Sound");
                _oneShotAudioSourse = _oneShotGameObject.AddComponent<AudioSource>();
            }

            _oneShotAudioSourse.PlayOneShot(GetAudioClip(sound));
        }
    }


    private static bool CanPlaySound(Sound sound)
    {
        switch (sound)
        {
            default:
                return true;

            case Sound.teast:
                if (_soundTimmerDictinart.ContainsKey(sound))
                {
                    float lastTimePlayer = _soundTimmerDictinart[sound];
                    float playerMoveTimmerMax = .05f;

                    // checkes if inufe time has passed that we can play the Audio agien
                    if (lastTimePlayer + playerMoveTimmerMax < Time.time)
                    {
                        _soundTimmerDictinart[sound] = Time.time;
                        return true;
                    }
                    else
                    {
                        return false;
                    }                   
                }
                else
                {
                    return true;
                }
        }
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        // runds fruge all the audio clips ind the array and returns it if it finds it
        foreach (AudioAssets.SoundAudioClip soundAudio in AudioAssets.instans.soundAudioClips)
        {
            if (soundAudio.sound == sound)
            {
                return soundAudio.audioClip;
            }
        }

        Debug.LogError($"Sound {sound} not found!");
        return null;
    }
}
