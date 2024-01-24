using UnityEngine;

[CreateAssetMenu(fileName = "Void Event", menuName = "Game Events/Void Event")]
public class VoidEvent : BaseGameEvent<VoidValue>
{
    public void Raise() => Raise(new VoidValue());
}
