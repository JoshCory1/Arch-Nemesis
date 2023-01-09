using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmeyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f, 5f)] float movementSpeed = 1f;
    // Start is called before the first frame update
     void OnEnable()
    {
        findPath();
        returnToStart();
        StartCoroutine(fallowPath());
    }
    void findPath()
    {
        path.Clear();
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");
        foreach(GameObject waypoint in waypoints)
        {
            path.Add(waypoint.GetComponent<WayPoint>());
        }
    }

    void returnToStart()
    {
        transform.position = path[0].transform.position;
    }

    IEnumerator fallowPath()
    {
        foreach(WayPoint wayPoint in path) 
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = wayPoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while(travelPercent < 1)
            {
                travelPercent += Time.deltaTime * movementSpeed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        gameObject.SetActive(false);
    }
}

