using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script2 : MonoBehaviour
{
    public float platformSpeed = 1.5f;
    private bool isRunning = false;
    public float distance = 2f;
    private float leftPos;
    private float rightPos;
    // Start is called before the first frame update
    void Start()
    {
        rightPos = transform.position.z + distance;
        leftPos = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < leftPos && platformSpeed < 0)
        {
            isRunning = false;
        }
        else if (transform.position.z >= rightPos)
        {
            platformSpeed = -platformSpeed;
        }
        if (isRunning)
        {
            Vector3 move = -transform.forward * platformSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            platformSpeed = Mathf.Abs(platformSpeed);
            isRunning = true;
        }
    }
}
