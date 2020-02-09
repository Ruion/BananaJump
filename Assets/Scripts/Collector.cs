using System.Linq;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField]
    private string[] tags;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(tags.Contains(collision.tag))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
