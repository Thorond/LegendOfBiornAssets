using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{

    [SerializeField]
    Text textNbVikings;
    [SerializeField]
    Text textNbShieldmaidens;
    [SerializeField]
    GameObject panelAttack;

    enum tagBtn
    {
        DownVikingBtn,
        UpVikingBtn,
        DownShieldmaidenBtn,
        UpShieldmaidenBtn
    }

    int nbVikings = 20;
    int nbShieldmaidens = 20;
    int nbVikingsSent = 0;
    int nbShieldmaidensSent = 0;

    public void SelectedBtn(GameObject btnPressed)
    {
        Debug.Log("nbVikings : " + nbVikings);
        Debug.Log("nbShieldmaidens : " + nbShieldmaidens);
        Debug.Log("nbVikingsSent : " + nbVikingsSent);
        Debug.Log("nbShieldmaidensSent : " + nbShieldmaidensSent);

        if (btnPressed.tag == tagBtn.DownVikingBtn.ToString())
        {
            if (nbVikingsSent > 0)
            {
                nbVikingsSent -= 1;
                nbVikings += 1;
                Debug.Log("Dans DownVikingBtn");
                Debug.Log("nbVikings : " + nbVikings);
                Debug.Log("nbShieldmaidens : " + nbShieldmaidens);
                Debug.Log("nbVikingsSent : " + nbVikingsSent);
                Debug.Log("nbShieldmaidensSent : " + nbShieldmaidensSent);
            }
        }
        else if (btnPressed.tag == tagBtn.UpVikingBtn.ToString())
        {
            if (nbVikings > 0)
            {
                nbVikingsSent += 1;
                nbVikings -= 1;
                Debug.Log("Dans UpVikingBtn");
                Debug.Log("nbVikings : " + nbVikings);
                Debug.Log("nbShieldmaidens : " + nbShieldmaidens);
                Debug.Log("nbVikingsSent : " + nbVikingsSent);
                Debug.Log("nbShieldmaidensSent : " + nbShieldmaidensSent);
            }
        }
        else if (btnPressed.tag == tagBtn.DownShieldmaidenBtn.ToString())
        {
            if (nbShieldmaidensSent > 0)
            {
                nbShieldmaidensSent -= 1;
                nbShieldmaidens += 1;
                Debug.Log("Dans DownShieldmaidenBtn");
                Debug.Log("nbVikings : " + nbVikings);
                Debug.Log("nbShieldmaidens : " + nbShieldmaidens);
                Debug.Log("nbVikingsSent : " + nbVikingsSent);
                Debug.Log("nbShieldmaidensSent : " + nbShieldmaidensSent);
            }
        }
        else if (btnPressed.tag == tagBtn.UpShieldmaidenBtn.ToString())
        {
            if (nbShieldmaidens > 0)
            {
                nbShieldmaidensSent += 1;
                nbShieldmaidens -= 1;
                Debug.Log("Dans DownShieldmaidenBtn");
                Debug.Log("nbVikings : " + nbVikings);
                Debug.Log("nbShieldmaidens : " + nbShieldmaidens);
                Debug.Log("nbVikingsSent : " + nbVikingsSent);
                Debug.Log("nbShieldmaidensSent : " + nbShieldmaidensSent);
            }
        }
        textNbVikings.text = nbVikingsSent.ToString();
        textNbShieldmaidens.text = nbShieldmaidensSent.ToString();
    }

    public void ShowPanelAttack()
    {
        panelAttack.SetActive(true);
    }

    public void HiddenPanelAttack()
    {
        panelAttack.SetActive(false);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
