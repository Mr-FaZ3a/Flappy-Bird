using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclespowner : MonoBehaviour
{
    // this script made to moving obstacles and to control when the obstacles stops moving if game over
    public int speed = 3;
    public obstaclespowner obstacle;
    public bool iscollided;
    public teleport parent, background;
    public GameObject ground, obstacles;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0); 
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            iscollided = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (obstacle.iscollided || background.iscollided)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            parent.stop(obstacles);
            background.stop(ground);

        }

    }
}
