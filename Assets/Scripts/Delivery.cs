using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private bool hasPackage = false;

    [SerializeField] private GameObject packagePrefab;

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Objects have collided");
    }

    private void OnTriggerEnter2D(Collider2D collidedObject)
    {
        if (collidedObject.CompareTag("Package"))
        {
            Debug.Log("Package Acquired");
            Destroy(collidedObject.GameObject(), 1f);
        }
        else if (collidedObject.CompareTag("Customer"))
        {
            Debug.Log("Package Acquired");
            Instantiate(packagePrefab, collidedObject.transform.position + new Vector3(1, 1, 1), Quaternion.identity);
            Destroy(collidedObject.GameObject(), 2f);
        }
    }
}