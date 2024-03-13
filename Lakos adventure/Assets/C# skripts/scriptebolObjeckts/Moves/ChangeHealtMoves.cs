using UnityEngine;

public static class ChangeHealtMoves
{
    public static void ChangeHealtCaller(BattelLingMons interragsen, int healPower)
    {
        Debug.Log("change healt");
        interragsen.ChangeHealt(healPower);
    }
}
