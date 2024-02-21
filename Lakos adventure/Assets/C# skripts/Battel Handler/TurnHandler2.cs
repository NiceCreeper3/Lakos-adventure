using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHandler2 : MonoBehaviour
{
    /// <summary>
    /// Perhapes make it a Enum that deturmens what akkson the player is takking
    /// make enemy tage turn after 
    /// </summary>
    /// 


    public enum PlayerActionType
    {
        Attack,
        Swiching,
        Orb,
        Item
    }


    [SerializeField] private BattelLingMons _player, _enemy;

    [Header("refrends to event")]
    [SerializeField] private SwichePomon OnEnemySwiche;


    private ushort _enemyMoves;
    private ushort _playerAttack, _AiAttack;
    private bool _dovingActionOnTurn = false;

    // makes it so the player can swiche with aot the aponet getting to hit back
    //[HideInInspector] public static bool FreeSwiche;

    private void Awake()
    {
        
    }

    public void PlayerChosenAction(PlayerActionType action)
    {
        switch (action)
        {
            case PlayerActionType.Attack:
                break;

            case PlayerActionType.Swiching:
                break;

            case PlayerActionType.Orb:
                CaptureWildPomon.CapturePomon();
                break;

            case PlayerActionType.Item:
                break;
        }
    }

    private void Turn()
    {

    }

}
