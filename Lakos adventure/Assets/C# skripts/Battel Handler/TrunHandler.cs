using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrunHandler : MonoBehaviour
{
    [SerializeField] private BattelLingMons _player, _enemy;
    [SerializeField] private UnityEvent triggerAttacks;

    // _________________________________________________(rewrite this)________________________________________________


    public void PlayerAction(int chosenAttack)
    {

    }

    public void BeatterTurn()
    {

    }

    // use new method
    public void Turn(int chosenAttack)
    {
        int playerSpeed = _player.ReturnSpeed();
        int enemySpeed = _enemy.ReturnSpeed();

        int AIAttack = AITurn();

        // gets the damige of both Pomons
        int playerDamage = _player.PomonUseMove(chosenAttack);
        int enemyDamage = _enemy.PomonUseMove(AIAttack);

        // compares the speed of both Pomons. the one with the higst gets to aket fhist
        if (playerSpeed > enemySpeed)
        {
            _enemy.TakesDamage(playerDamage);
            _player.TakesDamage(enemyDamage);
        }
        else if (playerSpeed < enemySpeed)
        {
            _player.TakesDamage(enemyDamage);
            _enemy.TakesDamage(playerDamage);
        }
        else
        {
            // while chose at random in case of tie
        }
    }

    /// <summary>
    /// makes the AI desice what attack to use
    /// </summary>
    /// <returns></returns>
    private int AITurn()
    {
        int whatAttackToPick = 0;

        // is meant to sent with attack the Ai is goving four
        return whatAttackToPick;
    }
}
