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

        PomonHPSlider(_pomonInUse);

        _battelLing.OnHealhtChange += BattelLing_OnHealhtChange;
    }

    private void BattelLing_OnHealhtChange(int obj)
    {
        SetPomonHp(obj);
    }

    private void PomonHPSlider(Pomons maxSet)
    {
        _healhtSlider.maxValue = maxSet.MaxHealt;
        _healhtSlider.value = maxSet.CurrentHealt;
        SetHealtColor();
    }

    private void SetPomonHp(int HPToSet)
    {
        if (HPToSet > _healhtSlider.value)
            _healhtSlider.value = 0;
        else
            _healhtSlider.value += HPToSet;

        SetHealtColor();
    }

    // add color to endekate damige
    private void SetHealtColor()
    {
        //sets the color of the fill depending on it the _healhtSlider.value is under a surten %
        // Red = 20% | Yellow = 50% | Green = above 50%
        if (_healhtSlider.maxValue * 0.20 >= _healhtSlider.value)
            _fillColor.color = Color.red;
        else if (_healhtSlider.maxValue * 0.50 >= _healhtSlider.value)
            _fillColor.color = Color.yellow;
        else
            _fillColor.color = Color.green;
    }
}
