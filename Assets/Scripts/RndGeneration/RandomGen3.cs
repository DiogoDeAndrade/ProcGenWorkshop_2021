using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGen3 : MonoBehaviour
{
    public int seed1;
    public int seed2;

    void Start()
    {
        var rndGen1 = new System.Random(seed1);
        var rndGen2 = new System.Random(seed2);

        for (int i = 0; i < 10; i++)
        {
            int r1 = rndGen1.Range(0, 100);
            Debug.Log("R1=" + r1);
            int r2 = rndGen2.Range(0, 100);
            Debug.Log("R2=" + r2);
        }
    }
}
