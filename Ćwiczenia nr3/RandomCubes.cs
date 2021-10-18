using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPlane;
    public GameObject myCube;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        
        Instantiate(myPlane, new Vector3(4.5f, -0.5f, 4.5f), Quaternion.identity);
        var rand = new System.Random();
        List<int> listOfCubeFields = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            var field = rand.Next(100);
            if (listOfCubeFields.Contains(field))
                i--;
            else
            {
                listOfCubeFields.Add(field);
                Instantiate(myCube, new Vector3(field/10, 0, field%10), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
