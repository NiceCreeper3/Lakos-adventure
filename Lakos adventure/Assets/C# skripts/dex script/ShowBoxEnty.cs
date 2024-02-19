using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShowBoxEnty : MonoBehaviour
{
    [SerializeField] private Pomons pomon;
    [SerializeField] private Image monportraitfront;
    [SerializeField] private TMP_Text name_text;
    [SerializeField] private showHealth health;

    public void loadmon(Pomons entry)
    {
        pomon = entry;
        name_text.text = pomon.PomonName;
        monportraitfront.sprite = pomon.Spesies.front;
        health.SetSlider(entry);
    }
}
