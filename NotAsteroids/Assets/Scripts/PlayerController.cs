using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    new public Rigidbody2D rigidbody2D;
    public GameObject bullet;
    public float bulletForce = 3f;
    public float bulletLifetime = 20f;

    public KeyCode keyRotateCCW = KeyCode.A;
    public KeyCode keyRotateCW = KeyCode.D;
    public KeyCode keyAccel = KeyCode.W;
    public KeyCode keyShoot = KeyCode.Space;


    private void Update()
    {
        bool doShoot = Input.GetKeyDown(keyShoot);

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

    void FixedUpdate()
    {
        bool rotateCCW = Input.GetKey(keyRotateCCW);
        bool rotateCW = Input.GetKey(keyRotateCW);
        bool doAccel = Input.GetKey(keyAccel);

        // Rotate
        float rotation = 0;
        if (rotateCCW)
            rotation += 90 * Time.deltaTime;

        if (rotateCW)
            rotation -= 90 * Time.deltaTime;

        rigidbody2D.SetRotation(transform.rotation.eulerAngles.z + rotation);

        // Translate
        if (doAccel)
        {
            Vector3 position = transform.position + transform.up * 5f * Time.deltaTime;
            rigidbody2D.MovePosition(position);
        }
    }
}
