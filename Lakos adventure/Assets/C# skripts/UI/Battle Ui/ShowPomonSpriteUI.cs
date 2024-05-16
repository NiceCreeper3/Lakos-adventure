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
    }

    void UpdatePomonImage()
    {
        // runds fruge all the images and adds a pomon sprite to them
        for (int i = 0; i < _imagesAvabol.Length; i++)
        {
            Debug.Log(i);

            if (_pomosToDisplay.Length > i)
            {
                _imagesAvabol[i].sprite = _pomosToDisplay[i].CurrentMon.Spesies.front;
            }
        }
    }
}
