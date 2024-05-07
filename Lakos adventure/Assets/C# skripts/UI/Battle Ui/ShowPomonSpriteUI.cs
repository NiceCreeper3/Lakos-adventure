using UnityEngine;
using UnityEngine.UI;

public class ShowPomonSpriteUI : MonoBehaviour
{
    [Header("Images to desplay the look of rhe Pomon")]
    [SerializeField] private Image[] _imagesAvabol;

    [Header("Pomons to refedes")]
    [SerializeField] private BattelLingMons[] _pomosToDisplay;


    [SerializeField] private BattelLingMons I1;
    [SerializeField] private BattelLingMons I2;

    [SerializeField] private Image T3;
    [SerializeField] private Image T4;

    private void OnEnable()
    {
        teast();
        //UpdatePomonImage();
    }

    void UpdatePomonImage()
    {
        Debug.Log($"YYYYYYYYY: {_imagesAvabol.Length}      {_pomosToDisplay.Length}");
        for (int i = 0; i < _imagesAvabol.Length; i++)
        {
            Debug.Log(i);

            if (_pomosToDisplay.Length > i)
            {
                //
                _imagesAvabol[i].sprite = _pomosToDisplay[i].CurrentMon.Spesies.front;
            }
        }
    }

    private void teast()
    {
        T3.sprite = I1.CurrentMon.Spesies.front;
        T4.sprite = I2.CurrentMon.Spesies.front;
    }
}
