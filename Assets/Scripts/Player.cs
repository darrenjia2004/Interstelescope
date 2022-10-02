using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private float speed = 1f;
    private Vector3 movement = Vector3.zero;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveRotation = Time.deltaTime * rotationSpeed * Input.GetAxisRaw("Horizontal") * 100;
        rb.angularVelocity -= moveRotation;
        Vector3 moveSpeed = new Vector3(0f, 1f, 0) * speed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        
        rb.velocity += (Vector2) (transform.rotation * moveSpeed);
        //transform.position += movement;
    }
    

}
