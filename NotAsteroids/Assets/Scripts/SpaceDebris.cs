using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDebris : MonoBehaviour
{
    private int splitCount;

    void Start()
    {
        float x = Random.Range(-27f, 27f);
        float y = Random.Range(-15f, 15f);
        transform.position = new Vector3(x, y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SplitThisObject();
        Destroy(collision.gameObject);
    }

    void SplitThisObject()
    {
        GameObject clone1 = Instantiate(gameObject);
        GameObject clone2 = Instantiate(gameObject);
        clone1.transform.localScale = clone1.transform.localScale / 2f;
        clone2.transform.localScale = clone2.transform.localScale / 2f;
        clone1.GetComponent<SpaceDebris>().splitCount++;
        clone2.GetComponent<SpaceDebris>().splitCount++;

        Destroy(gameObject);
    }
}
