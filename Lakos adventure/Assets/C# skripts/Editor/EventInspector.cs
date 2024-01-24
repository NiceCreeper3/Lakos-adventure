using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BaseGameEvent<>))]
public class EventInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        //BaseGameEvent<> baseGameEvent = (BaseGameEvent<>)target;

        if (GUILayout.Button("trigger event"))
        {
           // baseGameEvent.Raise(int = 0);
        }
    }
}
