using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed;
    [SerializeField] private float moveSpeed;

    [SerializeField] private float slowSpeed;
    [SerializeField] private float highSpeed;
    [SerializeField] private float normalSpeed;

    private bool hasGasoline = false;

    private void Update()
    {
        PlayerMove();
    }


    void PlayerMove()
    {
        var steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        var moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, -steerAmount);
        transform.Translate(0f, moveAmount, 0f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Gasoline") && !hasGasoline)
        {
            Debug.Log("Gasoline Restored");
            moveSpeed = highSpeed;
            Destroy(col.gameObject, 0.5f);
            hasGasoline = true;
        }

        else if (col.CompareTag("Package") && !hasGasoline)
        {
            moveSpeed = slowSpeed;
            Debug.Log("Slow Speed !!!!");
        }
        else if (col.CompareTag("Customer") && !hasGasoline)
        {
            moveSpeed = normalSpeed;
            Debug.Log("Normal Speed !!!!");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Environment") && hasGasoline)
        {
            Debug.Log("Gasoline Wasted by Environment !!!!");
            moveSpeed = normalSpeed;
            Debug.Log("Normal Speed - Environment !!!!");
            Debug.Log("Objects have collided");
            hasGasoline = false;
        }
    }
} // Class