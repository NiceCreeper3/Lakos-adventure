using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBuffUI : MonoBehaviour
{
    [SerializeField] private BattelLingMons _pomonToShow;

    [Header("gets the refends to the dots")]
    [SerializeField] private GameObject _attackBuffdots;
    [SerializeField] private GameObject _defendsBuffdots;
    [SerializeField] private GameObject _speedBuffdots;

    private List<Image> _attackDots;
    private List<Image> _defendsDots;
    private List<Image> _speedDots;

    private void Awake()
    {
        // indststansiats the lists
        _attackDots = new List<Image>();
        _defendsDots = new List<Image>();
        _speedDots = new List<Image>();

        // filles the lists withe the needede dots
        foreach (Transform dots in _attackBuffdots.transform)
            _attackDots.Add(dots.GetComponent<Image>());

        foreach (Transform dots in _defendsBuffdots.transform)
            _defendsDots.Add(dots.GetComponent<Image>());

        foreach (Transform dots in _speedBuffdots.transform)
            _speedDots.Add(dots.GetComponent<Image>());

        _pomonToShow.OnPomonBuff += _pomonToShow_OnPomonBuff;

        // colores ind all the dots to be black by defalt
        SetUpBuffDots(new StatesBuff.StatsBuffs(0,0,0));
    }

    private void _pomonToShow_OnPomonBuff(StatesBuff.StatsBuffs CurrentBuff)
    {
        Debug.Log($"the updated wereson was callede");

        // calles to set up the dots
        SetUpBuffDots(CurrentBuff);
    }

    private void SetUpBuffDots(StatesBuff.StatsBuffs CurrentBuff)
    {
        Debug.Log($"___________________[At:{CurrentBuff.AttackBuff} Defe:{CurrentBuff.DefenseBuff} Speed:{CurrentBuff.SpeedBuff}]___________________");

        // sets all the dots four ethe state
        Setdots(_attackDots, CurrentBuff.AttackBuff);
        Setdots(_defendsDots, CurrentBuff.DefenseBuff);
        Setdots(_speedDots, CurrentBuff.SpeedBuff);
    }

    /// <summary>
    /// filles ind the dots. based on where or not its buffed of debuffed
    /// </summary>
    /// <param name="images"></param>
    /// <param name="buff"></param>
    private void Setdots(List<Image> images, double buff)
    {
        // dis uses the buff value to check if the state is buffed/debuffed. and if so will color ind a dot and take buff down by one state.
        // it reapetes this ontil it ithere has 0 ind buff. and can then color the reast black.
        // or has colored all the dots

        // devides to so that ethe dot has the ame amout
        double o = StatesBuff.maxBuffAmount / images.Count;

        // fundes fruge all the dots. and depending apon if we are buffed/debuffed. we will color ind the dots
        // Red four Debuff. Yellow four Buff. and black four nither
        for (int i = 0; i < images.Count; i++)
        {
            // ind case there is no more 
            if (buff == 0)
            {
                images[i].color = Color.black;
            }
            else if (buff >= o)
            {
                // tages the buff value down by one stage
                buff -= o;
                images[i].color = Color.yellow;
            }
            else if (buff <= o)
            {
                buff += o;
                images[i].color = Color.red;
            }


        }
    }
}
