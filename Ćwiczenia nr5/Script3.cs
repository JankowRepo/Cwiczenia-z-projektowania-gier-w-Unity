using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script3 : MonoBehaviour
{
    public GameObject[] ways;
    int currentPlace = 0;
    float isNearPoint = 1;
    public float speed = 4;
    bool platformRunning = false;
    bool platformMoveToward = false;
    bool platfromMoveBack = false;
    Transform oldPar;
    Vector3 start_poz;
    void Start()
    {

        start_poz = transform.position;
    }
    //nie używać Update!
    void FixedUpdate()
    {
        if (platformRunning == true || platformMoveToward == true || platfromMoveBack == true)
        {
            if (Vector3.Distance(ways[currentPlace].transform.position, transform.position) < isNearPoint)
            {
                if (platformMoveToward == true)
                {
                    currentPlace++;
                    if (currentPlace >= ways.Length)
                    {
                        platfromMoveBack = true;
                        platformMoveToward = false;
                        currentPlace--;
                    }
                }
                //powrót
                else if (platfromMoveBack == true)
                {

                    if (currentPlace > 0)
                    {
                        currentPlace--;
                    }
                    else if (currentPlace == 0)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, start_poz, Time.deltaTime * speed);
                    }
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, ways[currentPlace].transform.position, Time.deltaTime * speed);
            Debug.Log(currentPlace);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Gracz wszedł na platformę");
            if (other.gameObject.transform.parent!= transform)
                oldPar = other.gameObject.transform.parent;
            other.gameObject.transform.parent = transform;
            platformRunning = true;
            platformMoveToward = true;
            platfromMoveBack = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Gracz wyszedł");
            other.gameObject.transform.parent = oldPar;
            platformRunning = false;
        }
    }
}

