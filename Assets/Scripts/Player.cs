using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool initialPush;

    [SerializeField]
    Rigidbody2D rb;
    int pushCount;
    bool playerDied;

    public float normalPush = 10f;
    public float extraPush = 14f;
    public float moveSpeed = 5f;


    // Update is called once per frame
    void Update()
    {
        if (playerDied) return;

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerDied) return;

        if(collision.tag == "ExtraPush")
        {
            if(!initialPush)
            {
                initialPush = true;

                PushUp(extraPush);

                collision.gameObject.SetActive(false);

            }
        }

        if (collision.tag == "ExtraPush")
        {
                PushUp(extraPush);

                collision.gameObject.SetActive(false);
        }

        if (collision.tag == "NormalPush")
        {
                PushUp(normalPush);

                collision.gameObject.SetActive(false);
        }

        if(collision.tag == "Enemy")
        {
            playerDied = true;

            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void PushUp(float yForce)
    {
        rb.velocity = new Vector2(rb.velocity.x, yForce);

        pushCount++;

        if(pushCount == 2)
        {
            PlatformSpawner.instance.SpawnPlatforms();
            pushCount = 0;
        }
    }
}
