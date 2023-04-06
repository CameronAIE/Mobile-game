using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDown : MonoBehaviour
{
    [SerializeField]
    private float defualtSpeed = 2;
    public float difficultyMultiplyer = 1;
    [SerializeField]
    private float deathZone;
    [SerializeField]
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        gm.obstacleActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.currentDiff < 1)
        {
            gm.currentDiff = 1;
        }

        gm.currentDiff = gm.currentDiff + (gm.currentDiff * 1/10000) * Time.deltaTime;
        transform.Translate(Vector3.down * Time.deltaTime * defualtSpeed * gm.currentDiff);

        if (transform.position.y < deathZone)
        {
            gm.obstacleActive = false;
            
            Destroy(gameObject);
        }
    }
}
