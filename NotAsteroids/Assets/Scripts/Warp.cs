using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [field: SerializeField] public Vector3 Offset { get; set; }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!collider2D.CompareTag("bullet"))
            return;

        Vector3 newPosition = collider2D.transform.position + Offset;
        collider2D.attachedRigidbody.MovePosition(newPosition);
    }
}
