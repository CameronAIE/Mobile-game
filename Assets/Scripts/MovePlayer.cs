using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = objectPos - (new Vector3(0, 0, -40));
        
            if (objectPos.y < -1.675)
            {
                rb.MovePosition(objectPos);
            }
            else
            {
                rb.MovePosition(new Vector3(objectPos.x, -1.675f, objectPos.z));
            }
        

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "attack")
        {
            gm.lives--;
            other.tag = "die";
        }
    }
}
