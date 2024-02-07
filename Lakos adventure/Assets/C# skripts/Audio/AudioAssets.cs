using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAssets : MonoBehaviour
{
    private static AudioAssets _instans;

    public static AudioAssets instans
    {
        get
        {
            // makes a audio AduioAssets objeckt if one is not pressent
            if (_instans == null) _instans = (Instantiate(Resources.Load("AduioAssets")) as GameObject).GetComponent<AudioAssets>();
            return _instans;
        }
    }

    public SoundAudioClip[] soundAudioClips;

    [System.Serializable]
    public class SoundAudioClip
    {
        public SoundManger.Sound sound;
        public AudioClip audioClip;
    }
}
