
using UnityEngine;

public class CustumButton : MonoBehaviour
{
    [SerializeField] private TurnHandler turnHandler;

    [SerializeField] private TurnHandler.PlayerActionType _buttonAction;
    [SerializeField] private int _buttonNummber;

    // works as the peramter four the button
    public void CustumActionButton()
    {
        turnHandler.PlayerChosenAction(_buttonAction, _buttonNummber);
    }
}
