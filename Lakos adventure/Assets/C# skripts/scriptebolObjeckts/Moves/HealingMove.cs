using UnityEngine;

[CreateAssetMenu(fileName = "Moves", menuName = "PomonMoves/Healing self")]
public class Healing : BasikMoves1
{
    public int healPower;

    public override void AbilityBefore(BattelLingMons interragsen)
    {
        interragsen.ChangeHealt(healPower);
    }
}
