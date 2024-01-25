using UnityEngine;

[CreateAssetMenu(fileName = "Moves", menuName = "ScriptableObjeckts/Pomon Moves")]
public class BasikMoves : ScriptableObject
{
    public string MoveName;

    public int power;

    // 
    public virtual void Abilety(Pomons target) { }

    /// is goving to contain type and abilety if we have time
}
