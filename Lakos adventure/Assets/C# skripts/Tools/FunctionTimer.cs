using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionTimer
{
    #region classes

    /// <summary>
    /// when pepole are making a FunctionTimer there are tenkaly making this one
    /// </summary>
    /// <param name="action"></param>
    /// <param name="timer"></param>
    /// <param name="timerName"></param>
    /// <returns></returns>
    public static FunctionTimer Create(Action action, float timer, string timerName = null)
    {
        InitIfNeeded();
        // creates a MonoBehaviourHook gameobjects
        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonoBehaviourHook));

        FunctionTimer functionTimer = new FunctionTimer(action, timer, timerName, gameObject) ;

        // hooks on the functionTimers UpdateTime to the MonoBehaviourHooks update
        gameObject.GetComponent<MonoBehaviourHook>().onUpdate = functionTimer.UpdateTime;

        activeTimerList.Add(functionTimer);

        return functionTimer;
    }

    // Dummy class to have access to MonoBehaviour functons
    private class MonoBehaviourHook : MonoBehaviour
    {
        public Action onUpdate;
        private void Update()
        {
            if (onUpdate != null)
                onUpdate();
        }
    }
    #endregion

    private static List<FunctionTimer> activeTimerList;
    private static GameObject _initGameObject;

    private GameObject _gameObject;

    private Action _action;

    private string _timerName;
    private float _timer;
    private bool _isDestroyed;

    #region static methodes
    private static void InitIfNeeded()
    {
        if (_initGameObject == null)
        {
            _initGameObject = new GameObject("FunctionTimer_InitGameObject");
            activeTimerList = new List<FunctionTimer>();
        }
    }

    private static void RemoveTimer(FunctionTimer functionTimer)
    {
        InitIfNeeded();
        activeTimerList.Remove(functionTimer);
    }

    private static void StopTimer(string timerName)
    {
        for (int i = 0; i < activeTimerList.Count; i++)
            if (activeTimerList[i]._timerName == timerName)
            {
                // stopes timer
                activeTimerList[i].DestroySelf();
                i--;
            }
    }
    #endregion

    private FunctionTimer(Action action, float timer, string timerName, GameObject gameObject)
    {
        this._action = action;
        this._timer = timer;
        this._timerName = timerName;
        this._gameObject = gameObject;
        _isDestroyed = false;
    }

    public void UpdateTime()
    {
        if (!_isDestroyed)
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                //trigger the action
                _action();
                DestroySelf();
            }
        }
    }

    private void DestroySelf()
    {
        _isDestroyed = true;
        UnityEngine.Object.Destroy(_gameObject);
    }
}
