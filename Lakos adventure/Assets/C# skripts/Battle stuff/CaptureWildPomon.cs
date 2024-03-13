using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureWildPomon : MonoBehaviour
{
    [SerializeField] private static pomonteam _playerPomonTeam;

    private static Pomons _currentCapture;

    private SwichePomon OnPomonSwich;

    private void Awake()
    {
        // subscribs to the event
        OnPomonSwich = GetComponent<SwichePomon>();

        OnPomonSwich.OnPomonSwiching += OnPomonSwich_OnPomonSwiching;
    }

    public static void SetplayerTeam(pomonteam pomonteam)
    {
        _playerPomonTeam = pomonteam;
    }

    // updates what pomon we are etmting to capture
    private void OnPomonSwich_OnPomonSwiching(Pomons pomonToChapture, bool arg2)
    {
        _currentCapture = pomonToChapture;
    }

    // is called when player clikes on the capture button
    public static void CapturePomon()
    {
        Debug.Log($"attemting to capture {_currentCapture}");

        int chansesToCapture = 3;

        // attempts to chapture. as long as this is not a trainer battle indekated by where or not there is a trainer sprite
        if (MapToBattel.IsTranerBattle != null)
        {
            // rolles 3 times randomly to see if pomon got chapured
            for (int i = 0; i <= chansesToCapture; i++)
            {
                int Chapture = Random.Range(_currentCapture.Spesies.CaptureChanse, 101);

                Debug.Log("player rolled " + Chapture + " On Chapture");

                if (Chapture == 100)
                {
                    PomonCaptured();
                }
            }
        }
    }

    private static void PomonCaptured()
    {
        _playerPomonTeam.team.Add(_currentCapture);

        //return to previes
        SceneLoader.ChageScene();
    }
}
