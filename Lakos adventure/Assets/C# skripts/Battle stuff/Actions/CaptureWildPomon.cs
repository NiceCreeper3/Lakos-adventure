using UnityEngine;

public class CaptureWildPomon : MonoBehaviour
{
    [SerializeField] private pomonteam _playerPomonTeam;
    [SerializeField] private pomonteam _theBox;
    [SerializeField] private int playerMaxTeam = 6;

    private static Pomons _currentCapture;

    private Switching OnPomonSwich;

    private void Awake()
    {
        // subscribs to the event
        OnPomonSwich = GetComponent<Switching>();
        OnPomonSwich.OnPomonSwiching += OnPomonSwich_OnPomonSwiching;
    }

    // updates what pomon we are etmting to capture
    private void OnPomonSwich_OnPomonSwiching(Pomons pomonToChapture, bool arg2)
    {
        _currentCapture = pomonToChapture;
    }

    // is called when player clikes on the capture button
    public void CapturePomon()
    {
        Debug.Log($"attemting to capture {_currentCapture}");


        int chansesToCapture = 3;

        // checkes if we can capture. fist checking if this is a trainer fight (indekated by if there is a trainer sprite), and then checks if we have spase four ned pomon
        if (MapToBattel.IsTranerBattle == null)
        {
            // rolles 3 times to see if the player chaptures the pomon
            for (int i = 0; i <= chansesToCapture; i++)
            {
                RollUtilatyes.Chanse(1);

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

    private void PomonCaptured()
    {
        Debug.Log("Pomon captured");

        // if the player allrede has up to his max number of pomones ind his team. then the chaptured Pomon is sent to the box list
        if (_playerPomonTeam.team.Count >= playerMaxTeam)
        {
            _theBox.team.Add(_currentCapture);
        }
        else
        {
            _playerPomonTeam.team.Add(_currentCapture);
        }
        

        //return to previes
        SceneLoader.ChageScene();
    }
}
