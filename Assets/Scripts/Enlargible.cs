using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enlargible : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] int enlargesLeft = 1;
    private float scale = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Enlarge(Vector3 center)
    {
        if (--enlargesLeft >= 0)
        {
            float expandFactor = Mathf.Pow(scale, 1f / 60f);
            Vector3 moveFactor = (scale - 1) * (transform.position - center) / 60f;
            for (int i = 0; i < 60; i++)
            {
                transform.localScale *= expandFactor;
                transform.position += moveFactor;
                yield return new WaitForSeconds(0.02f);
            }
        }
    }
}
