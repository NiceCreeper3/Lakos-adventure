using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwichingButtonGenerature : MonoBehaviour
{

    [SerializeField] private Transform _parent;

    [SerializeField] private pomonteam _playerTeam;
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private ushort _buttonCount;

    [Header("Posisons")]
    [SerializeField] private Vector2 Posistion;
    [SerializeField] private Vector2 _offSetFromPrevies;



    private void OnEnable()
    {
        GenerrateButtons();
    }

    private void GenerrateButtons()
    {
        foreach (Pomons pomon in _playerTeam.team)
        {
            ShowBoxEnty dex = Instantiate(_buttonPrefab, Posistion, Quaternion.identity, _parent).GetComponent<ShowBoxEnty>();
            dex.loadmon(pomon);

            Posistion += _offSetFromPrevies;
        }
    }

}
