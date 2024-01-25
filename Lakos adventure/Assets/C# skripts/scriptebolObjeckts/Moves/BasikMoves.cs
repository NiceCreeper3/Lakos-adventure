using UnityEngine;

[CreateAssetMenu(fileName = "Moves", menuName = "PomonMoves/No abilty")]
public class BasikMoves : ScriptableObject
{
    public string MoveName;

    public int power;

    // mite need to tage BattelLingMons
    public virtual void Abilety(BattelLingMons interragsen) { }

    /// is goving to contain type and abilety if we have time
}
