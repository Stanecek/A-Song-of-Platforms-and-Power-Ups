using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene ("Main", LoadSceneMode.Single);
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void GoToInstructions()
    {
        SceneManager.LoadScene("Controls", LoadSceneMode.Single);
    }

    public void GoToIntro()
    {
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}