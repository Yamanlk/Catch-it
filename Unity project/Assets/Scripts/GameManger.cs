using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour {

    public static int score;
    public static int health;
    public static bool dead;
    public GameObject panel;
    public Text sc;
    public Text heal;

	// Use this for initialization
	void Start () {
        dead = false;
        health = 10;
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        sc.text = score.ToString();
        heal.text = health.ToString();
        if (dead)
        {
            panel.SetActive(true);
        } else
        {
            panel.SetActive(false);
        }
        if (health == 0)
        {
            dead = true;
        }
	}

    public void Restart(){
        Application.LoadLevel(Application.loadedLevel);
    }
    public void Exit(){
        Application.Quit();
    }
    public void Stop(){
        dead = true;
    }
}
