using UnityEngine;

public class EnemySwiching : SwichePomon
{
    protected override void Awake()
    {
        //_pomonTeam = MapToBattel.enemyPomons;
        base.Awake();
    }

    public void AIPickMon()
    {
        for (int i = 0; i < _pomonTeam.team.Count; i++)
        {
            Debug.Log("RRRRRRRRRR");
            if (_pomonTeam.team[i].CurrentHealt > 0)
            {
                _seletedPomon = i;
                //SwitchPomonConfurmt();
                break;
            }
        }

        // calles if 
    }

    protected override void SwichePickMetthod()
    {
        AIPickMon();
    }

}
