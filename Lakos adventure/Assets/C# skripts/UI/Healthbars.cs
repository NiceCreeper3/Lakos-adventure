using UnityEngine;
using UnityEngine.UI;

public class Healthbars : MonoBehaviour
{
    //Values
    #region
    [Header("Pomon to refrens")]
    [SerializeField] private Pomons _pomonInUse;

    [Header("The health bar parts")]
    [SerializeField] private BattelLingMons _battelLing;
    [SerializeField] private Slider _healhtSlider;
    [SerializeField] private Image _fillColor;
    #endregion

    private void Awake()
    {
        // gets the slider componet from the object this script is on
        _healhtSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        // subskribes to the BattelLingMons events 
        _battelLing.OnHealhtChange += BattelLing_OnHealhtChange;
        _battelLing.OnPomonSwiche += _battelLing_OnPomonSwiche;
    }

    // mehtdos four when a event trigger 
    #region
    private void BattelLing_OnHealhtChange(int obj)
    {
        SetPomonHp(obj);
    }

    private void _battelLing_OnPomonSwiche(Pomons obj)
    {
        SetSlider(obj);
    }

    #endregion

    // Methodes
    #region

    // sets the max and current values of the health slider.
    // this method shode be called eny time a new pomon is swiched ind. as to make sure the health bar reprents the pomons HP aturtlig
    private void SetSlider(Pomons maxSet)
    {
        _healhtSlider.maxValue = maxSet.MaxHealt;
        _healhtSlider.value = maxSet.CurrentHealt;

        SetHealtColor();
    }

    // Cahnges the fill amout ind the health bar
    private void SetPomonHp(int HPToSet)
    {
        // makes sure if we get indto negtive digets it stajes at 0
        if (HPToSet > _healhtSlider.value)
            _healhtSlider.value = 0;
        else
            _healhtSlider.value += HPToSet;

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
    #endregion
}
