using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListCaughtMon : MonoBehaviour
{
    [SerializeField] private DisplayCaughtPomon displayCaught;
    [SerializeField] private pomonteam allpomon;
    [SerializeField] private GameObject entry;

    private List<GameObject> currententries = new List<GameObject>();

    public void loadmons()
    {
        if (currententries.Count > 0)
        {
            foreach (GameObject entry in currententries)
            {
                Destroy(entry);
            }
        }

        displayCaught.loadmon(allpomon.team[0]);
        for (int i = 0; i < allpomon.team.Count; i++)
        {
            ShowBoxEnty dex = Instantiate(entry, transform).GetComponent<ShowBoxEnty>();
            dex.loadmon(allpomon.team[i]);
            dex.displayCaught = displayCaught;
            currententries.Add(dex.gameObject);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        loadmons();
    }


}
