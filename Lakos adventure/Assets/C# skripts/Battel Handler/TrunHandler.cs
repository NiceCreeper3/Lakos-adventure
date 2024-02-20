using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunHandler : MonoBehaviour
{
    [SerializeField] private BattelLingMons _player, _enemy;
    private int _playerChoseAttack;
    private bool _dovingActionOnTurn = false;

    // makes it so the player can swiche with aot the aponet getting to hit back
    [HideInInspector] public static bool FreeSwiche;


    // player has picked a attack to do
    public void PlayerAttack(int chosenAttack)
    {
        _playerChoseAttack = chosenAttack;
        Turn();
    }

    // both turn on and off
    // makes it so if player is doving a action then that is what there are doving that trun
    public void PlayerAction(bool isActionTurn)
    {
        _dovingActionOnTurn = isActionTurn;
    }

    public void Turn()
    {
        // getes the speed of moboe player and enemy
        int playerSpeed = _player.ReturnSpeed();
        int enemySpeed = _enemy.ReturnSpeed();

        Debug.Log("enemy speed:" + enemySpeed + " Player Speed" + playerSpeed);

        if (_dovingActionOnTurn)
        {
            EnemyTurn();

        }

        // compares the speed of both Pomons. the one with the higst gets to aket fhist
        else if (playerSpeed > enemySpeed)
        {
            // Player does move first
            _player.PomonAttacks(_playerChoseAttack, _enemy);
            EnemyTurn();
        }
        else if (playerSpeed < enemySpeed)
        {
            EnemyTurn();
            _player.PomonAttacks(_playerChoseAttack, _enemy);
        }
        else
        {
            int Chapture = Random.Range(1, 2);

            if(Chapture == 1)
            {
                _player.PomonAttacks(_playerChoseAttack, _enemy);
                EnemyTurn();
            }
            else
            {
                EnemyTurn();
                _player.PomonAttacks(_playerChoseAttack, _enemy);
            }
        }
    }

    public void EnemyTurn()
    {
        // makes the AI pick what move to use
        int AIAttack = AITurn();
        _enemy.PomonAttacks(AIAttack, _player);
    }

    private IEnumerator TurnOrder(BattelLingMons firstTurn, BattelLingMons lastTrun)
    {
        //yield return new WaitUntil
        yield return new WaitForSecondsRealtime(5);
    }

    /// <summary>
    /// makes the AI desice what attack to use
    /// </summary>
    /// <returns></returns>
    private int AITurn()
    {
        int whatAttackToPick = Random.Range(0, 5);
        Debug.Log("ran" + whatAttackToPick);

        // is meant to sent with attack the Ai is goving four
        return whatAttackToPick;
    }
}
