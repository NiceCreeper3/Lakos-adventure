
using UnityEngine;

public class CustumButton : MonoBehaviour
{
    [SerializeField] private TurnHandler2 turnHandler2;

    [SerializeField] private TurnHandler2.PlayerActionType _buttonAction;
    [SerializeField] private int _buttonNummber;


    public void CustumActionButton()
    {
        turnHandler2.PlayerChosenAction(_buttonAction, _buttonNummber);
    }
}
