using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro lable;
    Vector2Int Coordinates = new Vector2Int();
    void Awake() 
    {
        lable = GetComponent<TextMeshPro>();
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
    }

    void DisplayCoordinates()
    {
        Coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        Coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        lable.text = Coordinates.x + "," + Coordinates.y;
    }
    void UpdateObjectName()
    {
        transform.parent.name = Coordinates.ToString();
    }
}
