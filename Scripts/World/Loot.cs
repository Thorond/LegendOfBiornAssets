using UnityEngine;

public class Loot
{
    private int gold;
    private int wood;
    private int iron;
    private int slaves;

    //Constructor
    public Loot(int g, int w, int i, int s)
    {
        gold = g;
        wood = w;
        iron = i;
        slaves = s;
    }

    //Getters and Setters
    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
        }
    }

    public int Wood
    {
        get
        {
            return wood;
        }
        set
        {
            wood = value;
        }
    }

    public int Iron
    {
        get
        {
            return iron;
        }
        set
        {
            iron = value;
        }
    }

    public int Slaves
    {
        get
        {
            return slaves;
        }
        set
        {
            slaves = value;
        }
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