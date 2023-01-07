using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    
    TextMeshPro label;
    Vector2Int Coordinates = new Vector2Int();
    WayPoint waypoint;
    void Awake() 
    {
        label = GetComponent<TextMeshPro>();
       // label.enabled = false;
        waypoint = GetComponentInParent<WayPoint>();
        DisplayCoordinates();  
    }
    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }  
        ColorCoordinates();
        ToggleLable();
    }
    void ToggleLable()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void ColorCoordinates()
    {
        if(waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void DisplayCoordinates()    
        {
            Coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
            Coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
            label.text = Coordinates.x + "," + Coordinates.y;
        }
    void UpdateObjectName()
    {
        transform.parent.name = Coordinates.ToString();
    }
}
