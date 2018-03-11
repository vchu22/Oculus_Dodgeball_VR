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
        gameStat = GameObject.Find("GameScript").GetComponent<GameStat>();
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
            setDestination();
        }
        transform.position = Vector3.MoveTowards(from, destination, speed * Time.deltaTime);
    }

    // what to do when collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        // target will disappear when hit by a ball
        if (collision.collider.tag == "Ball")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
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
        float x = rand.Next(-200, 200) * 0.1f,
            y = 1.3f,
            z = rand.Next(-200, 100) * 0.1f;
        Vector3 vtr = new Vector3(x, y, z);
        destination = vtr;
    }
}