using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class swippingcharacter : MonoBehaviour
{
    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
    public GameObject Ok;
    public GameObject Menu;
    GameObject bird;
    int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        Character1.SetActive(true);
        Character2.SetActive(false);
        Character3.SetActive(false);
        Ok.SetActive(false);
        Menu.SetActive(false);
        bird = Character1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void change()
    {
        // swipping birds per click anywhere
        i++;
        switch(i)
        {
            case 1 : Character1.SetActive(true); Character2.SetActive(false); Character3.SetActive(false); bird = Character1; break;
            case 2 : Character1.SetActive(false); Character2.SetActive(true); Character3.SetActive(false); bird = Character2; break;
            case 3 : Character1.SetActive(false); Character2.SetActive(false); Character3.SetActive(true); bird = Character3; i = 0; break;
        }
    }
    public void pausing()
    {
        Time.timeScale = 0;
        Ok.SetActive(true);
        Menu.SetActive(true);
    }
    public void continue_()
    {
        Time.timeScale = 1;
        Ok.SetActive(false);
        Menu.SetActive(false);
    }
    public void break_()
    {
        // execute when the menu button has pressed
        SceneManager.LoadScene(0);
    }
}
