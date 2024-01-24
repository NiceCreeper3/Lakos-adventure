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


    // Start is called before the first frame update
    void Start()
    {

    }


    private void Turn()
    {

    }

    private void SpawnPomons()
    {
                                                                        
    }

    private void AttackOrder()
    {
        int playerSpeed = _player.ReturnSpeed();
        int enemySpeed = _enemy.ReturnSpeed();
        if (playerSpeed > enemySpeed)
        {
            // mabye use a lambda epression to order them
            _moveOrder += _player.ReturnAttack;
            //_fistMove = 
            //_lastMove = _enemy.ReturnAttack(1);
        }
        else if (playerSpeed < enemySpeed)
        {

        }

        else
        {

        }

        //_moveOrder = 

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
