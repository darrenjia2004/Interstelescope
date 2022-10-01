using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected GameObject player;
    protected Rigidbody2D rb;
    [SerializeField] protected float rotationSpeed = 60f;
    [SerializeField] protected float speed = 4f;
    [SerializeField] protected float maxVelocity = 3f;

    [SerializeField] float closeDist = -1;

    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GameObject.Find("PlayerShip");
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(findPlayer());
        StartCoroutine(far());
    }

    IEnumerator findPlayer()
    {
        while (Vector3.Distance(transform.position, player.transform.position) > closeDist)
        {
            Vector3 direction = player.transform.position - transform.position;
            rb.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            rb.velocity = (transform.rotation * new Vector3(0f, 1f, 0) * Mathf.Min(rb.velocity.magnitude + speed * Time.deltaTime, maxVelocity));
            yield return null;
        }
        StartCoroutine(close());
    }

    protected virtual IEnumerator far()
    {
        
        yield return null;
    }

    protected virtual IEnumerator close()
    {

        yield return null;
    }
}
