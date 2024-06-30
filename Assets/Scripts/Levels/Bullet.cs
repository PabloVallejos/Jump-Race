using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject p;
    public float speed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 look = transform.position - p.transform.position;
        look.Normalize();
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;
        //transform.Rotate(0, 0, angle);

        rb.AddForce(-look * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
