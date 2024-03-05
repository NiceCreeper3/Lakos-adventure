using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    // gets a refrends to the event
    [SerializeField] private SwichePomon OnPomonSwitchIn;
    [SerializeField] private BattelLingMons OnPomonDamage;


    private void Awake()
    {
        // gets a subskribs to the event
        OnPomonSwitchIn.OnPomonSwiching += OnPomonSwitchIn_OnPomonSwitching;
        OnPomonDamage.OnHealhtChange += OnPomonDamage_OnHealhtChange;
    }

    // is triggered when SwichingPomon event is called
    private void OnPomonSwitchIn_OnPomonSwitching(Pomons theNewSwichedIndMon, bool isPlayerSwicind)
    {
        throw new System.NotImplementedException();
    }

    // is triggered when Damige is takken event is called
    private void OnPomonDamage_OnHealhtChange(int damigeTakken)
    {
        throw new System.NotImplementedException();
    }



}
