using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class showHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text health;
    [Header("The health bar parts")]
    [SerializeField] private Slider _healhtSlider;
    [SerializeField] private Image _fillColor;
    public void SetSlider(Pomons maxSet)
    {
        if (health != null)
            health.text = maxSet.CurrentHealt + "/" + maxSet.MaxHealt;


        _healhtSlider.maxValue = maxSet.MaxHealt;
        _healhtSlider.value = maxSet.CurrentHealt;

        Debug.Log($"Pomon {maxSet.name} has bean set op with {maxSet.CurrentHealt}/{maxSet.MaxHealt} Health");

        SetHealtColor();
    }

    // changes the color in health bar fill. this is to indkate how damige the pomon is
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
