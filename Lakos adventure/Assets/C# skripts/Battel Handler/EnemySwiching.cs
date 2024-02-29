using UnityEngine;

public class EnemySwiching : SwichePomon
{
    protected override void Awake()
    {
        _isPlayer = false;

        //____________________________________________________________________________________[Add this after Teasting]____________________________________________
        _pomonTeam = MapToBattel.enemyPomons;

        base.Awake();
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

        // ends the battle with a win. if enemy has no Pomon left
        if (outOfPomon)
            BattelWin();
    }

    protected override void SwichePickMetthod()
    {
        AIPickMon();
    }

}
