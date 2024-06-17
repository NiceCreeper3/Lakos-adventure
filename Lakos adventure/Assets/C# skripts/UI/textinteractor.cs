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

    //plays text in the text box
    public static void RunTextBox(string text)
    {
        if (interactor)
        {
            box.SetActive(true);
            textboxinsceene.CallUpdateFullText(text);
        }
    }

    // activate cutsceenes
    public static void changeanim(RuntimeAnimatorController animator)
    {
        controller = animator;
        interactor.setcontroller();
    }

    //deactivates cutsceenes
    public static void changeanim()
    {
        controller = null;
        interactor.setcontroller();
    }

    //generates actor in current scene
    public static Actorscript Generateactor(Actor person, Vector2 direction, Vector2Int location, RuntimeAnimatorController interaction)
    {
        Debug.Log(person.name + " at: " + location);
        if (!person.body)
        {
            if (person as playeractor == person)
            {
                Actorscript actorscript = interactor.generateplayer(person,direction, location);
                person.set(location);
                person.turn(direction);
                person.changeinteraction(interaction);
                return actorscript;
            }
            else if (person as trainer == person)
            {
                Actorscript actorscript = interactor.generatetrainer(person, direction, location, interaction);
                person.set(location);
                person.turn(direction);
                person.changeinteraction(interaction);
                return actorscript;
            }
            else
            {
                Actorscript actorscript = interactor.generateactor(person, direction, location, interaction);
                person.set(location);
                person.turn(direction);
                person.changeinteraction(interaction);
                return actorscript;
            }
        }
        else
        {
            person.set(location);
            person.turn(direction);
            person.changeinteraction(interaction);
            return person.body;
        }




    }


}
