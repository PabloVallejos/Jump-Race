using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bul;
    public Transform muz;
    public SpriteRenderer sr;
    public Sprite[] sps;
    public bool on;
    public GameObject p;
    float timer = 3;

    void Start()
    {
        //p = GameObject.FindGameObjectWithTag("Player");
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
            if (p.gameObject.tag == "Player") { sr.sprite = sps[1]; }

            if (p.gameObject.tag == "P1") { sr.sprite = sps[2]; }
            if (p.gameObject.tag == "P2") { sr.sprite = sps[3]; }


            if (timer <= 0)
            {
                GameObject bullet = Instantiate(bul, muz.position, transform.rotation);
                bullet.GetComponent<Bullet>().p = p;
                timer = 3;
            }
        }
    }
}
