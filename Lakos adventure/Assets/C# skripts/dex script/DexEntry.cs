using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DexEntry : MonoBehaviour
{
    public PomonsBluPrint bluPrint;
    public int id;
    [SerializeField] private pomondisplay Pomondisplay;
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text spesies;
    [SerializeField] private TMP_Text id_text;

    // Start is called before the first frame update
    void Start()
    {
        Pomondisplay = transform.parent.parent.parent.parent.parent.GetComponentInChildren<pomondisplay>();
        image.sprite = bluPrint.front;
        spesies.text = bluPrint.name;
        id_text.text = id+ "#";
    }

    // Update is called once per frame
    public void pressed()
    {
        Pomondisplay.loadmon(bluPrint);
    }
}
