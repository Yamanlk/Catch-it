using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public int ballColor;
    public Transform[] targets;
    private Transform currentTarget;
    private float waitTime;

    void Start()
    {
        targets[0] = GameObject.FindGameObjectWithTag("TargetU").transform;
        targets[1] = GameObject.FindGameObjectWithTag("TargetD").transform;
        targets[2] = GameObject.FindGameObjectWithTag("TargetR").transform;
        targets[3] = GameObject.FindGameObjectWithTag("TargetL").transform;
        int ran = Random.Range(0, 4);
        currentTarget = targets [ran];
        waitTime = 3;
    }

    void Update()
    {
        if (!GameManger.dead)
        {
            transform.Translate(Vector2.Lerp(transform.position, currentTarget.position, 1f) * Time.deltaTime / 2);
            if (waitTime > 0)
            {
                waitTime -= Time.deltaTime;
            } else
            {
                GameManger.health--;
                Destroy(this.gameObject);
            }
        }
    }
}
