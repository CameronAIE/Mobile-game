using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBallOnce : MonoBehaviour
{
    private Rigidbody _rb;
    private float timeToMove;
    [SerializeField]
    private float whenToMove;
    [SerializeField]
    private float maxForce;

    private bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            timeToMove += Time.deltaTime;
        }

        if (timeToMove >= whenToMove)
        {
            done = true;
            timeToMove = 0;
            float forceToAdd = Random.Range(-maxForce, maxForce);
            _rb.AddForce(Vector3.right * forceToAdd, ForceMode.Impulse);
        }
    }
}
