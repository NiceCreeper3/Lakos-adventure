using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LinkenStatesUI : MonoBehaviour
{
    [SerializeField] private BattelLingMons _onLinkenDamage;
    [SerializeField] private Switching _onLinkenSwicht;

    [SerializeField] private TMP_Text _linkenHealt;
    [SerializeField] private TMP_Text _linkenLevel;

    private Pomons _current;

    // Start is called before the first frame update
    private void Awake()
    {
        _onLinkenDamage.OnHealhtChange += _onLinkenDamage_OnHealhtChange;
        _onLinkenSwicht.OnPomonSwiching += _onLinkenSwicht_OnPomonSwiching;
    }

    private void _onLinkenDamage_OnHealhtChange(int obj)
    {
        ChangeHealt();
    }

    private void _onLinkenSwicht_OnPomonSwiching(Pomons pomon, bool arg2)
    {
        ShowLinkenStates(pomon);
    }

    private void ChangeHealt()
    {
        _linkenHealt.text = $"{_current.CurrentHealt}";
    }

    private void ShowLinkenStates(Pomons pomon)
    {
        _current = pomon;

        ChangeHealt();
        _linkenLevel.text = $"{_current.Level}";
    }
}