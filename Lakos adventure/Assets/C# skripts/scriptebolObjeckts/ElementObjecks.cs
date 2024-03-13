using UnityEngine;

[CreateAssetMenu(fileName = "Elemets", menuName = "Type/Elemets")]
public class ElementObjecks : ScriptableObject
{
    public string Element;
    public Color ElementColor;

    [Header("does 0.5 extra damge")]
    [SerializeField] private ElementObjecks[] _effetive;

    [Header("Resistes 0.25 damage")]
    [SerializeField] private ElementObjecks[] _resestes;

    private double buff = 0.5;
    private double deBuff = 0.25;

    public double ElementMultiplier(PomonsBluPrint defenderElemts)
    {
        double moddefiher = 1;

        Debug.Log($"defender has {defenderElemts.name} elemts");

        // runes frouge all the defending elemets.
        // if eny are ind _strongAgenst then it adds to moddefiher and does the oppsind if ind _weakAgenst
        foreach (ElementObjecks elemt in defenderElemts.PomonElemet)
        {
            Debug.Log($"{elemt.name} elemts");

            // runs fruge all the elemt this Element is strong agenst. and if then it adds bounes damige
            foreach (ElementObjecks attack in _effetive)
                if (elemt == attack)
                    moddefiher += buff;

            // runs fruge defenderes elemetal resistenses. and checks if this elemt is ind there resistenses
            foreach (ElementObjecks resists in elemt._resestes)
                if (resists == this)
                    moddefiher -= deBuff;
        }


        // returns the moddefiher
        return moddefiher;
    }


}
