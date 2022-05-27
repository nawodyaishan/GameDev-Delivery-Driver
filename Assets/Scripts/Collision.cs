using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Objects have collided");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("You Went Through me");
    }
}
