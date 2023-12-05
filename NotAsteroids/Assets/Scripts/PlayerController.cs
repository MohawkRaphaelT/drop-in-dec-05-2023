using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public float bulletForce = 3f;
    public float bulletLifetime = 20f;

    void Start()
    {
        
    }


    void Update()
    {
        bool rotateCCW = Input.GetKey(KeyCode.A);
        bool rotateCW = Input.GetKey(KeyCode.D);
        bool doAccel = Input.GetKey(KeyCode.W);
        bool doShoot = Input.GetKeyDown(KeyCode.Space);

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
        if (doShoot)
        {
            Vector3 position = transform.position + transform.up;
            GameObject bulletInstance = Instantiate(bullet, position, Quaternion.identity);
            
            Rigidbody2D rigidbody = bulletInstance.GetComponent<Rigidbody2D>();
            rigidbody.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);

            Destroy(bulletInstance, bulletLifetime);
        }
    }
}
