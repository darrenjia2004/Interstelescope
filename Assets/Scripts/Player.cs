using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private float dragRatio = 0.8f;
    [SerializeField] private float speed = .01f;
    private Vector3 movement = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        loseVelocity();
        float moveRotation = Time.deltaTime * rotationSpeed * Input.GetAxisRaw("Horizontal");
        transform.Rotate(new Vector3(0, 0, -moveRotation));
        Vector3 moveSpeed = new Vector3(0f, 1f, 0) * speed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        movement += transform.rotation * moveSpeed;
        Debug.Log(movement);
        transform.position += movement;
    }

    private void loseVelocity()
    {
        movement *= Mathf.Pow(dragRatio, Time.deltaTime);    
    }
}
