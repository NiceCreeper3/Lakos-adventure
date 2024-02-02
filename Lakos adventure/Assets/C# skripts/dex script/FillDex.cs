using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillDex : MonoBehaviour
{
    [SerializeField] private pomonlist allpomon;
    [SerializeField] private GameObject entry;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < allpomon.bluPrint.Length; i++)
        {
            DexEntry dex = Instantiate(entry, transform).GetComponent<DexEntry>();
            dex.bluPrint = allpomon.bluPrint[i];
            dex.id = i + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
