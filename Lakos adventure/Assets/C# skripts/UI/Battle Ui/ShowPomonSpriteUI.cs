using UnityEngine;
using UnityEngine.UI;

public class ShowPomonSpriteUI : MonoBehaviour
{
    [Header("Images to desplay the look of rhe Pomon")]
    [SerializeField] private Image[] _imagesAvabol;

    [Header("Pomons to refedes")]
    [SerializeField] private BattelLingMons[] _pomosToDisplay;

    private void OnEnable()
    {
        UpdatePomonImage();
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
}
