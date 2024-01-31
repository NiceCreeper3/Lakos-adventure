using UnityEngine;

[CreateAssetMenu(fileName = "Moves", menuName = "PomonMoves/No abilty")]
public class BasikMoves : ScriptableObject
{
    [Header("Attack name")]
    public string MoveName;

    [Header("attack base damige")]
    public int power;

    // mite need to tage BattelLingMons
    public virtual void Ability(BattelLingMons interragsen) { }

    /// is goving to contain type and abilety if we have time
}
