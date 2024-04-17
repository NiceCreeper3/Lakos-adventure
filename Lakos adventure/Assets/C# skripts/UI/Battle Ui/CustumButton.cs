
using UnityEngine;

public class CustumButton : MonoBehaviour
{
    // needs a refends to TurnHandler to attevate the PlayerChose 
    [SerializeField] public TurnHandler TurnHandler;

    // works as the peramter four the button
    [SerializeField] private TurnHandler.PlayerActionType _buttonAction;
    [SerializeField] public int ButtonNummber;

    private void Awake()
    {
        // gets a refrends to TurnHandler if there isent one areede
        if (TurnHandler == null)
            TurnHandler = GetComponent<TurnHandler>();
    }

    // calls PlayerChosen using the "parameters"
    public void CustumActionButton()
    {
        TurnHandler.PlayerChosenAction(_buttonAction, ButtonNummber);
    }
}
