using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillRack : MonoBehaviour {
    [SerializeField] private GameObject ballPrefab;
    private Vector3 startPoint;
    private float rotation;
    void Start () {
        startPoint = new Vector3(0.16f, 1.45f, -1.1f);
        rotation = transform.rotation.eulerAngles.y;
        Generate();
    }
    private void Generate()
    {
        Vector3 newPosition;
        GameObject newDodgeball;
        for (int h = 0; h < 4; h++) // the rack has a total of 4 layers
        {
            for (int l = 0; l < 6; l++) // generate 6 balls for each row
            {
                float bar = ((l < 3)? 0.0f: 0.1f); // there is a bar between the first three ball of a row and the last three. need to skip the bar to distribute the balls evenly
                int side = ((h%2==0)? 0:1); // alternate the row's side as height increments
                Vector3 offset = startPoint + new Vector3(-0.32f * side, -0.4f * h, 0.4f  * l + bar); 
                offset = Quaternion.Euler(0, rotation, 0) * offset; // offset should rotate along on rack's gameObject
                newPosition = transform.position + offset;
                newDodgeball = Instantiate(ballPrefab, newPosition, Quaternion.identity);
            }
        }
    }
}
