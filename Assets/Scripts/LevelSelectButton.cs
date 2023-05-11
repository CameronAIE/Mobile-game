using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField]
    private int level;
    // Start is called before the first frame update
    void Start()
    {
        if (level > PlayerPrefs.GetInt("Level", 1))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
