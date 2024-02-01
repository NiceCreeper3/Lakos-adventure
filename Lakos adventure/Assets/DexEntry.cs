using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DexEntry : MonoBehaviour
{
    public PomonsBluPrint bluPrint;
    private pomondisplay Pomondisplay;
    [SerializeField] private TMP_Text spesies;
    [SerializeField] private TMP_Text id;

    // Start is called before the first frame update
    void Start()
    {
        Pomondisplay = transform.parent.GetComponentInChildren<pomondisplay>();

        spesies.text = bluPrint.name;
        id.text = "0"+ "#";
    }

    // Update is called once per frame
    public void pressed()
    {
        Pomondisplay.loadmon(bluPrint);
    }
}
