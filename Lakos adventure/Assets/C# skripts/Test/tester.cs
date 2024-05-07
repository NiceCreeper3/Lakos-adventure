using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour
{
    private void Awake()
    {
        MYList<tester> my = new MYList<tester>();
        my.field = null;
    }

    private static void GetAttackWinner<TAttack, TDefender>( TAttack attack, TDefender defender)
    {
        //where TAttack : 
    }

    private interface Iattabel { public int Attack(); }
    private interface Idefenable { public int defent(); }

    private class player
    {

    }

    private class MYList<T> where T : class, new()
    {
        public T field;

        public T Func()
        {
            return default;
        }
    }
}
