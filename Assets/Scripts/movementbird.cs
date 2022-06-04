using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
public class movementbird : MonoBehaviour
{
    // Start is called before the first frame update
    public int jump = 300;

    public GameObject restart;
    public GameObject start;
    public GameObject change;
    public GameObject background;
    public GameObject pause;
    public GameObject obstacle;
    public GameObject ground;
    public GameObject flash;
    public following camera_;
    public Text score;
    bool dead;
    bool b;
    int i ;
    Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Awake()
    {
        restart.SetActive(false);
        Time.timeScale = 0;
    }
    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D col)
    {
        // do not repeat lose function
        i++;
        if (i == 1){
                lose();
            }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // do not repeat lose function
        if(col.gameObject.tag == "obstacles" && i == 0)
        {
            i++;
            lose();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        // Obstacle Spawner
        if (col.gameObject.tag == "ObstaclesParent")
        {
            Debug.Log(obstacle.GetComponent<SpriteRenderer>().bounds.size.y);
            float posy = Random.Range(
                ground.transform.position.y + (ground.GetComponent<SpriteRenderer>().bounds.size.y + obstacle.GetComponent<SpriteRenderer>().bounds.size.y) / 2,
                (background.GetComponent<SpriteRenderer>().bounds.size.y - obstacle.GetComponent<SpriteRenderer>().bounds.size.y) / 2
            );
            col.gameObject.transform.position = new Vector3(
                (obstacle.GetComponent<SpriteRenderer>().bounds.size.x / 2) + camera_.pos,
                posy, col.gameObject.transform.position.z
            );
            // Adding to score
            score.text = (int.Parse(score.text) + 1).ToString();
        }
    }
    void Update()
    {
        // getting player input
        // rotate the bird per click and per frame
        if (Input.GetMouseButtonDown(0) && !dead && b)
        {
            if ((transform.rotation.z < 0.075f))
            {
                transform.rotation = new Quaternion(0, 0, 0.25f + transform.rotation.z, transform.rotation.w);
            }
            body.AddForce(Vector2.up * jump);
        }
        else if (!Input.GetMouseButtonDown(0) && b && !(transform.rotation.z < -0.15f))
        {
            transform.rotation = new Quaternion(0, 0,  -0.00325f + transform.rotation.z, transform.rotation.w);
        }
    }
    void FixedUpdate()
    {
        // to make flash effect
        if (flash.GetComponent<Image>().color.a > 0){
            Debug.Log(flash.GetComponent<Image>().color);
            flash.GetComponent<Image>().color = new Color(1,1,1, flash.GetComponent<Image>().color.a - 0.1f);
        }

    }

    public void replay()
    {
        pause.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void starting()
    {
        b = !b;
        Time.timeScale = 1;
        start.SetActive(false);
        change.SetActive(false);
        transform.position = new Vector2(-6, transform.position.y);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        pause.SetActive(true);
        flash.GetComponent<Image>().color = new Color(1,1,1,1);
    }
    void lose()
    {
        dead = true;
        restart.SetActive(dead);
        pause.SetActive(!dead);
        body.velocity = Vector2.zero;
        GetComponent<Animator>().SetBool("isdead", true);
        flash.GetComponent<Image>().color = new Color(1,1,1,1);
    }
}
