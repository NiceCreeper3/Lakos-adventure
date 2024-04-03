using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyAI
{
    private static ushort _enemyMoves;
    private static ushort _AiAttack;

    private static BattelLingMons _AIPomon, _playerPomon;

    public static void GetRefendses(BattelLingMons AIMon, BattelLingMons playerMon)
    {
        _AIPomon = AIMon;
        _playerPomon = playerMon;
    }

    public static void UpdateEnemyAttackList(Pomons AIPomon)
    {
        // makes sure the script is up to date on how big the pool of attacks the AI pomon is
        _enemyMoves = (ushort)AIPomon.PomonMoves.Count;
    }

    // gets what nummber of attack the AI wants to use. this also triggeres the BeforeBattle Methodes
    public static TurnHandler.TurnAction AITurn()
    {
        // gets a random nummber using _enemyMoves. to get a nummber that indekates what attack the AI wants to use
        ushort whatAttackToPick = (ushort)Random.Range(0, _enemyMoves);
        _AiAttack = whatAttackToPick;

        Debug.Log("AI attack is " + whatAttackToPick);

        _AIPomon.BeforeBattle(whatAttackToPick, _playerPomon);


        // is meant to sent with attack the Ai is goving four. can be expanded latter to also maby try to run or use items
        return EnemyAttack;
    }

    private static void EnemyAttack()
    {
        _AIPomon.PomonAttacks(_AiAttack, _playerPomon);
    }
}
