using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer2d : MonoBehaviour {

    public Transform target;
    public float speed = 2f;
    private float minDistance = 8f;
    private float range;

    // Assign by dragging the GameObject with ScriptA into the inspector before running the game.
    public HPController HealthBarScript;

    void Update()
    {
        //Check if the player is alive
        if (target != null)
        {
                //calculate the distance of the player
            range = Vector2.Distance(transform.position, target.position);

            if (range < minDistance)  // if less than minimal distance then follow player
            {
                //Debug.Log(range);

                if (target.position.x > transform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);    //Change the position of the sprite
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);    //Change the position of the sprite
                }


                //Fallow the player, but dont let the enemy "jump" by giving a fixed target position
                Vector2 fixedTargetPosition = new Vector2(target.position.x, transform.position.y);
                transform.position = Vector2.MoveTowards(transform.position, fixedTargetPosition, speed * Time.deltaTime);

            }
        }
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Call function of another script
            HealthBarScript.DamagePayer();
        }
    }


}
