using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "new Actor", menuName = "person/Civilian")]
public class Actor : ScriptableObject
{
    [Header("actor")]
    public string Name;
    public Sprite[] sprites;

    [HideInInspector] public Actorscript body;


    public void movex(int length)
    {
        if (length <= 0)
        {

        }
        else if (length > 0)
        {

        }
    }
    public void movey(int length)
    {
        
    }

    public void turn(int direction)
    {
        SpriteRenderer renderer = body.GetComponentInChildren<SpriteRenderer>();
        switch(direction)
        {
            case 1:
                renderer.sprite = Getsprite("foward");
                break;

            case 2:
                renderer.sprite = Getsprite("back");
                break;

            case 3:
                renderer.sprite = Getsprite("left");
                break;

            case 4:
                renderer.sprite = Getsprite("right");
                break;
        }
    }

    public Sprite Getsprite(string spritename)
    {
        Sprite sprite = null;
        foreach (Sprite sprite1 in sprites)
        {
            if(sprite1.name == spritename)
            {
                sprite = sprite1;
            }
        }
        return sprite;
    }

}
