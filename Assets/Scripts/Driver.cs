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
    
    // Delivery
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);

    private SpriteRenderer _sp;
    private bool hasPackage = false;
    
    
    // Main Methods
    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerMove();
    }

    // User Methods
    void PlayerMove()
    {
        var steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        var moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, -steerAmount);
        transform.Translate(0f, moveAmount, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Package Pickup");
            Destroy(collidedObject, 1f);
            hasPackage = true;
            _sp.color = hasPackageColor;

            // Speed Change
            moveSpeed = slowSpeed;
        }
        else if (collidedObject.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Package Delivered");
            _sp.color = noPackageColor;
            hasPackage = false;

            // Speed Change
            moveSpeed = normalSpeed;
        }
        else if (CompareTag("Gasoline"))
        {
            Debug.Log("Gasoline Restored");
            Destroy(collidedObject, 0.5f);

            // Speed Change
            moveSpeed = highSpeed;
        }
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Objects have collided");
        Debug.Log("Gasoline Wasted !!!!");
        moveSpeed = normalSpeed;
    }
} // Class