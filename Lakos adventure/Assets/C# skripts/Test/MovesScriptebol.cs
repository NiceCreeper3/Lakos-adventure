using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "PomonMoves/Teast")]
public class MovesScriptebol : ScriptableObject
{
    [Header("Flaver")]
    public string MoveName;
    public string MoveDiskrepseon;

    [Header("attack")]
    public int power;
    public ElementObjecks MoveElement;

    private enum AbilityEffects
    {
        ChangeUserHealt,
        BuffTarget,
        DebuffTarget
    }

    [System.Serializable]
    private struct AddAbiltyes
    {
        public AbilityEffects AbilityEffects;
        public bool GoesBeforeTurn;
        public bool TargetSelf;
    }

    // is only used her so is a priavte
    [Header("Ablityes the move has")]
    [SerializeField] private AddAbiltyes[] _abilityes;

    // waht abiltyes 
    private delegate void Ability(BattelLingMons TargetSelf);
    private Ability _beforeTagetSelf, _beforeTagetEnemy, _afterTargetSelf, _afterTagetEnemy;

    // healt change
    #region
    public int healPower;

    private void HealtChange(BattelLingMons interragsen)
    {
        interragsen.ChangeHealt(healPower);
    }
    #endregion

    // buff/debuff
    #region
    [Header("Buffing pomon")]
    [SerializeField] private Buffing.BuffInfo[] _getBoffings;

    private void GiveBuffInfo(BattelLingMons interragsen)
    {
        Buffing.Buff(interragsen, _getBoffings);
    }
    #endregion

    // maby move all the ablityes to a difrent spot
    public void AbilbyAtevated()
    {
        // rundes fruge all the pikked effects
        foreach (AddAbiltyes ability in _abilityes)
        {
            // checkes what Ability was pikked
            switch (ability.AbilityEffects)
            {
                case AbilityEffects.ChangeUserHealt:                    
                    WhenAndHowToAblity(HealtChange, ability.GoesBeforeTurn,  ability.TargetSelf);
                    break;

                case AbilityEffects.BuffTarget:
                    WhenAndHowToAblity(GiveBuffInfo, ability.GoesBeforeTurn, ability.TargetSelf);
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
                _beforeTagetSelf += ability;
            else
                _beforeTagetEnemy += ability;
        }
        else
        {
            if (targetself)
                _afterTargetSelf += ability;
            else
                _afterTagetEnemy += ability;
        }
    }

    // when ablitys are called
    #region

    // are methods that represend what ablitys to trigger and at what time
    public void AbilityBeforeTargetSelf(BattelLingMons TargetSelf)
    {
        _beforeTagetSelf(TargetSelf);
    }

    public void AbilityAfterTargetSelf(BattelLingMons TargetSelf) 
    {
        _afterTargetSelf(TargetSelf);
    }

    public void AbilityBeforeTargetEnemy(BattelLingMons TargetEnemy)
    {
        _beforeTagetEnemy(TargetEnemy);
    }

    public void AbilityAfterTargetEnemy(BattelLingMons TargetEnemy)
    {
        _afterTagetEnemy(TargetEnemy);
    }
    #endregion
}

