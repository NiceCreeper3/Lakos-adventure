using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwichingMonsUI : MonoBehaviour
{
    [SerializeField] private Transform _seleketPannel;
    [SerializeField] private SwichePomon _swichePomon;
    [SerializeField] private GameObject[] _PomonTextPlate;
    [SerializeField] private List<TMP_Text> _pomonNameText;

    [SerializeField] private pomonteam _playerPomonTeam; // ________________________________[remove or change after teast]______________________________

    private void Start()
    {
        _pomonNameText = new List<TMP_Text>();

        // garabes all the text values by getting the child of the gameobjeck
        foreach (GameObject plate in _PomonTextPlate)
        {
            //_pomonNameText.Add(plate.transform.GetChild(0).GetComponent<TMP_Text>());
            _pomonNameText.Add(plate.GetComponentInChildren<TMP_Text>());
        }
            
    }

    private void OnEnable()
    {
        _swichePomon.OnPomonSwiching += SwichePomon_OnPomonSwiching;
        _swichePomon.OnPomonSelket += SwichePomon_OnPomonSelket;

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
        Debug.Log("ggg");

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
