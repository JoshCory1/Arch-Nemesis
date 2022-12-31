using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmeyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] float waiteTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fallowPath());
    }

    IEnumerator fallowPath()
    {
        foreach(WayPoint wayPoint in path) 
        {
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(waiteTime);
        }
    }
}

