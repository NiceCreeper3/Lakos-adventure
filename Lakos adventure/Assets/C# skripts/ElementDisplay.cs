using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementDisplay : MonoBehaviour
{
    private ElementObjecks type;
    [SerializeField] private Image image;
    public void loadtype(ElementObjecks element)
    {
        type = element;
        image.color = element.ElementColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
