using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleOver : MonoBehaviour
{
    #region structs
    [System.Serializable]
    private struct LinkenBox
    {
        [Header("box")]
        public GameObject Box;
        public Image LinkenImage;

        [Header("Level")]
        public GameObject LevelDot;
        public TMP_Text HowMenyNewLevels;

        public Slider LevelSlider;
    }
    private struct LinkenLevelInfo
    {
        public Sprite LinkenImage;
        public float LeveledUpAmount;
        public float CurrentXP;
        public float XPToNextLevel;

        public LinkenLevelInfo(Sprite linken, float levelAmount, float currentXP, float xpToNextLevel)
        {
            LinkenImage = linken;
            LeveledUpAmount = levelAmount;
            CurrentXP = currentXP;
            XPToNextLevel = xpToNextLevel;
        }
    }
    #endregion

    [Header("Objecks that need to be turnt off or on")]
    [SerializeField] private GameObject _battleOverUI;
    [SerializeField] private GameObject[] _turnOffUI;

    [SerializeField] private LinkenBox[] _linkenBoxes;

    [SerializeField] private XpHandler _OnLinkenLevel;
    [SerializeField] private Switching[] _eventRefends;

    private List<LinkenLevelInfo> _linkenInfo;
    
    private void Awake()
    {
        _linkenInfo = new List<LinkenLevelInfo>();

        _OnLinkenLevel.OnPomonLevel += _OnLinkenLevel_OnPomonLevel;

        foreach (Switching events in _eventRefends)
            events.OnBattleOver += _eventRefends_OnBattleOver;
    }

    private void _OnLinkenLevel_OnPomonLevel(Pomons arg1, ushort arg2)
    {
        SetLevel(arg1, arg2);
    }

    private void _eventRefends_OnBattleOver()
    {
        Debug.Log("end battle was called");
        InsertInfoIntoBoxes();
    }

    private void SetLevel(Pomons pomon, ushort arg2)
    {

        _linkenInfo.Add(new LinkenLevelInfo(pomon.Spesies.front, arg2, pomon.Level, pomon.Expirence));

    }

    private void InsertInfoIntoBoxes()
    {
        foreach (GameObject uiParts in _turnOffUI)
            uiParts.SetActive(false);

        // turns on the battle over ui
        _battleOverUI.SetActive(true);

        // Funds fruge all the LinkesBoxes. and then check if there is a likend to represent
        // if it can then it turns the box on and adds info to show
        // if not then it turns it off
        for (int i = 0; i < _linkenBoxes.Length; i++)
        {
            if (_linkenInfo.Count > i)
            {
                // turns the button on and gives it the move its represending. (if eny are awebol. else it turns it off)               
                _linkenBoxes[i].LinkenImage.sprite = _linkenInfo[i].LinkenImage;

                // shows if new level was gained
                if (_linkenInfo[i].LeveledUpAmount >= 0)
                {
                    _linkenBoxes[i].HowMenyNewLevels.text = $"{_linkenInfo[i].LeveledUpAmount}\n new level";
                }
                else
                {
                    _linkenBoxes[i].LevelDot.SetActive(false);
                }
                
               
                _linkenBoxes[i].LevelSlider.maxValue = _linkenInfo[i].XPToNextLevel;
                _linkenBoxes[i].LevelSlider.value = _linkenInfo[i].CurrentXP;

                Debug.Log($"current xp {_linkenInfo[i].CurrentXP}");

                _linkenBoxes[i].Box.SetActive(true);
            }
            else
            {
                _linkenBoxes[i].Box.SetActive(false);
            }
        }
    }

    public void QuitGame()
    {
        SceneLoader.ChageScene();
    }


}
