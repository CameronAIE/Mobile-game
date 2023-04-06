using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallModeAddScore : MonoBehaviour
{
    [SerializeField]
    private GameManager gm;

    private float ballScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            ballScore = other.gameObject.GetComponent<BallModeBall>().score;
            gm.score += ballScore;
            Destroy(other.gameObject);
        }
    }
}
