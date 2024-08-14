using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivePlayerTeam : MonoBehaviour
{
    [SerializeField] private pomonteam _PlayerTeamIndUse;

    public event Action<pomonteam> GiveTeamIndUse;
    
    private void Awake()
    {
        GiveTeamIndUse?.Invoke(_PlayerTeamIndUse);
    }
}
