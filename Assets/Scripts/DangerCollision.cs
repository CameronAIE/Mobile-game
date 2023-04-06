using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerCollision : MonoBehaviour
{
    [SerializeField]
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        //gm = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            gm.lost = true;
            gm.gameOver = true;
        }
    }
}
