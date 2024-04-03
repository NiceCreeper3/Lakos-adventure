using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapMons : MonoBehaviour
{
    [SerializeField] private ListCaughtMon boxlist;
    [SerializeField] private ListCaughtMon baglist;
    [SerializeField] private pomonteam box;
    [SerializeField] private pomonteam bag;
    [SerializeField] private DisplayCaughtPomon bagtoswap;
    [SerializeField] private DisplayCaughtPomon boxtoswap;
    // Start is called before the first frame update
    public void swappomons()
    {
        Pomons bagmon = bagtoswap.pomon;
        Pomons boxmon = boxtoswap.pomon;
        if (bagmon && boxmon)
        {
            int boxindex = box.team.IndexOf(boxtoswap.pomon);
            box.team.Insert(boxindex, bagtoswap.pomon);
            box.team.RemoveAt(boxindex + 1);

            int bagindex = bag.team.IndexOf(bagtoswap.pomon);
            bag.team.Insert(bagindex, boxtoswap.pomon);
            bag.team.RemoveAt(bagindex + 1);


            baglist.loadmons();
            boxlist.loadmons();
        }
        
    }

    private void Start()
    {
        while (bag.team.Count < 6)
        {
            if (box.team.Count > 0)
            {
                bag.team.Add(box.team[0]);
                box.team.RemoveAt(0);
            }
            else
            {
                break;
            }
        }
        baglist.loadmons();
        boxlist.loadmons();
    }


}
