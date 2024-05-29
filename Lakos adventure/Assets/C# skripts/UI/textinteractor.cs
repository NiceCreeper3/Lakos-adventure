using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public static class textinteractor
{
    public static TypeWriterEffect textboxinsceene;
    public static GameObject box;

    public static RuntimeAnimatorController controller;
    public static animationinteractor interactor;

    public static void RunTextBox(string text)
    {
        if (interactor)
        {
            box.SetActive(true);
            textboxinsceene.CallUpdateFullText(text);
        }
    }


    public static void changeanim(RuntimeAnimatorController animator)
    {
        controller = animator;
        interactor.setcontroller();
    }
    public static void changeanim()
    {
        controller = null;
        interactor.setcontroller();
    }
    public static Actorscript Generateactor(Actor person, Vector2 direction, Vector2Int location)
    {
        Debug.Log(person.name);
        if (!person.body)
        {
            if (person as playeractor == person)
            {
                return interactor.generateplayer(person,direction, location);
            }
            else if (person as trainer == person)
            {
                return interactor.generatetrainer(person, direction, location);
            }
            else
            {
                return interactor.generateactor(person, direction, location);
            }
        }
        else return person.body;


    }


}
