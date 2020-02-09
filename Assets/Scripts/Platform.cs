using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private GameObject oneBanana, bananas;

    [SerializeField]
    private Transform spawnPoint;

    private void OnEnable()
    {
        if(Random.Range(0,10) > 3)
        {
            Instantiate(oneBanana, spawnPoint);
        }
        else
        {
            Instantiate(bananas, spawnPoint);
        }
    }
}
