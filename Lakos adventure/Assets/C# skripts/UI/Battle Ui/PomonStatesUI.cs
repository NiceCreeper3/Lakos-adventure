using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PomonStatesUI : MonoBehaviour
{
    [SerializeField] private BattelLingMons _onHealtChange;
    [SerializeField] private SwichePomon _onPomonSwitch;

    [SerializeField] private TMP_Text _currentHeatText;

    private void Awake()
    {
        _onHealtChange.OnHealhtChange += OnHealtChange_OnHealhtChange;
        _onPomonSwitch.OnPomonSwiching += _onPomonSwitch_OnPomonSwiching;
    }

    private void OnHealtChange_OnHealhtChange(int obj)
    {

    }

    private void _onPomonSwitch_OnPomonSwiching(Pomons arg1, bool arg2)
    {

    }

    private void NewSwictedIndLinken()
    {

    }

    private void UpdateHealt()
    {

    }
}
