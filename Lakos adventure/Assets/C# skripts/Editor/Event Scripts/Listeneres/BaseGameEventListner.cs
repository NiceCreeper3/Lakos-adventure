using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// T = type, E = event, UER = unity event reader
public abstract class BaseGameEventListner<T, E, UER> : MonoBehaviour, 
    IgameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
   
{
    [SerializeField] private E _gameEvent;

    public E GameEvent { get { return _gameEvent; } set { _gameEvent = value; } }

    [SerializeField] private UER unityEventResponse;

    // regsterse this listener script when is set aktive 
    private void OnEnable()
    {
        if(_gameEvent == null) { return; }

        _gameEvent.RegisterListener(this);
    }

    // unregsterse this listener script when it is turnt off or deleted
    private void OnDisable()
    {
        if (_gameEvent == null) { return; }

        _gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(T item)
    {
        unityEventResponse?.Invoke(item);
    }
}
