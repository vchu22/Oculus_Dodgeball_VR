using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillRack : MonoBehaviour {
    [SerializeField] private GameObject ballPrefab;
    private GameObject rack;
    private Vector3 startPoint;
    private Vector3 offset;
    void Start () {
        rack = GameObject.Find("Basketball rack");
        startPoint = new Vector3(-0.4f, 0.1f, 0.16f);
        offset = new Vector3(0.4f, -0.4f, -0.32f);
        Generate();
    }
    
    void Update () {
        
    }

    private void Generate()
    {
        Vector3 newPosition;
        GameObject newDodgeball;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                float k = ((j < 3)? 0.0f: 0.1f);
                newPosition = transform.position + startPoint + new Vector3(offset.x * j + k, offset.y * i, offset.z * ((i%2==0)? 0:1));
                newDodgeball = Instantiate(ballPrefab, newPosition, Quaternion.identity);
            }
        }
    }
}
