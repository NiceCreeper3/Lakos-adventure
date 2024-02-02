using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject dex;
    public void Dexopen()
    {
        Instantiate(dex, canvas.transform);
    }
}
