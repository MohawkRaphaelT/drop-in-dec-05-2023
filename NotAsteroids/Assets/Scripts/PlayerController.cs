using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        bool rotateCCW = Input.GetKey(KeyCode.A);
        bool rotateCW = Input.GetKey(KeyCode.D);
        bool doAccel = Input.GetKey(KeyCode.W);
        bool doShoot = Input.GetKey(KeyCode.Space);

        // Rotate
        float rotation = 0;
        if (rotateCCW)
            rotation += 90 * Time.deltaTime;

        if (rotateCW)
            rotation -= 90 * Time.deltaTime;

        transform.rotation =
            Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + rotation);

        // Translate
        if (doAccel)
            transform.position += transform.up * 5f * Time.deltaTime;

        // Shoot
    }
}
