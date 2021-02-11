using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGen1 : MonoBehaviour
{
    public int seed;

    void Start()
    {
        Random.InitState(seed);
        for (int i = 0; i < 10; i++)
        {
            int r = Random.Range(0, 100);
            Debug.Log(r);
        }
    }
}
