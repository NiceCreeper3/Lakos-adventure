using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this only serves to be inherted, to make other type of events ezer
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseGameEvent<T> : ScriptableObject
{
    private readonly List<IgameEventListener<T>> eventListeners = new List<IgameEventListener<T>>();

    // triggeres a event
    public void Raise(T item)
    {
        // the for loop goes ind revose to makes sure if one of the events destoyes it self then it does not give a error
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(item);
        }
    }

    public void RegisterListener(IgameEventListener<T> listener)
    {
        // makes sure we don,t add a listener that is allrede registered
        if (!eventListeners.Contains(listener))
        {
            eventListeners.Add(listener);
        }
    }

    public void UnregisterListener(IgameEventListener<T> listener)
    {
        // checkes if the listener is registered. and if so then removes it from beaing registerd
        if (eventListeners.Contains(listener))
        {
            eventListeners.Remove(listener);
        }
    }
}
