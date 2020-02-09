using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BGSpawner : MonoBehaviour
{
    private GameObject[] bgs;
    private float height;
    private float highestY;

    // Start is called before the first frame update
    void Start()
    {
        bgs = GameObject.FindGameObjectsWithTag("Background");

        height = bgs[0].GetComponent<BoxCollider2D>().bounds.size.y;

        highestY = bgs.OrderByDescending(x => x.transform.position.y).First().transform.position.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Background")
        {
            // if target is higher than highest point, take one deactivated bg to the top and activate it
            if(collision.transform.position.y >= highestY)
            {
                Vector3 temp = collision.transform.position;

                for (int i = 0; i < bgs.Length; i++)
                {
                    if(!bgs[i].activeInHierarchy)
                    {
                        // take the bg to the top
                        temp.y += height;
                        bgs[i].transform.position = temp;
                        bgs[i].SetActive(true);

                        highestY += height;
                    }
                }
            }
        }
    }

}
