using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    [SerializeField] private SoundManger.Sound sound;

    // playes the given aduio klip
    public void PlayAudioOnPress()
    {
        SoundManger.Playsound(sound);
    }
}
