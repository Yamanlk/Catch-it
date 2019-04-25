using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] Button up;
    [SerializeField] Button down;
    [SerializeField] Button right;
    [SerializeField] Button left;
    [SerializeField] Button colorChanger;

    [SerializeField] Transform[] targets;
    [SerializeField] Sprite[] sprits;

    int currentColor;

    Vector3 vec1 = new Vector3(0,0,90);
    Vector3 vec0 = new Vector3 (0,0,0);
   
	void Start () {
        currentColor = 1;
        colorChanger.onClick.AddListener(() =>
        {
            if (!GameManger.dead) {
                ColorChanging();
            }
        }); 
        up.onClick.AddListener(() =>
        {
            if (!GameManger.dead) {
                Move(targets[0],false);   
            }
           
        }); 
        down.onClick.AddListener(() =>
        {
            if (!GameManger.dead) {
                Move(targets[1],false);     
            }
        }); 
        right.onClick.AddListener(() =>
        {
            if (!GameManger.dead) {
                Move(targets[2],true);     
            }
 
        }); 
        left.onClick.AddListener(() =>
        {
            if (!GameManger.dead) {
                Move(targets[3],true);     
            }  
        }); 
	}
	
    void Update () {
        
	}

    void Move(Transform target , bool rot){
        transform.position = target.position;
        if (rot)
        {
            transform.eulerAngles = vec1;
        } else
        {
            transform.eulerAngles = vec0;
        }
    }

    void ColorChanging(){
        if (currentColor  != 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprits [currentColor];
            currentColor++;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprits [0];
            currentColor = 1;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Ball")
        {
            TackBall(col.gameObject);
        }
    }

    void TackBall(GameObject ball){
        if (ball.GetComponent<Ball>().ballColor == currentColor)
        {
            Destroy(ball);
            GameManger.score++;
        } else
        {
            Destroy(ball);
            GameManger.health--;
        }
    }
}
