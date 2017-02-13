using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

    public Transform target;
    public float speed;

    public int countDragonGlass;
    public Text countText;

    public LifeManager lifeManagerScript;

    public GameObject player;

	// Use this for initialization
	void Start () {
        countDragonGlass = 0;
        SetCountText();
    }
	
	// Update is called once per frame
	void Update () {

        if (target != null)
        {
            //Fallow the player
            Vector3 fixedTargetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, fixedTargetPosition, speed * Time.deltaTime);
        }
            

        //transform.position = target.position;

        //If player is out of lives
        if (lifeManagerScript.lifeCounter <= 0)
        {
            Destroy(player);   //Destroy the player

            SceneManager.LoadScene("GameOver", LoadSceneMode.Single); //call the Game Over Scene
        }

        //If player grabs 10 dragon glass
        if (countDragonGlass >= 10)
        {
            SceneManager.LoadScene("WIN", LoadSceneMode.Single); //call the Game Over Scene
        }
    }

    public void CountDragonGlass()
    {
        countDragonGlass++;
    }

    public void SetCountText()
    {
        //countText.text = "Dragon Glass: " + countDragonGlass.ToString();
        countText.text = "X" + countDragonGlass.ToString();
    }
}
