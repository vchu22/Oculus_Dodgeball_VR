using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Vector3 destination;
    private System.Random rand = new System.Random();
    GameStat gameStat;
    private float speed;
    // Use this for initialization
    void Start()
    {
        gameStat = GameObject.Find("GameUniverse").GetComponent<GameStat>();
        destination = new Vector3();
        speed = 1f;
        setDestination();
    }

    // Update is called once per frame
    void Update()
    {
        // Move randomly
        Vector3 from = transform.position;
        if (from == destination)
        {
            Debug.Log("from == dest");
            setDestination();
        }
        transform.position = Vector3.MoveTowards(from, destination, speed * Time.deltaTime);
        Debug.Log("Moved to (x: " + destination.x + ", y: "+ destination.y + ", z: " + destination.z+")");
    }

    // what to do when collision occurs
    private void OnCollisionEnter(Collision collisionInfo)
    {
        // target will disappear when hit by a ball
        if (collisionInfo.collider.tag == "Ball")
        {
            Destroy(gameObject);
            int gamescore = gameStat.score++;
            Debug.Log("Score: " + gamescore);
        }
        else
        {
            // change direct when hitting a concrete object
            setDestination();
        }
    }
    private void setDestination()
    {
        float x = rand.Next(-490, 490) * 0.01f,
            y = 1.3f,
            z = rand.Next(-490, 490) * 0.01f;
        Debug.Log("Dest (x: " + x + ", y: " + y + ", z: " + z+")");
        Vector3 vtr = new Vector3(x, y, z);
        destination = vtr;
    }
}