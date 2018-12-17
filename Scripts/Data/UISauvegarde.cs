using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UISauvegarde : MonoBehaviour {

    private GameData json = new GameData();
    private List<PlayerData> datas = new List<PlayerData>();
    private List<PlayerData> list = new List<PlayerData>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onSubmit()
    {
        // On crée datas
        list = json.LoadPlayerData();
        foreach (PlayerData l in list)
        {
            PlayerData p = new PlayerData(l.pseudo, l.score);
            datas.Add(p);
        }

        // On ajoute le joueur
        PlayerData test = new PlayerData("Variable du nom du joueur", 120);

        // Si c'est un record
        if (test.score >= datas[datas.Count - 1].Score)
        {
            // On l'ajoute
            datas.Add(test);
            // On trie
            for (int b = datas.Count - 2; b >= 0; b--)
            {
                for (int c = 0; c <= b; c++)
                {
                    if (datas[c + 1].score > datas[c].score)
                    {
                        PlayerData t = datas[c + 1];
                        datas[c + 1] = datas[c];
                        datas[c] = t;
                    }
                }
            }

            // On réécris le Json
            string ct = "";
            int varTest = 0;
            if (datas.Count < 8)
                varTest = datas.Count;
            else
                varTest = 8;

            ct = ct + "{ \"pseudo\":\" " + datas[0].Name + "\", \"score\":\"" + datas[0].Score + "\"}";
            for (int v = 1; v < varTest; v++)
            {
                Debug.Log(varTest);
                ct = ct + "/{ \"pseudo\":\" " + datas[v].Name + "\", \"score\":\"" + datas[v].Score + "\"}";
            }

            string filePath = Path.Combine(Application.streamingAssetsPath, "player.json");
            File.WriteAllText(filePath, ct);
        }
    }
}
