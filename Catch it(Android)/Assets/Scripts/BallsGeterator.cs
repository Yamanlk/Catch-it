using UnityEngine;
using System.Collections;

public class BallsGeterator : MonoBehaviour
{
    [SerializeField] GameObject[] balls;
    public float waitTime;

    void Start()
    {
        waitTime = 3f;
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        yield return new WaitForSeconds(3);
        while (!GameManger.dead)
        {
            if (waitTime > 0.4f)
            {
                int ranBalls = Random.Range(0, 3);
                Instantiate(balls [ranBalls], transform.position, transform.rotation);
                yield return new WaitForSeconds(waitTime);
                waitTime -= 0.05f;
            } else
            {
                int ranBalls = Random.Range(0, 3);
                Instantiate(balls [ranBalls], transform.position, transform.rotation);
                yield return new WaitForSeconds(0.4f);
            }
        }
    }
}
