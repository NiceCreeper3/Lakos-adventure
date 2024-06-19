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

    public RuntimeAnimatorController interaction;


    public void movex(int length)
    {
        LocationData data = textinteractor.interactor.GetComponent<LocationHandeler>().data;
        int index = data.findactor(this);
        if (index != -1)
        {
            
            LocationData.SceneActorData actorData = data.actordatainfo[index];
            if (length != 0)
            {
            }

            int change = actorData.location.x + length;
            data.setactor(this,new Vector2Int(change, actorData.location.y));
        }

        turn(new Vector2(length,0));
        body.movepoint += new Vector2Int(length, 0);
    }
    public void movey(int length)
    {
        LocationData data = textinteractor.interactor.GetComponent<LocationHandeler>().data;
        int index = data.findactor(this);
        if (index != -1)
        {

            LocationData.SceneActorData actorData = data.actordatainfo[index];
            if (length != 0)
            {
            }

            int change = actorData.location.y + length;
            data.setactor(this, new Vector2Int(actorData.location.x, change));
        }
        turn(new Vector2(0, length));
        body.movepoint += new Vector2Int(0, length);
    }
    public void set(Vector2Int location)
    {
        
        LocationData data = textinteractor.interactor.GetComponent<LocationHandeler>().data;
        body.movepoint = new Vector2Int(location.x, location.y);
        body.gameObject.transform.position = new Vector3((0.64f * location.x) + 0.32f, (0.64f * location.y) + 0.32f, 0);
        data.setactor(this, new Vector2Int(location.x, location.y));
    }
    public void setx(int location)
    {
        LocationData data = textinteractor.interactor.GetComponent<LocationHandeler>().data;
        body.movepoint = new Vector2Int(location, body.movepoint.y);
        body.gameObject.transform.position = new Vector3((0.64f * location) + 0.32f, body.gameObject.transform.position.y, 0);
        int index = data.findactor(this);
        if (index != -1)
        {
            LocationData.SceneActorData actorData = data.actordatainfo[index];
            int change = location;
            data.setactor(this, new Vector2Int(change, actorData.location.y));
        }
        
    }
    public void sety(int location)
    {
        LocationData data = textinteractor.interactor.GetComponent<LocationHandeler>().data;
        body.movepoint = new Vector2Int(body.movepoint.x, location);
        body.gameObject.transform.position = new Vector3(body.gameObject.transform.position.x, (0.64f * location) + 0.32f, 0);
        int index = data.findactor(this);
        if (index != -1)
        {
            LocationData.SceneActorData actorData = data.actordatainfo[index];

            int change = location;
            data.setactor(this, new Vector2Int(actorData.location.x, change));
        }
    }
    public void turn(int direction)
    {
        LocationData data = textinteractor.interactor.GetComponent<LocationHandeler>().data;
        int index = data.findactor(this);
        LocationData.SceneActorData actorData = data.actordatainfo[index];

        
        if (body)
        {
            SpriteRenderer renderer = body.GetComponentInChildren<SpriteRenderer>();
            switch (direction)
            {
                case 1:
                    body.diretion = new Vector2(0, 1);
                    actorData.direction = new Vector2(0, 1);
                    renderer.sprite = Getsprite("forward");
                    break;

                case 2:
                    body.diretion = new Vector2(0, -1);
                    actorData.direction = new Vector2(0, -1);
                    renderer.sprite = Getsprite("back");
                    break;

                case 3:
                    body.diretion = new Vector2(-1, 0);
                    actorData.direction = new Vector2(-1, 0);
                    renderer.sprite = Getsprite("left");
                    break;

                case 4:
                    body.diretion = new Vector2(1, 0);
                    actorData.direction = new Vector2(1, 0);
                    renderer.sprite = Getsprite("right");
                    break;
            }
        }
        else
        {
            switch (direction)
            {
                case 1:
                    actorData.direction = new Vector2(0, 1);
                    break;

                case 2:
                    actorData.direction = new Vector2(0, -1);
                    break;

                case 3:
                    actorData.direction = new Vector2(-1, 0);
                    break;

                case 4:
                    actorData.direction = new Vector2(1, 0);
                    break;
            }
        }
        
    }
    public void turn(Vector2 direction)
    {
        LocationData data = textinteractor.interactor.GetComponent<LocationHandeler>().data;
        int index = data.findactor(this);
        LocationData.SceneActorData actorData = data.actordatainfo[index];
        actorData.direction = direction;
        if (body)
        {
            SpriteRenderer renderer = body.GetComponentInChildren<SpriteRenderer>();
            direction.Normalize();
            if (direction.y == 1)
            {
                body.diretion = new Vector2(0, 1);
                renderer.sprite = Getsprite("forward");
            }
            else if (direction.y == -1)
            {
                body.diretion = new Vector2(0, -1);
                renderer.sprite = Getsprite("back");
            }
            else if (direction.x == -1)
            {
                body.diretion = new Vector2(-1, 0);
                renderer.sprite = Getsprite("left");
            }
            else if (direction.x == 1)
            {
                body.diretion = new Vector2(1, 0);
                renderer.sprite = Getsprite("right");
            }
        }





    }

    public void ineract()
    {
        textinteractor.changeanim(interaction);
    }
    public void changeinteraction(RuntimeAnimatorController animatorController)
    {
        LocationData data = textinteractor.interactor.GetComponent<LocationHandeler>().data;
        int index = data.findactor(this);
        LocationData.SceneActorData actorData = data.actordatainfo[index];
        interaction = animatorController;
        actorData.interaction = animatorController;
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
        LocationData data = textinteractor.interactor.GetComponent<LocationHandeler>().data;
        data.removeactor(this);
        if (body)
        {
            Destroy(body.gameObject);
        }
    }
    

}
