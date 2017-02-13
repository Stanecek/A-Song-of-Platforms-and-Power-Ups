using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

    public int startingLives;
    public int lifeCounter;

    private Text theText;

    public HPController healthBarScript;

	// Use this for initialization
	void Start () {

        theText = GetComponent<Text>();

        lifeCounter = startingLives;
	}
	
	// Update is called once per frame
	void Update () {
        theText.text = "X" + lifeCounter;
	}

    public void GiveLife()
    {
        lifeCounter++;
    }

    public void TakeLife()
    {
        lifeCounter--;
        healthBarScript.RestartHealth();
    }
}
