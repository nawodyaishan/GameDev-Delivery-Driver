using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);

    private SpriteRenderer _sp;

    [SerializeField] private bool hasPackage = false;
    [SerializeField] private GameObject packagePrefab;

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Objects have collided");
    }

    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Package Pickup");
            Destroy(collidedObject.GameObject(), 1f);
            hasPackage = true;
        }
        else if (collidedObject.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Package Delivered");
            // Destroy(collidedObject.GameObject(), 2f);
            hasPackage = false;
            //collidedObject.GetComponent<Transform>().position
        }
    }

    private void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
    }
}