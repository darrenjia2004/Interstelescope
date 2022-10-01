using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruiserShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform[] shootPoint;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        
    }

    private void BeginShooting()
    {
        anim.SetInteger("state", 1);
    }
    private void Shoot(int gun)
    {
        Instantiate(bullet, shootPoint[gun].position, transform.rotation);
    }
    private void EndShooting()
    {
        anim.SetInteger("state", 0);
    }
}
