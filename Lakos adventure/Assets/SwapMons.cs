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
        int boxindex = box.team.IndexOf(boxtoswap.pomon);
        box.team.RemoveAt(boxindex);
        box.team.Insert(boxindex,bagtoswap.pomon);
        int bagindex = bag.team.IndexOf(bagtoswap.pomon);
        bag.team.RemoveAt(bagindex);
        bag.team.Insert(boxindex, boxtoswap.pomon);

        baglist.loadmons();
        boxlist.loadmons();
    }

    
}
