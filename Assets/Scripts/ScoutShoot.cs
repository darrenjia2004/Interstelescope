using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform[] shootPoint;
    private Animator anim;
    private void Start()
    {

        anim = GetComponent<Animator>();
        print(anim);
    }

    private void Update()
    {
        
    }

    public void BeginShooting()
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
