using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagetLocator : MonoBehaviour
{
    [SerializeField] Transform Wepon;
    [SerializeField] ParticleSystem ProjectileParticals;
    [SerializeField] float range = 15f;
    [SerializeField] Transform Target;
   
    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWepon();   
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;
        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        Target = closestTarget;
    }
    private void AimWepon()
    {
        float targetDistance = Vector3.Distance(transform.position, Target.position);
        transform.LookAt(Target);
        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }
    void Attack(bool IsActive)
    {
        var emissonModule = ProjectileParticals.emission;
    }
}
