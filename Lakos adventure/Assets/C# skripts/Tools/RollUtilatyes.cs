using UnityEngine;

public static class RollUtilatyes
{
    /// <summary>
    /// gets a chance and Sees if we hit it or not
    /// </summary>
    /// <param name="chanse">the chanse to hit the desired reasult</param>
    /// <param name="extendRollLengt">ind case you want to lower chanse to the 0.x numberes so fx(5, 1 == 0.5Chanse)</param>
    /// <returns></returns>
    public static bool Chanse(double chanse, float extendRollLengt = 0)
    {
        int RollLengt = 100;

        for (int i = 0; i > extendRollLengt; i++)
        {
            RollLengt = RollLengt * 10;
        }

        RollLengt++; // add the one extra to make up four randoms rules

        #region the roll
        // gets a random nummber
        double roll = Random.Range(1, RollLengt);

        if (chanse >= roll)
        {
            // sempelises that the roll was hit
            return true;
        }

        // sempelises that the roll was missed
        return false;
        #endregion
    }
}
