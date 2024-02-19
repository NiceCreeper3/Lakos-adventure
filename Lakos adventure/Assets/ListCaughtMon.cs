using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCaughtMon : MonoBehaviour
{
    [SerializeField] private DisplayCaughtPomon displayCaught;
    [SerializeField] private pomonteam allpomon;
    [SerializeField] private GameObject entry;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < allpomon.team.Count; i++)
        {
            ShowBoxEnty dex = Instantiate(entry, transform).GetComponent<ShowBoxEnty>();
            dex.pomon = allpomon.team[i];
            dex.displayCaught = displayCaught;
        }
    }


}
