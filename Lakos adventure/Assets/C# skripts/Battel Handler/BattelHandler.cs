using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BattelHandler : MonoBehaviour
{
    [SerializeField] private BattelLingMons _player, _enemy;
    [SerializeField] private UnityEvent triggerAttacks;


    // mite delethe
    private delegate int firstMove(int i);
    private delegate void lastMove();
    private delegate int MoveOrder(int i);

    private MoveOrder _moveOrder;


    public void Turn(int chosenAttack)
    {
        int playerSpeed = _player.ReturnSpeed();
        int enemySpeed = _enemy.ReturnSpeed();

        int AIAttack = AITurn();

        // gets the damige of both Pomons
        int playerDamige = _player.PomonUseMove(chosenAttack);
        int enemyDamige = _enemy.PomonUseMove(AIAttack);

        // compares the speed of both Pomons. the one with the higst gets to aket fhist
        if (playerSpeed > enemySpeed)
        {
            _enemy.TagesDamige(playerDamige);
            _player.TagesDamige(enemyDamige);
        }
        else if (playerSpeed < enemySpeed)
        {
            _player.TagesDamige(enemyDamige);
            _enemy.TagesDamige(playerDamige);
        }
        else
        {
            // while chose at random ind case of tie
        }
    }

    /// <summary>
    /// makes the AI desice what attack to use
    /// </summary>
    /// <returns></returns>
    private int AITurn()
    {
        int whatAttackToPik = 0;

        // is meant to sent with attack the Ai is goving four
        return whatAttackToPik;
    }
}
