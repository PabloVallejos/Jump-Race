using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Cannon can;
    public Door dr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && can != null) { can.on = true; can.p = collision.gameObject; }
        if (collision.gameObject.CompareTag("P1") && can != null) { can.on = true; can.p = GameObject.FindGameObjectWithTag("P2"); }
        if (collision.gameObject.CompareTag("P2") && can != null) { can.on = true; can.p = GameObject.FindGameObjectWithTag("P1"); }

        if (collision.gameObject.CompareTag("Player") && dr != null || collision.gameObject.CompareTag("P1") && dr != null || collision.gameObject.CompareTag("P2") && dr != null) { dr.on = true; }
    }
}
