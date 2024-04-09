using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Animations;

[CreateAssetMenu(fileName = "new Actor", menuName = "person/Civilian")]
public class Actor : ScriptableObject
{
    [Header("actor")]
    public string Name;
    public Sprite[] sprites;

    [HideInInspector] public Actorscript body;
    [SerializeField] public textinteractor Textinteractor;

    public RuntimeAnimatorController interaction;


    public void movex(int length)
    {
        if (length < 0)
        {
            turn(3);
        }
        else if (length > 0)
        {
            turn(4);
        }
        body.movepoint += new Vector3(0.64f * length, 0, 0);
    }
    public void movey(int length)
    {
        if (length < 0)
        {
            turn(2);
        }
        else if (length > 0)
        {
            turn(1);
        }
        body.movepoint += new Vector3(0, 0.64f * length, 0);
    }
    public void setx(int location)
    {
        LocationData data = Textinteractor.interactor.GetComponent<LocationHandeler>().data;
        body.movepoint = new Vector3(0.64f * location, body.gameObject.transform.position.y, 0);
        body.gameObject.transform.position = new Vector3(0.64f * location, body.gameObject.transform.position.y, 0);
        int index = data.findactor(this);
        //data.actordatainfo[index].location.x = location;
        
    }
    public void sety(int location)
    {
        body.movepoint = new Vector3(body.gameObject.transform.position.x, 0.64f * location, 0);
        body.gameObject.transform.position = new Vector3(body.gameObject.transform.position.x, 0.64f * location, 0);
    }
    public void turn(int direction)
    {
        SpriteRenderer renderer = body.GetComponentInChildren<SpriteRenderer>();
        switch(direction)
        {
            case 1:
                body.diretion = new Vector2(0,1);
                renderer.sprite = Getsprite("forward");
                break;

            case 2:
                body.diretion = new Vector2(0, -1);
                renderer.sprite = Getsprite("back");
                break;

            case 3:
                body.diretion = new Vector2(-1, 0);
                renderer.sprite = Getsprite("left");
                break;

            case 4:
                body.diretion = new Vector2(1, 0);
                renderer.sprite = Getsprite("right");
                break;
        }
    }
    public void turn(Vector2 direction)
    {
        SpriteRenderer renderer = body.GetComponentInChildren<SpriteRenderer>();
        if (direction == new Vector2(0, 1))
        {
            body.diretion = new Vector2(0, 1);
            renderer.sprite = Getsprite("forward");
        }
        else if(direction == new Vector2(0, -1))
        {
            body.diretion = new Vector2(0, -1);
            renderer.sprite = Getsprite("back");
        }
        else if (direction == new Vector2(-1, 0))
        {
            body.diretion = new Vector2(-1, 0);
            renderer.sprite = Getsprite("left");
        }
        else if (direction == new Vector2(1, 0))
        {
            body.diretion = new Vector2(1, 0);
            renderer.sprite = Getsprite("right");
        }
                

                





    }

    public void ineract()
    {
        Textinteractor.changeanim(interaction);
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

    public void kill()
    {
        Destroy(body.gameObject);
    }
    

}
