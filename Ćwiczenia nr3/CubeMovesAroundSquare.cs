using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovesAroundSquare : MonoBehaviour
{

    int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(1 * Time.deltaTime * speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x >= 10 && transform.position.y <= 0)
            transform.Rotate(0, 0, 90);
        else if (transform.position.x >= 10 && transform.position.y >= 10)
            transform.Rotate(0, 0, 90);
        else if (transform.position.x <= 0 && transform.position.y >= 10)
            transform.Rotate(0, 0, 90);
        else if (transform.position.x <=0 && transform.position.y <= 0)
            transform.Rotate(0, 0, 90);

        transform.Translate(1*Time.deltaTime * speed,0, 0);

    }
}
