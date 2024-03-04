using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;
[CreateAssetMenu(fileName = "textbox indecator", menuName = "textindecator")]
public class textinteractor: ScriptableObject
{
    public TypeWriterEffect textboxinsceene;
    public GameObject box;

    public AnimatorController controller;
    public animationinteractor interactor;

    public void RunTextBox(string text)
    {
        box.SetActive(true);
        textboxinsceene.CallUpdateFullText(text);
    }

    public void changeanim(AnimatorController animator)
    {
        controller = animator;
        interactor.setcontroller();
    }

    
}
