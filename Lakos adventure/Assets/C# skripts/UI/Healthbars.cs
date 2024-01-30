using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Healthbars : MonoBehaviour
{
    [Header("Pomon to refrens")]
    [SerializeField] private Pomons _pomonInUse;

    [Header("The health bar parts")]
    [SerializeField] private BattelLingMons _battelLing;
    [SerializeField] private Slider _healhtSlider;
    [SerializeField] private Image _fillColor;

    private void Start()
    {
        _healhtSlider = GetComponent<Slider>(); 

        _healhtSlider.maxValue = _pomonInUse.MaxHealt;
        _healhtSlider.value = _pomonInUse.CurrentHealt;

        _battelLing.OnHealhtChange += BattelLing_OnHealhtChange;
    }

    private void BattelLing_OnHealhtChange(int obj)
    {
        SetPomonHp(obj);
    }

    private void SetPomonHp(int HPToSet)
    {
        if (HPToSet > _healhtSlider.value)
            _healhtSlider.value = 0;
        else
            _healhtSlider.value += HPToSet;

        Debug.Log("hafe presenteg" + _healhtSlider.maxValue * 0.20);

        // add color to endekate damige
        if (_healhtSlider.maxValue * 0.20 >= _healhtSlider.value)
            _fillColor.color = Color.red;
        else if (_healhtSlider.maxValue * 0.50 >= _healhtSlider.value)
            _fillColor.color = Color.yellow;
        else
            _fillColor.color = Color.green;


    }
}
