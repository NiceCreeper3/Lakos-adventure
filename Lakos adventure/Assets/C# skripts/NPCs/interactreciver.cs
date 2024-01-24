using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interactreciver : MonoBehaviour
{
    [SerializeField] private UnityEvent ontrigger;
    // Start is called before the first frame update
    public void Trigger()
    {
        ontrigger.Invoke();

    }
}
