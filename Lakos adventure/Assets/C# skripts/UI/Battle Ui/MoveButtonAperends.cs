using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveButtonAperends : MonoBehaviour
{
    // refrends to what info to show
    [HideInInspector] public Moves MoveToRepresent;

    private Button _buttonPlate;

    [SerializeField] private TMP_Text _Text;
    [SerializeField] private Image _elemteIcon;

   

    // Start is called before the first frame update
    void Awake()
    {
        _buttonPlate = transform.GetComponent<Button>();
    }

    private void OnEnable()
    {
        // setting Button aperends
        Debug.Log($"Set Button aprends using {MoveToRepresent.MoveName}");
        SetText();
        SetColorAndIcon();
    }

    private void SetText()
    {
        _Text.text = MoveToRepresent.MoveName;
    }

    private void SetColorAndIcon()
    {
        //_buttonPlate.onClick

        // gets a tempurary refrends to the moves element
        ElementObjecks element = MoveToRepresent.MoveElement;

        if (element.ElementIcon != null)
            _elemteIcon.sprite = element.ElementIcon;

        _buttonPlate.GetComponent<Image>().color = element.ElementColor;

    }
}
