using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    // this script made to move background and to control when the ObstacleParent and background stop moving if game over
    public bool iscollided;
    public float speed;
    public obstaclespowner obstacle;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            iscollided = true;
        }
    }
    // Update is called once per frame
    public void stop(GameObject self)
    {
        self.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    }
}
