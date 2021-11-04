using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random=UnityEngine.Random;

public class Zadanie1 : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    public int numberOfCubes=10;
    // obiekt do generowania
    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;
    public Material mat5;
    public GameObject block;

    void Start()
    {
        Vector3 Max = GetComponent<MeshRenderer>().bounds.max;
        Vector3 Min = GetComponent<MeshRenderer>().bounds.min;

        float maxX = Max.x;
        float minX = Min.x;
        float maxZ = Max.z;
        float minZ = Min.z;

        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<int> pozycje_x = new List<int>(Enumerable.Range(Convert.ToInt32(minX + maxX), Convert.ToInt32(maxX + maxX)).OrderBy(x => Guid.NewGuid()).Take(10));
        List<int> pozycje_z = new List<int>(Enumerable.Range(Convert.ToInt32(minZ + maxZ), Convert.ToInt32(maxZ + maxZ)).OrderBy(x => Guid.NewGuid()).Take(10));


        for (int i = 0; i < numberOfCubes; i++)
        {
            
            this.positions.Add(new Vector3(pozycje_x[i]-4.5f, 0.5f, pozycje_z[i]-4.5f));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {
        
        
        
    }

    IEnumerator GenerujObiekt()
    {
        List<Material> list = new List<Material>() { mat1, mat2, mat3, mat4, mat5 };
        Debug.Log("wywołano coroutine");
        foreach (Vector3 pos in positions)
        {
            block.GetComponent<MeshRenderer>().material = list[Random.Range(0, 5)];
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}
