using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Elemets", menuName = "Type/Elemets")]
public class ElementObjecks : ScriptableObject
{
    public string Element;
    public Color ElementColor;

    private double buff = 0.5;

    [SerializeField] private ElementObjecks[] _strongAgenst;
    [SerializeField] private ElementObjecks[] _weakAgenst;

    public double ElementMultiplier(PomonsBluPrint defenderElemts)
    {
        double moddefiher = 1;

        // runes frouge all the defending elemets.
        // if eny are ind _strongAgenst then it adds to moddefiher and does the oppsind if ind _weakAgenst
        foreach (ElementObjecks elemt in defenderElemts.PomonElemet)
        {
            // runs frug all of the elemts its it srong agenst. if eny defending elemts mathe with one ind _strongAgenst. then it adds to moddefiher
            foreach (ElementObjecks strong in _strongAgenst)
                if (elemt == strong)
                    moddefiher += buff;

            foreach (ElementObjecks defend in _weakAgenst)
                if (elemt == defend)
                    moddefiher -= buff;
        }



        return moddefiher;
    }


}
