using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStat : MonoBehaviour {
    [HideInInspector] public int score;
    [SerializeField] private GameObject targetPrefab;
    public int totalTargets;
    System.Random rand = new System.Random();
    
    // Use this for initialization
    void Start () {
        score = 0;
        totalTargets = rand.Next(1, 15); // ensure there is at least one in the scene
        for (int i = 0; i < totalTargets; i++)
            generateTargets();
        Debug.Log("The room has a total of "+ totalTargets + " targets");
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    private void generateTargets()
    {
        Vector3 pos = new Vector3(rand.Next(-499, 499) * 0.01f, 1.3f, rand.Next(-499, 499) * 0.01f);
        GameObject newTarget = Instantiate(targetPrefab, pos, Quaternion.identity);
    }
}
