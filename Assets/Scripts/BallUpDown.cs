using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallUpDown : MonoBehaviour
{

    private Rigidbody _rb;
    private float timeToMove;
    [SerializeField]
    private float whenToMove;
    [SerializeField]
    private float maxForce;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timeToMove += Time.deltaTime;
        

        if (timeToMove >= whenToMove)
        {
            timeToMove = 0;
            float forceToAdd = Random.Range(-maxForce, maxForce);
            _rb.AddForce(Vector3.up * forceToAdd, ForceMode.Impulse);
        }
    }
}

