using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStat : MonoBehaviour {
    public int score;
    int totalTargets;
    System.Random rand = new System.Random();
	// Use this for initialization
	void Start () {
        score = 0;
        totalTargets = rand.Next(30);
        Debug.Log("The room has a total of "+ totalTargets + " targets");
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void generateTargets()
    {

    }
}
