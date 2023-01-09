using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmeyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints = 0;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    void OnParticleCollision(GameObject other)
    {
        processHit();
    }

    private void processHit()
    {
        takeDamage();
    }

    private void takeDamage()
    {
        currentHitPoints --;
        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
