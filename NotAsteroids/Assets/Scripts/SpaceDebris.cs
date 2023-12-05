using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDebris : MonoBehaviour
{
    void Start()
    {
        float x = Random.Range(-27f, 27f);
        float y = Random.Range(-15f, 15f);
        transform.position = new Vector3(x, y, 0);
    }

    void Update()
    {
        
    }
}
