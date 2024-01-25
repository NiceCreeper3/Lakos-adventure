using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moves", menuName = "PomonMoves/Buff Attack")]
public class BuffMoves : BasikMoves
{
    public int buffAmount;

    public override void Abilety(BattelLingMons interragsen)
    {
        interragsen._attack += buffAmount;
    }
}
