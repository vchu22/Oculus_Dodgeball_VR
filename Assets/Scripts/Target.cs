using System.Collections.Generic;
using UnityEngine;

namespace System
{
    public class Target : MonoBehaviour
    {
        private Vector3 destination = new Vector3();
        private Random rand = new Random();
        GameStat gameStat = GameObject.Find("GameUniverse").GetComponent<GameStat>();
        public float speed;
        // Use this for initialization
        void Start()
        {
            setDestination();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }

        // what do when collision occurs
        private void OnCollisionEnter(Collision collisionInfo)
        {
            // target will disappear when hit by a ball
            if (collisionInfo.collider.tag == "Ball")
            {
                Destroy(gameObject);
                int gamescore = gameStat.score++;
                Debug.Log("Score: "+ gamescore);
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
            Debug.Log("x: " + x + ", y: " + y + ", z: " + z);
            destination = new Vector3(x, y, z);
        }
        private void Move()
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
        }
    }
}