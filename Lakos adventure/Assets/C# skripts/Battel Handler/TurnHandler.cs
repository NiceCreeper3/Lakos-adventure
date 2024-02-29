using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    /// <summary>
    /// Perhapes make it a Enum that deturmens what akkson the player is takking
    /// make enemy tage turn after 
    /// </summary>
    public enum PlayerActionType
    {
        Attack,
        Swiching,
        Orb,
        Run,
        Item
    }

    [SerializeField] private BattelLingMons _player, _enemy;

    [Header("refrends to event")]
    [SerializeField] private SwichePomon _onEnemySwiche;

    public static bool FreeAction;

    private delegate void TurnAction();
    private TurnAction _playerAction, _enemyAction;

    private ushort _enemyMoves;
    private ushort _playerAttack, _AiAttack;

    // makes it so the player can swiche with aot the aponet getting to hit back
    //[HideInInspector] public static bool FreeSwiche;

    private void Awake()
    {
        _onEnemySwiche.OnPomonSwiching += OnEnemySwiche_OnPomonSwiching;
    }

    private void OnEnemySwiche_OnPomonSwiching(Pomons arg1, bool arg2)
    {
        _enemyMoves = (ushort)arg1.PomonMoves.Count;
    }

    // is called by the attack buttons. /tenekly by CustumButton/
    public void PlayerChosenAction(PlayerActionType action, int chosen)
    {
        _playerAttack = 0;

        switch (action)
        {
            case PlayerActionType.Attack:
                // 
                _playerAttack = (ushort)chosen;
                _player.BeforeBattle(_playerAttack);

                _playerAction = Attack;
                break;

            case PlayerActionType.Swiching:
                _playerAction = dullAction; // not 100% sure. maby display text
                break;

            case PlayerActionType.Orb:
                _playerAction = CaptureWildPomon.CapturePomon;
                
                break;

            case PlayerActionType.Run:
                _playerAction = Run.Exskape;
                
                break;

            case PlayerActionType.Item:
                // calls with item we are . or have it display text
                break;
        }

        if (FreeAction != true)
            TurnOrder();
        else
            _playerAction();
    }


    // if it gets more sufiste catted then put ind it onwen script
    private ushort EnemyTurnAI()
    {
        // giver et tall mellem 0 til 3
        ushort whatAttackToPick = (ushort)Random.Range(0, _enemyMoves);
        Debug.Log("random attack " + whatAttackToPick);

        _enemyAction = EnemyAttack;

        // is meant to sent with attack the Ai is goving four
        return whatAttackToPick;
    }

    // inprove so can be used to by player and enemy
    #region attack and i hate it and needs inprovement
    private void Attack()
    {
        //_playerAttack
        _player.PomonAttacks(_playerAttack, _enemy);
    }
    
    private void EnemyAttack()
    {
        _enemy.PomonAttacks(_AiAttack, _player);
    }
    #endregion

    // is meant to indekate the player did somthing else
    private void dullAction() { }


    private void TurnOrder()
    {
        // getes the speed of moboe player and enemy
        int playerSpeed = _player.ReturnSpeed();
        int enemySpeed = _enemy.ReturnSpeed();

        Debug.Log("enemy speed:" + enemySpeed + " Player Speed" + playerSpeed);
        _AiAttack = EnemyTurnAI();


        // compares the speed of both Pomons. the one with the higst gets to aket fhist
        if (playerSpeed > enemySpeed)
        {
            // Player does move first
            StartCoroutine(Turn(_playerAction, _enemyAction));
        }
        else if (playerSpeed < enemySpeed)
        {
            StartCoroutine(Turn(_enemyAction, _playerAction));
        }
        else // picks at random if speed even
        {
            // can be shorten but don,t reamber how
            short Chapture = (short)Random.Range(1, 2);

            if (Chapture == 1)
            {
                StartCoroutine(Turn(_playerAction, _enemyAction));
            }
            else
            {
                StartCoroutine(Turn(_enemyAction, _playerAction));
            }
        }
    }

    // starts the turn. and has a 1 sec delay indbetyvie the to turns
    private IEnumerator Turn(TurnAction fistsOrder, TurnAction sekundOrder)
    {
        fistsOrder();
        yield return new WaitForSecondsRealtime(1); // time four animason to play
        sekundOrder();
    }
}
