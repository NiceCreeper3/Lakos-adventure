using UnityEngine;

[CreateAssetMenu(fileName = "Moves", menuName = "ScriptableObjeckts/Pomon Moves")]
public class Moves : ScriptableObject
{
    public string MoveName;

    public int power;

    // is goving to be how we add abilletes to moves potentuly
    public delegate void abbilety();



    /// is goving to contain type and abilety if we have time

}
