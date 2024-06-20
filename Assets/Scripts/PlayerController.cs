using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool P;
    public Rigidbody2D head;
    Rigidbody2D rb;
    float power;
    bool ground;
    Vector2 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dir.y = 1;
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space) && ground)
        {
            power += Time.deltaTime * 100;
        }if (Input.GetKeyUp(KeyCode.Space) && ground)
        {
            rb.AddForce(dir * power);
            power = 0;
        }
        Debug.Log(power);
        Debug.Log(ground);

        if (head != null)
        {
            head.AddForce(Vector2.up * 0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) { ground = true; }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) { ground = false; }
    }
}
