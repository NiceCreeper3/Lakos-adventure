using UnityEngine;

[CreateAssetMenu(fileName = "Moves", menuName = "PomonMoves/No abilty")]
public class BasikMoves1 : ScriptableObject
{
    [Header("Flaver")]
    public string MoveName;
    public string MoveDiskrepseon;

    [Header("attack")]
    public int power;
    public ElementObjecks MoveElement;

    // mite need to tage BattelLingMons
    public virtual void AbilityBefore(BattelLingMons interragsen) { }

    public virtual void AbilityAfter(BattelLingMons interragsen) { }

    /// is goving to contain type and abilety if we have time
}
