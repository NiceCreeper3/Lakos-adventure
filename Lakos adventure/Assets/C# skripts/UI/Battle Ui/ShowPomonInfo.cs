using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowPomonInfo : MonoBehaviour
{
    [Header("Reffrenses")]
    [SerializeField] private SwichePomon _onPomonSeleck;
    [SerializeField] private GameObject _confermbutton;

    [Header("Where to show info")]
    [SerializeField] private Image Image;
    //[SerializeField] private Image _pictureOfPomon;
    [SerializeField] private TMP_Text _flaverText;
    [SerializeField] private TMP_Text _showHealt;
    [SerializeField] private TMP_Text _showAttack;
    [SerializeField] private TMP_Text _showDefens;
    [SerializeField] private TMP_Text _showSpeed;

    private void Awake()
    {
        _onPomonSeleck.OnPomonSelket += OnPomonSeleck_OnPomonSelket;
        _onPomonSeleck.OnPomonSwiching += _onPomonSeleck_OnPomonSwiching;

    }

    private void OnPomonSeleck_OnPomonSelket(Pomons obj)
    {
        ShowInfo(obj);
        turnOnOffConfurm(true);
    }

    private void _onPomonSeleck_OnPomonSwiching(Pomons arg1, bool arg2)
    {
        turnOnOffConfurm(false);
    }

    private void ShowInfo(Pomons pomonToShow)
    {     
        Image.sprite = pomonToShow.Spesies.front;
        _flaverText.text = pomonToShow.Spesies.description;
        _showHealt.text = $"{pomonToShow.CurrentHealt}Hp/{pomonToShow.MaxHealt}HP";
        _showAttack.text = pomonToShow.Attack.ToString();
        _showDefens.text = pomonToShow.Defense.ToString();
        _showSpeed.text = pomonToShow.Speed.ToString();
    }

    private void turnOnOffConfurm(bool trunOnOff)
    {
        _confermbutton.SetActive(trunOnOff);
    }

}
