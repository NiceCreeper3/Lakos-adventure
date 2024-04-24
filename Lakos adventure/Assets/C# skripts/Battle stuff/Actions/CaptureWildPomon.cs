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

        int playerMaxTeam = 6;

        int chansesToCapture = 3;

        // checkes if we can capture. fist checking if this is a trainer fight (indekated by if there is a trainer sprite), and then checks if we have spase four ned pomon
        if (MapToBattel.IsTranerBattle == null && _playerPomonTeam.team.Count != playerMaxTeam)
        {
            // rolles 3 times to see if the player chaptures the pomon
            for (int i = 0; i <= chansesToCapture; i++)
            {
                int Chapture = Random.Range(_currentCapture.Spesies.CaptureChanse, 101);

                Debug.Log("player rolled " + Chapture + " On Chapture");

                if (Chapture == 100)
                {
                    PomonCaptured();
                    break; // breaks the loop so the player only chaptures the pomon ones
                }
            }
        }
    }

    private static void PomonCaptured()
    {
        Debug.Log("Pomon captured");

        _playerPomonTeam.team.Add(_currentCapture);

        //return to previes
        SceneLoader.ChageScene();
    }
}
