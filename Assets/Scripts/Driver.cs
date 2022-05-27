using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 1f;
    [SerializeField] private float moveSpeed = 0.01f;

    void Start()
    {
    }

    void Update()
    {
        transform.Rotate(0f, 0f, steerSpeed);
        transform.Translate(0f, moveSpeed, 0f);
    }
} // Class