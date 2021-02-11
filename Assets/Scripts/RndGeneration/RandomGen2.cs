using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGen2 : MonoBehaviour
{
    public int seed1;
    public int seed2;

    void Start()
    {
        var rndGen1 = new System.Random(seed1);
        var rndGen2 = new System.Random(seed2);

        for (int i = 0; i < 10; i++)
        {
            double r1 = rndGen1.NextDouble();
            Debug.Log("R1=" + r1);
            double r2 = rndGen2.NextDouble();
            Debug.Log("R2=" + r2);
        }
    }
}
