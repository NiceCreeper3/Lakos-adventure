using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IgameEventListener<T>
{
    void OnEventRaised(T item);
}
