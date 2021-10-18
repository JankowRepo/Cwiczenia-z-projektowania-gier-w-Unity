using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoves : MonoBehaviour
{
    int direction = 0;
    int speed = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 10)
            direction = -1;
        else if (transform.position.x <= 0)
            direction = 1;
        transform.Translate(direction * Time.deltaTime * speed, 0, 0);
    }
}
