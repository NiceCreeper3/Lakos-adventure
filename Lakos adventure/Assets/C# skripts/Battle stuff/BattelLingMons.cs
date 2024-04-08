using System;
using UnityEngine;

public class BattelLingMons : MonoBehaviour
{
    public enum Buffs
    {
        AttackBuff,
        SpeedBuff,
        DefenseBuff       
    }

    // Values
    #region

    [Header("Checks if swiching pomon needs player logic or AI logic")]
    [SerializeField] private bool _isPlayerMon;

    [Header("Reference to aesthetic stuff")]
    [SerializeField] private SpriteRenderer pomonImgeDissplay; // mite move after 

    [Header("Text box")]
    [SerializeField] private textinteractor _textBox;

    [HideInInspector] public Pomons CurrentMon;
    private SwichePomon OnSwitch;

    // represents buffs
    private DamageMath.StatsBuff _buffs;

    // evnets
    public event Action<int> OnHealhtChange;
    public event Action OnPomonSwicheNeeded;

    
    #endregion

    // Start is called before the first frame update
    private void Awake()
    {
        // gets refrends to swichePomon
        OnSwitch = GetComponent<SwichePomon>();

        // gets a refrends to Pomon swiching
        OnSwitch.OnPomonSwiching += OnSwiche_OnPomonSwiching;
    }

    private void OnSwiche_OnPomonSwiching(Pomons arg1, bool arg2)
    {
        SwitchPomon(arg1, arg2);
    }

    // methods
    #region

    public int ReturnSpeed()
    {
        return (int)(CurrentMon.Speed * _buffs.SpeedBuff);
    }

    // triggeres chosen attacks BeforeAblity
    public void BeforeBattle(int attackPicked, BattelLingMons aponent)
    {
        CurrentMon.PomonMoves[attackPicked].AbilityBeforeTargetSelf(this);
        CurrentMon.PomonMoves[attackPicked].AbilityBeforeTargetEnemy(aponent);
    }

    // adds stats "stabs". aka buffs
    public void StatesBuff(double buffTimes, Buffs whatToBuff)
    {
        // the max amount of times we can buff
        short maxBuffAmount = 2;

        switch (whatToBuff)
        {
            case Buffs.AttackBuff:
                _buffs.AttackBuff += buffTimes;
                break;

            case Buffs.SpeedBuff:
                _buffs.SpeedBuff += buffTimes;
                break;

            case Buffs.DefenseBuff:
                _buffs.DefenseBuff += buffTimes;
                break;
        }

        // make it beater latter
        // adds a buff cap. so you can only have buffed [maxBuffTimes]. the + 2 is to acount four the buffes starting at 1
        if (maxBuffAmount <_buffs.AttackBuff)
            _buffs.AttackBuff = maxBuffAmount;
        if (maxBuffAmount < _buffs.SpeedBuff)
            _buffs.SpeedBuff = maxBuffAmount;
        if (maxBuffAmount < _buffs.DefenseBuff)
            _buffs.DefenseBuff = maxBuffAmount;

        Debug.Log($"has buffed/debuffed {CurrentMon.PomonName}s {whatToBuff} by {buffTimes}");
    }

    // calkulates damige and and  sends it to the (attckTarget)
    public void PomonAttacks(int attackPicked, BattelLingMons attckTarget)
    {
        int damage = 0;
        Moves move = null;

        // checkes if the Pomon is stil alive 
        if (CurrentMon.CurrentHealt > 0)
        {
            // makes a short refrens to the Move
            move = CurrentMon.PomonMoves[attackPicked];

            Debug.Log(
                $"_______________{CurrentMon.PomonName}_______________\n" +
                $"___________used {move.MoveName}_______________ ");

            // actevates the Ability after the Damage math as to not give buff damige amidetly
            move.AbilityAfterTargetSelf(this);
            move.AbilityAfterTargetEnemy(attckTarget);

            // ind case the move has not attack power. the move is not meant to do damage and there four this does not make eny damage math
            if (move.power != 0)
            {
                damage = DamageMath.AttackMath(move, CurrentMon, attckTarget.CurrentMon, _buffs);
                damage = DamageMath.DefenderMath(attckTarget.CurrentMon, damage, attckTarget._buffs);

                // thanges the healt of the enemy pomon
                attckTarget.ChangeHealt(-damage);
            }

            // writes what move the enemy used as well as a short deskripson of what it does
            if (!_isPlayerMon)
                _textBox.RunTextBox($" ({CurrentMon.PomonName} used {move.MoveName}) \n {move.MoveDiskrepseon}");

            Debug.Log("_______________[end of attack]_______________");
        }
        else
        {
            Debug.Log("you dumb boy? this Pomon has fainted");
        }
    }

    // health maipulason
    #region

    //make changes ind the helt of the pomon. this can be healing or damage
    public void ChangeHealt(int howToChange)
    {
        CurrentMon.CurrentHealt += howToChange;

        // makes sure a pomon does not have more health then MaxHealth
        if (CurrentMon.CurrentHealt > CurrentMon.MaxHealt) // makes sure the Pomon does not get more HP then Max
            CurrentMon.CurrentHealt = CurrentMon.MaxHealt;

        Debug.Log($"{CurrentMon.PomonName} has had its health changed by {howToChange} and is now at {CurrentMon.CurrentHealt}/{CurrentMon.MaxHealt}");

        OnHealhtChange?.Invoke(howToChange);

        // checks if the pomon has negetive healt. if so then its considered dead.
        // and its hp is put to 0 as it is nicer to look at
        if (CurrentMon.CurrentHealt <= 0)
        {
            CurrentMon.CurrentHealt = 0;
            TurnHandler.FreeAction = true;
            OnPomonSwicheNeeded?.Invoke();
        }
    }
    #endregion


    // is goving to handel swithing ind a new pokemon
    private void SwitchPomon(Pomons swichingPomons, bool isPlayerMon)
    {
        if (CurrentMon != null)
            Debug.Log($"swichint {CurrentMon.PomonName} out with {swichingPomons.PomonName}");

        // playes a audio clip
        SoundManger.Playsound(SoundManger.Sound.OnPomonEnterBattel);

        // sets the new _currentMon Pomon to be the swithed ind one
        CurrentMon = swichingPomons;

        // sets buff amount
        _buffs = new DamageMath.StatsBuff(1,1,1);

        foreach (Moves moves in swichingPomons.PomonMoves)
            moves.AbilityActivated();
            

        // insertes the sprite ind its plase. and if its the player mekes sure it is the back sprite 
        if (isPlayerMon)
            pomonImgeDissplay.sprite = CurrentMon.Spesies.back;
        else
            pomonImgeDissplay.sprite = CurrentMon.Spesies.front;
    }
    #endregion
}
