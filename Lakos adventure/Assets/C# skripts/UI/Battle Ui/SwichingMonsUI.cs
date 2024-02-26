using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwichingMonsUI : MonoBehaviour
{
    [SerializeField] private Transform _seleketPannel;
    [SerializeField] private SwichePomon swichePomon;
    [SerializeField] private TMP_Text[] _pomonNameText;

    [SerializeField] private pomonteam _playerPomonTeam; // ________________________________[remove or change after teast]______________________________
    private Transform[] _pomonNameButton;
    

    private void Start()
    {
        /*
        // make this use (_seleketPannel) to get the Text
        foreach (Transform button in _seleketPannel)
        {
            _pomonName = button.GetChild(0).gameObject.transform.
        }*/
    }

    private void OnEnable()
    {
        swichePomon.OnPomonSwiching += SwichePomon_OnPomonSwiching;
        swichePomon.OnPomonSelket += SwichePomon_OnPomonSelket;

        FillMonNames();
    }

    private void OnDisable()
    {
        swichePomon.OnPomonSwiching -= SwichePomon_OnPomonSwiching;
        swichePomon.OnPomonSelket -= SwichePomon_OnPomonSelket;
    }

    private void SwichePomon_OnPomonSwiching(Pomons arg1, bool arg2)
    {

    }


    private void SwichePomon_OnPomonSelket(Pomons obj)
    {
        ShowPomonInfo();
    }


    private void FillMonNames()
    {
        // sets op so eathe moves name is represendit on a button
        for (int i = 0; i <= _pomonNameText.Length - 1; i++)
        {
            try
            {
                _pomonNameText[i].text = _playerPomonTeam.team[i].PomonName;
            }
            catch
            {
                _pomonNameText[i].text = "";
            }
        }
    }

    private void ShowPomonInfo()
    {

    }
}
