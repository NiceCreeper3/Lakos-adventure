using UnityEngine;
using UnityEngine.UI;

public class Healthbars : MonoBehaviour
{
    //Values
    #region
    [Header("The health bar parts")]
    [SerializeField] private BattelLingMons _battelLingEvents;
    [SerializeField] private SwichePomon _omSwiche;
    [SerializeField] private Slider _healhtSlider;
    [SerializeField] private Image _fillColor;

    private Pomons current;
    #endregion

    private void Awake()
    {
        // gets the slider componet from the object this script is on
        _healhtSlider = GetComponent<Slider>();

        // subskribes to the BattelLingMons events 
        _battelLingEvents.OnHealhtChange += BattelLing_OnHealhtChange;
        _omSwiche.OnPomonSwiching += _omSwiche_OnPomonSwiching;
        //_battelLingEvents.OnPomonSwiche += _battelLing_OnPomonSwiche;
    }

    private void _omSwiche_OnPomonSwiching(Pomons arg1, bool arg2)
    {
        SetSlider(arg1);
    }

    // mehtdos four when a event trigger 
    #region
    private void BattelLing_OnHealhtChange(int obj)
    {
        //SetPomonHp(obj);
        _healhtSlider.value = current.CurrentHealt;
        SetHealtColor();
    }

    #endregion

    // Methodes
    #region

    // sets the max and current values of the health slider.
    // this method shode be called eny time a new pomon is swiched ind. as to make sure the health bar reprents the pomons HP aturtlig
    private void SetSlider(Pomons maxSet)
    {
        current = maxSet;

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
    #endregion
}
