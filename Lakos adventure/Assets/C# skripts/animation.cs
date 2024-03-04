using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class animationinteractor : MonoBehaviour
{
    [SerializeField] private textinteractor handler;
    [SerializeField] private Animator animator;
   // Start is called before the first frame update
   void Start()
    {
        handler.interactor = this;
        animator.runtimeAnimatorController = handler.controller;
    }

    // Update is called once per frame
    public void setcontroller()
    {
        animator.runtimeAnimatorController = handler.controller;
    }
}
