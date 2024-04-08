using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAnimasons : MonoBehaviour
{
    public struct animasonValues
    {
        public Sprite Fram;
        public float TimeOnTilNextFrame;
    }

    [SerializeField] private SwichePomon _updateAnimason;
    [SerializeField] private BattelLingMons _attackEvent;

    private animasonValues[] _pomonAnimason;

    private void Awake()
    {
        // gets updated off all the Pomons animasons on a swicht event. this is put ind PomonAnimason
        // run animason on event
        _updateAnimason.OnPomonSwiching += _updateAnimason_OnPomonSwiching;
    }

    private void _updateAnimason_OnPomonSwiching(Pomons arg1, bool arg2)
    {
        
        // gets add a array indto the pomons that holds animason frames and pass them on to here
    }

    

    private IEnumerator RunAnimason()
    {
        foreach (animasonValues i in _pomonAnimason)
        {
            // play Fram    like this  gamebojeck.sprite = Fram;
            yield return new WaitForSeconds(i.TimeOnTilNextFrame);
        } 
    }

}
