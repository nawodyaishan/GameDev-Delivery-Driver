using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed;
    [SerializeField] private float moveSpeed;

    void Start()
    {
    }

    private void Update()
    {
        var steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        var moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, -steerAmount);
        transform.Translate(0f, moveAmount, 0f);
    }
} // Class