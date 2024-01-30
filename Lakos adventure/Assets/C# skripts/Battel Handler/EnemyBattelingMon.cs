public class EnemyBattelingMon : BattelLingMons
{
    // is what Pomon the AI Piced
    private Pomons _pomonPiced;

    protected override void SwichePomonLogic()
    {
        AiPicPomon();
        SwitchPomon(_pomonPiced);
    }


    private void AiPicPomon()
    {
        foreach (Pomons pomon in TeastArrey)
        {
            if (pomon.CurrentHealt !<= 0)
            {
                _currentMon = _pomonPiced;
                break;
            }
        }
    }
}
