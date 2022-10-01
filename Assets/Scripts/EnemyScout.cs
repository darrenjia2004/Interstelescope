using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScout : Enemy
{
    ScoutShoot shooter;

    public override void Start()
    {
        shooter = GetComponent<ScoutShoot>();
        base.Start();
    }
    protected override IEnumerator far()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            shooter.BeginShooting();
        }
    }

}
