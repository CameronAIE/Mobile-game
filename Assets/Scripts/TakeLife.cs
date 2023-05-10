using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeLife : MonoBehaviour
{
    [SerializeField]
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            gm.lives--;
            other.tag = "die";
        }
    }
}
