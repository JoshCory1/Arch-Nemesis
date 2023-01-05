using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagetLocator : MonoBehaviour
{
    [SerializeField] Transform Wepon;
    [SerializeField] Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        Target = FindObjectOfType<EnmeyMover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWepon();   
    }

    private void AimWepon()
    {
        transform.LookAt(Target);
    }
}
