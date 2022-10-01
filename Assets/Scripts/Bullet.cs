using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletSpeed = 15f;
    public float lifetime = 5f;
    public LayerMask solidLayers;
    
    public float distance;
    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }
    // Update is called once per frame
    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector3.up, distance, solidLayers);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<PlayerCollision>().TakeDamage(1);
            }
            DestroyBullet();
        }
        transform.Translate(Vector3.up * bulletSpeed * Time.deltaTime);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
