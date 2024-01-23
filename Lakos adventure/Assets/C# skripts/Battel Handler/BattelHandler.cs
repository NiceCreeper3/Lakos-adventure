using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattelHandler : MonoBehaviour
{
    [SerializeField] private BattelLingMons _player, _enemy;
    private delegate void fistMove();
    private delegate void _lastMove();


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
            //_fistMove = _player.ReturnAttack();
            //_lastMove = _enemy.ReturnAttack();
        }
        else if (playerSpeed < enemySpeed)
        {

        }

        else
        {

        }

    }

    private void AITurn()
    {

    }
}
