public static class ChangeHealtMoves
{
    public static void ChangeHealtByNummber(BattelLingMons interragsen, int ChangeHealt)
    {
        
        interragsen.ChangeHealt(ChangeHealt);
    }

    /// <summary>
    /// Changes the health of a Pomon based on % amout of there max healt
    /// </summary>
    /// <param name="interragsen"></param>
    /// <param name="healPower"></param>
    public static void ChangeHealtByMaxHealt(BattelLingMons interragsen, double Pressentig)
    {
        // does the mathe before sending it on to the ChangeHealt method
        int ChangeHealt = (int)(interragsen.CurrentMon.MaxHealt * Pressentig);

        interragsen.ChangeHealt(ChangeHealt);
    }

    /// <summary>
    /// Changes health of a pomon based on how muthe healt there are missing
    /// </summary>
    /// <param name="interragsen"></param>
    /// <param name="healPower"></param>
    public static void ChangeHealtByMissingHealt(BattelLingMons interragsen, double Pressentig)
    {
        int ChangeHealt = (int)(interragsen.CurrentMon.MaxHealt * Pressentig);



        interragsen.ChangeHealt(ChangeHealt);
    }
}
