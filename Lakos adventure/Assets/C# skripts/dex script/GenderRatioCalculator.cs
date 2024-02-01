using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenderRatioCalculator : MonoBehaviour
{
    public int ratio;

    [SerializeField] private Slider gender;
    [SerializeField] private TMP_Text text;



    // Update is called once per frame
    void Update()
    {
        text.text = ratio +"%";
        gender.value = ratio;
    }
}
