using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunHandler : MonoBehaviour
{
    [SerializeField] private BattelLingMons _player, _enemy;

    [Header("refrends to event")]
    [SerializeField] private SwichePomon OnEnemySwiche;


    private ushort _enemyMoves; 
    private ushort _playerAttack, _AiAttack;
    private bool _dovingActionOnTurn = false;

    // makes it so the player can swiche with aot the aponet getting to hit back
    [HideInInspector] public static bool FreeSwiche;

    private void Awake()
    {
        OnEnemySwiche.OnPomonSwiching += OnEnemySwiche_OnPomonSwiching;
    }

    private void OnEnemySwiche_OnPomonSwiching(Pomons arg1, bool arg2)
    {
        _enemyMoves = (ushort)arg1.PomonMoves.Count; 
    }


    // player has picked a attack to do
    public void PlayerAttack(int chosenAttack)
    {
        _playerAttack = (ushort)chosenAttack;
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
            _player.PomonAttacks(_playerAttack, _enemy);
            EnemyTurn();
        }
        else if (playerSpeed < enemySpeed)
        {
            EnemyTurn();
            _player.PomonAttacks(_playerAttack, _enemy);
        }
        else
        {
            int Chapture = Random.Range(1, 2);

            if(Chapture == 1)
            {
                _player.PomonAttacks(_playerAttack, _enemy);
                EnemyTurn();
            }
            else
            {
                EnemyTurn();
                _player.PomonAttacks(_playerAttack, _enemy);
            }
        }
    }

    public void EnemyTurn()
    {
        // makes the AI pick what move to use
        AITurn();
        _enemy.PomonAttacks(_AiAttack, _player);
    }

    private IEnumerator TurnOrder(BattelLingMons firstTurn, BattelLingMons lastTrun)
    {

        yield return new WaitForSecondsRealtime(1);
        

        // insert battel is over 
        while (true)
        {
            

            //if ()

            //yield return new WaitUntil();
        }

        //yield return new WaitUntil
        yield return new WaitForSecondsRealtime(5);
    }

    /// <summary>
    /// makes the AI desice what attack to use
    /// </summary>
    /// <returns></returns>
    private void AITurn()
    {
        // giver et tall mellem 0 til 3
        int whatAttackToPick = Random.Range(0, _enemyMoves);
        Debug.Log("random attack " + whatAttackToPick);

        // is meant to sent with attack the Ai is goving four
        _AiAttack = (ushort)whatAttackToPick;
    }
}
