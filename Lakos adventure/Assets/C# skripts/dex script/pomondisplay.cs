using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class pomondisplay : MonoBehaviour
{
    [SerializeField] private PomonsBluPrint pomon;
    [SerializeField] private Image monportrait;
    [SerializeField] private TMP_Text nameandid;
    [SerializeField] private TMP_Text desc;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void loadmon(PomonsBluPrint entry)
    {

    }
}
