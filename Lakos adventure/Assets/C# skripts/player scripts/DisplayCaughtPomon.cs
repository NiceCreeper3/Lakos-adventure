using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DisplayCaughtPomon : MonoBehaviour
{
    [SerializeField] private Pomons pomon;
    [SerializeField] private Image monportraitfront;
    [SerializeField] private TMP_Text attack;
    [SerializeField] private TMP_Text defece;
    [SerializeField] private TMP_Text speed;
    [SerializeField] private TMP_Text name_text;
    [SerializeField] private showHealth health;
    [SerializeField] private TMP_Text spesies;
    [SerializeField] private Image gender;

    [SerializeField] private Sprite dude;
    [SerializeField] private Sprite dudette;




    // Start is called before the first frame update
    void Start()
    {
        loadmon(pomon);
    }

    public void loadmon(Pomons entry)
    {
        pomon = entry;
        name_text.text = pomon.PomonName;
        monportraitfront.sprite = pomon.Spesies.front;
        attack.text = "Attack:" + pomon.Attack;
        defece.text = "Defence:" + pomon.Defense;
        speed.text = "speed:" + pomon.Speed;
        if (pomon.IsDude)
        {
            gender.sprite = dude;
        }
        else
        {
            gender.sprite = dudette;
        }
        health.SetSlider(entry);
        spesies.text = "species:" + pomon.Spesies.name;
        name_text.text = pomon.name;
    }
}
