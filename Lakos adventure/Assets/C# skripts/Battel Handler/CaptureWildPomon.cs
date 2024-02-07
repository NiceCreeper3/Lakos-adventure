using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureWildPomon : MonoBehaviour
{


    [SerializeField] private bool _trainerBattel = false;

    public static List<Pomons> PomonTeamList = new List<Pomons>();

    private Pomons _currentCapture;


    private SwichePomon OnPomonSwich;

    private void Awake()
    {
        OnPomonSwich = GetComponent<SwichePomon>();

        OnPomonSwich.OnPomonSwiching += OnPomonSwich_OnPomonSwiching;
    }

    private void OnPomonSwich_OnPomonSwiching(Pomons arg1, bool arg2)
    {
        _currentCapture = arg1;
    }



    // maby Move this to its oven script
    public void CapturePomon()
    {
        int chansesToCapture = 3;

        if (!_trainerBattel)
        {
            for (int i = 0; i <= chansesToCapture; i++)
            {
                int Chapture = Random.Range(_currentCapture.Spesies.CaptureChanse, 100);

                Debug.Log("player rolled " + Chapture + " On Chapture");

                if (Chapture == 99)
                {
                    PomonCaptured();
                }
            }
        }
    }

    private void PomonCaptured()
    {
        PomonTeamList.Add(_currentCapture);
        Debug.Log(PomonTeamList);


        SceneManger.ChageScene("outdoors"); // __________________________[Reaplase with the return to previes]_______________________________________
    }
}
