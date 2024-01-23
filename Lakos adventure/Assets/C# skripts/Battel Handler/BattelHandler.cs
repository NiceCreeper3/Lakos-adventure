using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattelHandler : MonoBehaviour
{
    [SerializeField] private BattelLingMons player, enemy;



    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void SpawnPomons()
    {
                                                                        
    }

    private void AttackPomon()
    {
        int dam = player.ReturnAttack(0);
        enemy.TagesDamige(dam);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("3"))
        {
            AttackPomon();
        }
    }
}
