using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WhiteBall : MonoBehaviour
{
    [SerializeField]
    private GameObject[] balls;

    [SerializeField]
    private float timeToChange;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeToChange)
        {
            Instantiate(balls[UnityEngine.Random.Range(0, balls.Length)], this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
