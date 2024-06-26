using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new team", menuName = "Pomon/Group/Team")]
public class pomonteam : ScriptableObject
{
    public List<Pomons> team;

    public pomonteam(Pomons[] pomons)
    {
        foreach(Pomons pomon in pomons)
        {
            team.Add(pomon);
        }
    }
}
