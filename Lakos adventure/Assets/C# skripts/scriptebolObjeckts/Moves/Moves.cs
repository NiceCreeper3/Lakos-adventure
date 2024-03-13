using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "PomonMoves/Move")]
public class Moves : ScriptableObject
{
    [Header("Flaver")]
    public string MoveName;
    public string MoveDiskrepseon;
    public SoundManger.Sound MoveSound;

    [Header("attack")]
    public int power;
    public ElementObjecks MoveElement;

    public enum AbilityEffects
    {
        ChangeUserHealt,
        BuffTarget,
        DebuffTarget
    }

    [System.Serializable]
    public struct AddAbiltyes
    {
        public AbilityEffects AbilityEffects;
        public bool CallAfterAttack;
        public bool TargetSelf;
    }

    // is only used her so is a priavte
    [Header("Ablityes the move has")]
    public AddAbiltyes[] AddedAbilityes;

    // waht abiltyes 
    private delegate void Ability(BattelLingMons TargetSelf);
    private Ability _beforeTagetSelf, _beforeTagetEnemy, _afterTargetSelf, _afterTagetEnemy;

    // healt change
    #region
    [SerializeField] private int _healPower;

    private void HealtChange(BattelLingMons interragsen)
    {
        ChangeHealtMoves.ChangeHealtCaller(interragsen, _healPower);
    }
    #endregion

    // buff/debuff
    #region
    [Header("Buffing pomon")]
    [SerializeField] private BuffingMoves.BuffInfo[] _getBoffings;

    private void GiveBuffInfo(BattelLingMons interragsen)
    {
        BuffingMoves.Buff(interragsen, _getBoffings);
    }
    #endregion

    // maby move all the ablityes to a difrent spot
    public void AbilityActivated()
    {
        //int nummber = (nummber + 1) % MyArray;

        // rundes fruge all the pikked effects
        foreach (AddAbiltyes ability in AddedAbilityes)
        {
            // checkes what Ability was pikked
            switch (ability.AbilityEffects)
            {
                case AbilityEffects.ChangeUserHealt:                    
                    WhenAndHowToAblity(HealtChange, ability.CallAfterAttack,  ability.TargetSelf);
                    break;

                case AbilityEffects.BuffTarget:
                    WhenAndHowToAblity(GiveBuffInfo, ability.CallAfterAttack, ability.TargetSelf);
                    break;

                case AbilityEffects.DebuffTarget:
                    WhenAndHowToAblity(GiveBuffInfo, ability.CallAfterAttack, ability.TargetSelf);
                    break;
            }
        }
    }

    private void WhenAndHowToAblity(Ability ability, bool goesBefore, bool targetself )
    {
        // checkes if the attack happens before or after 
        if (goesBefore)
        {
            // checkes if this abilty is targeting it self or the enemy 
            if (targetself)
                _afterTargetSelf += ability;
            else
                _afterTagetEnemy += ability;
        }
        else
        {
            if (targetself)
                _beforeTagetSelf += ability;
            else
                _beforeTagetEnemy += ability;
        }
    }

    // when ablitys are called
    #region

    // are methods that represend what ablitys to trigger and at what time
    public void AbilityBeforeTargetSelf(BattelLingMons TargetSelf)
    {
        if (_beforeTagetSelf != null)
            _beforeTagetSelf(TargetSelf);
    }

    public void AbilityAfterTargetSelf(BattelLingMons TargetSelf) 
    {
        if (_afterTargetSelf != null)
            _afterTargetSelf(TargetSelf);
    }

    public void AbilityBeforeTargetEnemy(BattelLingMons TargetEnemy)
    {
        if (_beforeTagetEnemy != null)
            _beforeTagetEnemy(TargetEnemy);
    }

    public void AbilityAfterTargetEnemy(BattelLingMons TargetEnemy)
    {
        if (_afterTagetEnemy != null)
            _afterTagetEnemy(TargetEnemy);
    }
    #endregion
}

