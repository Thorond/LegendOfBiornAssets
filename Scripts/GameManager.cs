using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

	// Variables
	[SerializeField] GameObject panelOptions;
	[SerializeField] GameObject gameOverPanel;
	[SerializeField] BalanceManager balanceManager;
    private bool optionActive = false;
	private bool gameOver = false;
	private Resource resources;

	// Getters and Setters


	public Resource Resources{
		get{
			return resources;
		}
	}
	public bool GameOver{get{return gameOver;}set{gameOver = value;}}
	

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

		if ( !gameOver){
			
		} else {
			gameOverPanel.SetActive(true);
		}
    }

	// Functions 

    public void backMenu()
    {
		gameOverPanel.SetActive(false);
        SceneManager.LoadScene("MenuScene");
    }

	public void leaveGame()
    {
        Application.Quit();
    }

	
}
