using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool on;
    void Update()
    {
        if (on)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<Animator>().SetBool("Closed", true);
        }
    }
}
