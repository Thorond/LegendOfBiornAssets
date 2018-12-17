using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [SerializeField] GameObject leaderboardPanel;
    [SerializeField] GameObject tutoPanel;
    [SerializeField] GameObject optPanel;
    [SerializeField] GameObject menuPanel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void classementPanel()
    {
        leaderboardPanel.SetActive(true);
    }

    public void tutorielPanel()
    {
        tutoPanel.SetActive(true);
    }

    public void optionsPanel()
    {
        optPanel.SetActive(true);        
    }

    public void retourMenu(Btn selectedBtn)
    {
        Debug.Log(selectedBtn.tag);
        if (selectedBtn.tag == "tutorielBtn")
            tutoPanel.SetActive(false);
        else if (selectedBtn.tag == "optionsBtn")
            optPanel.SetActive(false);
        else if (selectedBtn.tag == "classementPanel")
            leaderboardPanel.SetActive(false);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
