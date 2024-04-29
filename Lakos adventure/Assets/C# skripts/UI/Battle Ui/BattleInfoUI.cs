using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleInfoUI : MonoBehaviour
{
    [Header("Images to desplay the look of rhe Pomon")]
    [SerializeField] private Image _playerImage;
    [SerializeField] private Image _enemyImage;

    [Header("Pomons to refedes")]
    [SerializeField] private BattelLingMons _playerMon;
    [SerializeField] private BattelLingMons _enemyPomon;



    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        UpdatePomonImage();
    }

    void UpdatePomonImage()
    {
        _playerImage.sprite = _playerMon.CurrentMon.Spesies.front;
        _enemyImage.sprite = _enemyPomon.CurrentMon.Spesies.front;
    }
}
