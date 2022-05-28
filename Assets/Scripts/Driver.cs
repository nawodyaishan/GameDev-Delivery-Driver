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

    void Start()
    {
    }

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
        if (CompareTag("Gasoline"))
        {
            Debug.Log("Gasoline Restored");
            moveSpeed = highSpeed;
            Destroy(col, 0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Gasoline Wasted !!!!");
        moveSpeed = normalSpeed;
    }

    void PlayerSlow()
    {
        
    }

} // Class








