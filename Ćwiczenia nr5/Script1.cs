using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    public float platformSpeed = 3f;
    private bool isRunning = false;
    public float distance = 6.6f;
    private float leftPos;
    private float rightPos;

    void Start()
    {
        rightPos = transform.position.x + distance;
        leftPos = transform.position.x;
    }

    void FixedUpdate()
    {
        
        if (transform.position.x < leftPos && platformSpeed<0)
        {
            isRunning = false;
        }
        else if (transform.position.x >= rightPos)
        {
            platformSpeed = -platformSpeed;
        }
        if (isRunning)
        {
            Vector3 move = transform.right * platformSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = transform;
            platformSpeed = Mathf.Abs(platformSpeed);
            isRunning = true;
        }
    }
}