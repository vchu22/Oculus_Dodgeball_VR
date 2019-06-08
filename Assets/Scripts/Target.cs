using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Vector3 destination;
    private System.Random rand = new System.Random();
    GameStat gameStat;

    // Use this for initialization
    void Start()
    {
        gameStat = GameObject.Find("GameScript").GetComponent<GameStat>();
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
        transform.position = Vector3.MoveTowards(from, destination, Time.deltaTime);
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
        destination = new Vector3(rand.Next(-200, 200) * 0.1f, 1.3f, rand.Next(-200, 100) * 0.1f);
    }
}