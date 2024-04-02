using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showtypes : MonoBehaviour
{
    [SerializeField] private List<GameObject> currenttypes = null;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject typedisplay;

    // Start is called before the first frame update
    public void loadtypes(ElementObjecks[] elements)
    {
        clear();
        for(int i = 0; i < elements.Length; i++)
        {
            ElementDisplay dex = Instantiate(typedisplay, content).GetComponent<ElementDisplay>();
            currenttypes.Add(dex.gameObject);
            dex.loadtype(elements[i]);

        }
    }

    private void clear()
    {
        if (currenttypes.Count != 0)
        {
            
            for (int i = 0; i < currenttypes.Count   ; i++)
            {
                if (currenttypes[i])
                {
                    Destroy(currenttypes[i]);
                }
                
                
            }
        }
        currenttypes.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
