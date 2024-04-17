using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[CreateAssetMenu(fileName = "textbox indecator", menuName = "textindecator")]
public class textinteractor: ScriptableObject
{
    public TypeWriterEffect textboxinsceene;
    public GameObject box;

    public RuntimeAnimatorController controller;
    public animationinteractor interactor;
    public pomonteam wild;

    public void RunTextBox(string text)
    {
        if (interactor)
        {
            box.SetActive(true);
            textboxinsceene.CallUpdateFullText(text);
        }
    }


    public void changeanim(RuntimeAnimatorController animator)
    {
        controller = animator;
        interactor.setcontroller();
    }
    public void changeanim()
    {
        controller = null;
        interactor.setcontroller();
    }
    public Actorscript Generateactor(Actor person)
    {
        
        if (person.GetType() == new playeractor().GetType())
        {
            return interactor.generateplayer(person);
        }
        else if(person.GetType() == new trainer().GetType())
        {
            return interactor.generatetrainer(person);
        }
        else
        {
            return interactor.generateactor(person);
        }
    }


}
