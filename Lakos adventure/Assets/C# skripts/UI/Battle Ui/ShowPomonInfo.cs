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
    [SerializeField] private TMP_Text _flaverText;
    [SerializeField] private TMP_Text _showLevel;
    [SerializeField] private TMP_Text _showHealt;
    [SerializeField] private TMP_Text _showAttack;
    [SerializeField] private TMP_Text _showDefens;
    [SerializeField] private TMP_Text _showSpeed;

    [SerializeField] private GameObject[] _elementImages;

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
        // Info
        Image.sprite = pomonToShow.Spesies.front;
        if (pomonToShow.Level != null)
            _showLevel.text = $"({pomonToShow.Level.GetLevelNumber()})";
        _flaverText.text = pomonToShow.Spesies.description;

        #region Pomon states
        _showHealt.text = $"({pomonToShow.CurrentHealt}/{pomonToShow.MaxHealt})";
        _showAttack.text = $"Attack:({pomonToShow.Attack})";
        _showDefens.text = $"Defense:({pomonToShow.Defense})";
        _showSpeed.text = $"Speed:({pomonToShow.Speed})";
        #endregion

        // rundes fruge a the elements the pomon has
        // it runds fruge det images array inset of the elemets array 
        for (int i = 0; i < _elementImages.Length; i++)
        {
            // Check if the index is within the bounds of pomonToShow.Spesies.PomonElemet
            // checks if there is a element to put indto the image space.
            // it does this by cheking if the row in image array is bigger then the amout of elements the pokemon has
            if (pomonToShow.Spesies.PomonElemet.Length > i)
            {
                // shows the elements the Pomon has
                _elementImages[i].GetComponent<Image>().sprite = pomonToShow.Spesies.PomonElemet[i].ElementIcon;
                _elementImages[i].SetActive(true);
            }
            else
            {
                _elementImages[i].SetActive(false);
            }
        }


    }

    private void turnOnOffConfurm(bool trunOnOff)
    {
        _confermbutton.SetActive(trunOnOff);
    }

}
