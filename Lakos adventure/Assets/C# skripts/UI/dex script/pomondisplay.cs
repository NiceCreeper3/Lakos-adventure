using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class pomondisplay : MonoBehaviour
{
    [SerializeField] private PomonsBluPrint pomon;
    [SerializeField] public int id;
    [SerializeField] private Image monportraitfront;
    [SerializeField] private Image monportraitback;
    [SerializeField] private TMP_Text nameandid;
    [SerializeField] private TMP_Text desc;
    [SerializeField] private GenderRatioCalculator genderRatio;
    [SerializeField] private showtypes typedisect;


    // Start is called before the first frame update


    public void loadmon(PomonsBluPrint entry)
    {
        pomon = entry;
        monportraitfront.sprite = pomon.front;
        monportraitback.sprite = pomon.back;
        desc.text = pomon.description;
        genderRatio.ratio = pomon.genderratio;
        nameandid.text = id + "#" + pomon.name;
        typedisect.loadtypes(pomon.PomonElemet);
    }
}
