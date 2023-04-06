using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGrav : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]
    private float grav;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.AddForce(Vector3.down * grav, ForceMode.Impulse);
    }
}
