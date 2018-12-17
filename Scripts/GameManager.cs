using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

	// Variables
	[SerializeField] GameObject panelOptions;
    private bool optionActive = false;
	private Resource resources;

	// Getters and Setters


	public Resource Resources{
		get{
			return resources;
		}
	}
	

	// Use this for initialization
	void Start () {
		resources = new Resource();

		Debug.Log("Jeu lancé.");
	}
	
	// Update is called once per frame

	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !optionActive)
        {
            panelOptions.SetActive(true);
            optionActive = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && optionActive)
        {
            panelOptions.SetActive(false);
            optionActive = false;
        }
    }

	// Functions 

    public void backMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

	public void leaveGame()
    {
        Application.Quit();
    }
	
}
