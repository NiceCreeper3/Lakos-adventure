using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GenateLinkes : MonoBehaviour
{
    // this code is meant to be a rush job and not welldon

    [Header("how to make/change Linkens")] 
    [SerializeField] private PomonsBluPrint _pomonToGenrate;
    [SerializeField] private ushort howMutheToLevel = 1;

    [Header("The linkens genrated")]
    [SerializeField] private Pomons _pomonGenrated;

    [Header("UI Info")]
    [SerializeField] private TMP_Text[] _texts;
    [SerializeField] private Image _linkesImage;

    private MoveLookSetUp moveLook;

    private void Awake()
    {
        moveLook = GetComponent<MoveLookSetUp>();

        GerateFourLook();
    }

    public void GerateFourLook()
    {
        Debug.Log("NEW Genrate");
        _pomonGenrated = _pomonToGenrate.generateMon(1);

        ShowPomonInfo(_pomonGenrated);
    }

    public void InCressLevel()
    {
        int xpToLevel = 0;
        int timesToIncresStates = 0;

        // incres the level of a Pomon
        for (int i = 0; i <= howMutheToLevel; i++)
        {
            xpToLevel = _pomonGenrated.Level.GetExpirenceOntilNextLevel();
            timesToIncresStates += _pomonGenrated.Level.GiveXP(xpToLevel);
        }

        // increses the states
        _pomonGenrated.Level.IncreseStates(_pomonGenrated, timesToIncresStates);

        ShowPomonInfo(_pomonGenrated);
    }

    private void ShowPomonInfo(Pomons pomon)
    {
        _texts[0].text = $"Level: {pomon.Level.GetLevelNumber()}";

        // states
        _texts[1].text = $"Healt: {pomon.MaxHealt}";
        _texts[2].text = $"Attack: {pomon.Attack}";
        _texts[3].text = $"Speed: {pomon.Speed}";
        _texts[4].text = $"Defends: {pomon.Defense}";

        _linkesImage.sprite = pomon.Spesies.front;

        // sets up the attack look
        if (moveLook != null)
            moveLook.CallMoveLook(pomon);
    }
}
