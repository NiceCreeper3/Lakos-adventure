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
        box.SetActive(true);
        textboxinsceene.CallUpdateFullText(text);
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
    public void generateactor(Actor person)
    {
        interactor.generateactor(person);
    }


}
