
using UnityEngine;

public class CustumButton : MonoBehaviour
{
    // needs a refends to TurnHandler to attevate the PlayerChose 
    [SerializeField] private TurnHandler turnHandler;

    // works as the peramter four the button
    [SerializeField] private TurnHandler.PlayerActionType _buttonAction;
    [SerializeField] private int _buttonNummber;

    private void Awake()
    {
        // gets a refrends to TurnHandler if there isent one areede
        if (turnHandler == null)
            turnHandler = GetComponent<TurnHandler>();
    }

    // calls PlayerChosen using the "parameters"
    public void CustumActionButton()
    {
        turnHandler.PlayerChosenAction(_buttonAction, _buttonNummber);
    }
}
