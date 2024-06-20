using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bul;
    public Transform muz;
    public bool on;
    GameObject p;
    float timer = 3;

    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            Vector3 look = transform.InverseTransformPoint(p.transform.position);
            float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;

            transform.Rotate(0, 0, angle);
            if (timer > 0) { timer -= Time.deltaTime; }

            if (timer <= 0)
            {
                Instantiate(bul, muz.position, transform.rotation);
                timer = 3;
            }
        }
    }
}
