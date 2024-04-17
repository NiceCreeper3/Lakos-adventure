using UnityEngine;

[CreateAssetMenu(fileName = "Elemets", menuName = "Pomon/Elemets")]
public class ElementObjecks : ScriptableObject
{
    [Header("Flaver info")]
    public string Element;
    public Color ElementColor;
    public Sprite ElementIcon;

    [Header("does 0.5 extra damge")]
    [SerializeField] private ElementObjecks[] _effetive;

    [Header("Resistes 0.25 damage")]
    [SerializeField] private ElementObjecks[] _resestes;

    private double buff = 0.5;
    private double deBuff = 0.25;

    public double ElementMultiplier(PomonsBluPrint defenderElemts)
    {
        double moddefiher = 1;
        // holdes the writen name off the elemts the defender has
        string defenderElemtNames = "";

        // runes frouge all the defending elemets.
        // if eny are ind _strongAgenst then it adds to moddefiher and does the oppsind if ind _weakAgenst
        foreach (ElementObjecks elemt in defenderElemts.PomonElemet)
        {
            // runs fruge all the elemt this Element is strong agenst. and if then it adds bounes damige
            foreach (ElementObjecks attack in _effetive)
                if (elemt == attack)
                    moddefiher += buff;

            // runs fruge defenderes elemetal resistenses. and checks if this elemt is ind there resistenses
            foreach (ElementObjecks resists in elemt._resestes)
                if (resists == this)
                    moddefiher -= deBuff;

            defenderElemtNames += $"{elemt.name }";
        }

        Debug.Log(
            $"defender has {defenderElemts.name} elemts \n" +
            $"{defenderElemtNames}");

        // returns the moddefiher
        return moddefiher;
    }


}
