using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SwichePomon : MonoBehaviour
{
    public event Action<Pomons> OnPomonSelket;
    public event Action<Pomons, bool> OnPomonSwiching;

    [Header("the team of pomon chosen to battel")]
    [SerializeField] private Pomons[] _pomonTeam;

    private int _seletedPomon;

    // the buttons of picing a new Pomon is goving to be here
    public void SeltedPomon(int pomonNummber)
    {
        Debug.Log("attemting to swiche Pomon");

        if (_pomonTeam[pomonNummber].CurrentHealt > 0)
        {
            _seletedPomon = pomonNummber;
        }
    }

    // is goving to handel swithing ind a new pokemon
    public void SwitchPomonConfurmt()
    {
        OnPomonSwiching?.Invoke(_pomonTeam[_seletedPomon], false);
    }


}
