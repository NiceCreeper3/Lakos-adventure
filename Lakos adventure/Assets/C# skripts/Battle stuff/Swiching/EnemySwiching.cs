using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwiching : Switching
{
    protected override void Awake()
    {
        _isPlayer = false;

        // adds the info from map if there has not bean given a team
        if (_pomonTeam == null)
            _pomonTeam = MapToBattel.enemyPomons;

        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        AIPickMon();
    }

    public void AIPickMon()
    {
        // sets it so we asume there have run out of pomon. but if one is found then it sets this to false
        bool outOfPomon = true;

        // funds fruge the pomonTeam list one by one and if eny have more then 0 HP. it stopes the loop and saves the nummber ind _seletedPomon
        for (int i = 0; i < _pomonTeam.team.Count; i++)
        {
            if (_pomonTeam.team[i].CurrentHealt > 0)
            {
                _seletedPomon = i;
                outOfPomon = false;
                SwitchPomonConfurmt();
                break;
            }
        }

        if (outOfPomon)
            EndBattle((ushort)_pomonTeam.team.Count);
    }

    protected override void SwichePickMetthod()
    {
        AIPickMon();
    }

}
