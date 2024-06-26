using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class DisplayCaughtPomon : MonoBehaviour
{
    [SerializeField] public Pomons pomon;
    [SerializeField] private Image monportraitfront;
    [SerializeField] protected TMP_Text attack;
    [SerializeField] protected TMP_Text defece;
    [SerializeField] protected TMP_Text speed;
    [SerializeField] private TMP_Text name_text;
    [SerializeField] private showHealth health;
    [SerializeField] private TMP_Text spesies;
    [SerializeField] private TMP_Text level_text;
    [SerializeField] private MoveInitialize moveInitializer;
    [SerializeField] private Image gender;
    [SerializeField] private showtypes typedisect;

    [SerializeField] private Sprite dude;
    [SerializeField] private Sprite dudette;

    public virtual void loadmon(Pomons entry)
    {
        pomon = entry;
        name_text.text = pomon.PomonName;
        monportraitfront.sprite = pomon.Spesies.front;
        attack.text = "Attack:" + pomon.Attack;
        defece.text = "Defence:" + pomon.Defense;
        speed.text = "speed:" + pomon.Speed;
        level_text.text = pomon.Level + " lv.";
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
        try
        {
            moveInitializer.Updatemoves(pomon.PomonMoves);
        }
        catch
        {

        }
        typedisect.loadtypes(pomon.Spesies.PomonElemet);
    }
}
