using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class pomondisplay : MonoBehaviour
{
    [SerializeField] private PomonsBluPrint pomon;
    [SerializeField] private Image monportraitfront;
    [SerializeField] private Image monportraitback;
    [SerializeField] private TMP_Text nameandid;
    [SerializeField] private TMP_Text desc;
    [SerializeField] private GenderRatioCalculator genderRatio;


    // Start is called before the first frame update
    void Start()
    {
        loadmon(pomon);
    }

    public void loadmon(PomonsBluPrint entry)
    {
        pomon = entry;
        monportraitfront.sprite = pomon.front;
        monportraitback.sprite = pomon.back;
        desc.text = pomon.description;
        genderRatio.ratio = pomon.genderratio;
        nameandid.text = "0# " + pomon.name;
    }
}
