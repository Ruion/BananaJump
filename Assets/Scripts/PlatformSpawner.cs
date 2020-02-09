using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static PlatformSpawner instance;

    [SerializeField]
    private GameObject leftPlatform, rightPlatform;
    
    [SerializeField]
    private Transform platformParent;
   
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private float enemyY;

    [SerializeField]
    private float leftXMin = -4.4f, leftXMax = -2.8f, rightXMin = 4.4f, rightXMax = 2.8f,
        yThreshold = 2.6f, enemyXMin, enemyXMax;

    private float lastY;

    private int platformSpawned;

    public int firstSpawnCount = 8;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        lastY = transform.position.y;

        SpawnPlatforms();
    }

    public void SpawnPlatforms()
    {
        Vector3 tempPos = transform.position;

        for (int i = 0; i < firstSpawnCount; i++)
        {
            tempPos.y = lastY;

            if (platformSpawned % 2 == 0)
            {
                tempPos.x = Random.Range(leftXMin, leftXMax);
                Instantiate(leftPlatform, tempPos, Quaternion.identity, platformParent);
            }
            else 
            {
                tempPos.x = Random.Range(rightXMin, rightXMax);
                Instantiate(rightPlatform, tempPos, Quaternion.identity, platformParent);
            }
            platformSpawned++;
            lastY += yThreshold;
        }

        if (Random.Range(0, 3) == 1)
            SpawnEnemy();
        

    }

    void SpawnEnemy()
    {
        Vector3 temp = transform.position;
        temp.x = Random.Range(enemyXMin, enemyXMax);
        temp.y += enemyY;

        Instantiate(enemy, temp, Quaternion.identity, platformParent);
    }
}
