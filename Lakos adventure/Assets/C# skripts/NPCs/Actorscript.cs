using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actorscript : MonoBehaviour
{
    [SerializeField] public Actor actor;
    [SerializeField] public Vector2 diretion;
    [SerializeField] public Grid grid;
    [SerializeField] public Vector3 movepoint;

    private void Start()
    {
        //StartCoroutine(drawframe());
    }
    IEnumerator drawframe()
    {
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        int frameindex = 1;
        while(true)
        {
            bool v = transform.position != movepoint;
            //yield return new WaitUntil(System.Func< transform.position != movepoint > ());
            yield return new WaitForSeconds(0.3f);
            if (transform.position != movepoint)
            {
                if (diretion.y != 0)
                {
                    if (diretion.y >= 0)
                    {
                        //forward
                        if (frameindex % 2 == 0)
                        {
                            renderer.sprite = actor.Getsprite("forward" + frameindex / 2);
                        }
                        else
                        {
                            renderer.sprite = actor.Getsprite("forward");
                        }
                    }
                    else
                    {
                        //back
                        if (frameindex % 2 == 0)
                        {
                            renderer.sprite = actor.Getsprite("back" + frameindex / 2);
                        }
                        else
                        {
                            renderer.sprite = actor.Getsprite("back");
                        }
                    }

                }
                else if (0 != diretion.x)
                {
                    if (diretion.x >= 0)
                    {
                        //right
                        if (frameindex % 2 == 0)
                        {
                            renderer.sprite = actor.Getsprite("right" + frameindex / 2);
                        }
                        else
                        {
                            renderer.sprite = actor.Getsprite("right");
                        }
                    }
                    else
                    {
                        //left
                        if (frameindex % 2 == 0)
                        {
                            renderer.sprite = actor.Getsprite("left" + frameindex / 2);
                        }
                        else
                        {
                            renderer.sprite = actor.Getsprite("left");
                        }
                    }


                }
            }
            else
            {
                if (diretion.y != 0)
                {
                    if (diretion.y >= 0)
                    {
                        renderer.sprite = actor.Getsprite("forward");
                    }
                    else
                    {
                        renderer.sprite = actor.Getsprite("back");
                    }

                }
                else if (0 != diretion.x)
                {
                    if (diretion.x >= 0)
                    {
                        renderer.sprite = actor.Getsprite("right");
                    }
                    else
                    {
                        renderer.sprite = actor.Getsprite("left");
                    }


                }
            }

            if (frameindex == 4)
            {
                frameindex = 1;
            }
            else
            {
                frameindex++;
            }
        }
            
            
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,movepoint, 1 * Time.deltaTime);
        
    }
    public void load()
    {
        
        gameObject.transform.position = movepoint;
        actor.body = this;

        if (diretion.y != 0)
        {
            if (diretion.y >= 0)
            {
                actor.turn(1);
            }
            else
            {
                actor.turn(2);
            }

        }
        else if (0 != diretion.x)
        {
            if (diretion.x >= 0)
            {
                actor.turn(4);
            }
            else
            {
                actor.turn(3);
            }


        }
    }
}
