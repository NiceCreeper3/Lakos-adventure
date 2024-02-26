using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    // gets a refrends to the event
    [SerializeField] private SwichePomon OnPomonSwichInd;
    [SerializeField] private BattelLingMons OnPomonDamige;


    private void Awake()
    {
        // gets a subskribs to the event
        OnPomonSwichInd.OnPomonSwiching += OnPomonSwichInd_OnPomonSwiching;
        OnPomonDamige.OnHealhtChange += OnPomonDamige_OnHealhtChange;
    }

    // is triggered when SwichingPomon event is called
    private void OnPomonSwichInd_OnPomonSwiching(Pomons theNewSwichedIndMon, bool isPlayerSwicind)
    {
        throw new System.NotImplementedException();
    }

    // is triggered when Damige is takken event is called
    private void OnPomonDamige_OnHealhtChange(int damigeTakken)
    {
        throw new System.NotImplementedException();
    }



}
