using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class following : MonoBehaviour
{
    public GameObject background;
    Vector2 init;
    public float pos;
    // Start is called before the first frame update
    void Start()
    {
        // the long x of camera to use it for respowning obstacles behind the front of player view
        pos = transform.position.x + 4.939963f;
    }
    void Awake()
    {
        init = background.transform.position;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        // back to initial position when something of background child has left the camera field
        if (col.gameObject.tag == "GameController"){
            background.transform.position = init;
        }   
    }
    // Update is called  once per frame
    void Update()
    {
    }

}