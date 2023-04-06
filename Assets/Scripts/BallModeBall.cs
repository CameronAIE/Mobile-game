using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallModeBall : MonoBehaviour
{
    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "die")
        {
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
