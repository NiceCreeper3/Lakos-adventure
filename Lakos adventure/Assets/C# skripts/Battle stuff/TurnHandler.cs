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

    public delegate void TurnAction();
    private TurnAction _playerAction, _enemyAction;


    private ushort _playerAttack;

    [SerializeField] private GameObject[] _makeInvesbolDurringAttack;
    [SerializeField] private GameObject[] _makevisubolDurring;

    // makes it so the player can swiche with aot the aponet getting to hit back
    //[HideInInspector] public static bool FreeSwiche;

    private void Awake()
    {
        // gives the neede refrendses to the Ai script
        EnemyAI.GetRefendses(_enemy, _player);
        _onEnemySwiche.OnPomonSwiching += OnEnemySwiche_OnPomonSwiching;
    }

    private void OnEnemySwiche_OnPomonSwiching(Pomons AIPomon, bool arg2)
    {
        EnemyAI.UpdateEnemyAttackList(AIPomon);
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
                _player.BeforeBattle(_playerAttack, _enemy);

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
        {
            _playerAction();
            FreeAction = false;
        }
            
    }



    // inprove so can be used to by player and enemy
    #region attack and i hate it and needs inprovement
    private void Attack()
    {
        //_playerAttack
        _player.PomonAttacks(_playerAttack, _enemy);
    }
    

    #endregion

    // is meant to indekate the player did somthing else
    private void dullAction() { }


    private void TurnOrder()
    {
        // getes the speed of moboe player and enemy
        int playerSpeed = _player.ReturnSpeed();
        int enemySpeed = _enemy.ReturnSpeed();
        
        Debug.Log(
            "enemy speed:" + enemySpeed + 
            "\n          Player Speed" + playerSpeed);
        //_AiAttack = AITurn();
        _enemyAction = EnemyAI.AITurn();

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
    private IEnumerator Turn(TurnAction fistsOrder, TurnAction secundOrder)
    {
        foreach (GameObject makeInvesebol in _makeInvesbolDurringAttack)
            makeInvesebol.SetActive(false);
        /*
                foreach (GameObject visubol in _makevisubolDurring)
                    visubol.SetActive(true);*/

        Debug.Log($"attacks the fist:{fistsOrder} Secound:{secundOrder}");

        fistsOrder();
        yield return new WaitForSecondsRealtime(1); // time four animason to play
        secundOrder();

        foreach (GameObject makeInvesebol in _makeInvesbolDurringAttack)
            makeInvesebol.SetActive(true);
/*
        foreach (GameObject visubol in _makevisubolDurring)
            visubol.SetActive(false);*/
    }
}