using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwichingMonsUI : MonoBehaviour
{
    [SerializeField] private pomonteam _playerPomonTeam;

    [SerializeField] private Transform _seleketPannel;
    [SerializeField] private SwichePomon _swichePomon;
    [SerializeField] private GameObject[] _PomonTextPlate;
    [SerializeField] private List<TMP_Text> _pomonNameText;

    private void OnEnable()
    {
        _swichePomon.OnPomonSwiching += SwichePomon_OnPomonSwiching;
        _swichePomon.OnPomonSelket += SwichePomon_OnPomonSelket;

        _pomonNameText = new List<TMP_Text>();

        // garabes all the text values by getting the child of the gameobjeck
        foreach (GameObject plate in _PomonTextPlate)
            _pomonNameText.Add(plate.GetComponentInChildren<TMP_Text>());

        FillMonNames();
    }

    private void OnDisable()
    {
        _swichePomon.OnPomonSwiching -= SwichePomon_OnPomonSwiching;
        _swichePomon.OnPomonSelket -= SwichePomon_OnPomonSelket;
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
        //_PomonTextPlate[0].SetActive(true);
        _pomonNameText[0].text = _playerPomonTeam.team[0].PomonName;

        Debug.Log(_playerPomonTeam.team[0].CurrentHealt);

        // sets op so eathe moves name is represendit on a button
        for (int i = 0; i < _PomonTextPlate.Length; i++)
        {
            
            try
            {
                // checkes if the Pomon is on full HP
                if (_playerPomonTeam.team[i].CurrentHealt > 0)
                {
                    


                    // sets the name of the pomon on the button
                    _PomonTextPlate[i].SetActive(true);
                    Debug.Log("was called");
                    _pomonNameText[i].text = _playerPomonTeam.team[i].PomonName;               
                }
                else
                {
                    // perhaps make it insted turn the button gray and disabel cliking on it
                      
                }

            }
            catch
            {
                _PomonTextPlate[i].SetActive(false);
                Debug.Log("missing pomon");
            }
        }
    }

    private void ShowPomonInfo()
    {

    }
}
