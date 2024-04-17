using UnityEngine;

public static class AnimasonRunner
{
    [System.Serializable]
    public struct animasonValues
    {
        public Sprite Fram;
        public float TimeOnTilNextFrame;
    }

    public static void RunAnimason(SpriteRenderer toAnimateObject, Animasons animason)
    {
        foreach (animasonValues i in animason.AnimasonFrames)
        {
            FunctionTimer.Create(() => toAnimateObject.sprite = i.Fram, i.TimeOnTilNextFrame);
        } 
    }
}
