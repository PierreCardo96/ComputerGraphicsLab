using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
    [SerializeField]
    GameObject destinationObject;

    [SerializeField]
    GameObject destinationPrefab;

    [SerializeField]
    Transform playerRadarPoint;

    [SerializeField]
    Text distanceText;

    [SerializeField]
    float radarRadius = 8f;

    private GameObject destinationRadarPoint;

    // Start is called before the first frame update
    void Start()
    {
        InitializeRadarPoints();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRadarPoints();
    }

    private void InitializeRadarPoints()
    {
        destinationRadarPoint = Instantiate(destinationPrefab, destinationObject.transform.position, Quaternion.identity);
    }

    private void UpdateRadarPoints()
    {
        float distance = Vector3.Distance(destinationObject.transform.position, transform.position);
        distanceText.text = Math.Round(distance, 0).ToString();

        if (distance > radarRadius)
        {
            DrawPointOnBorder();
        }
        else
        {
            DrawPointInsideRadar();
        }
    }

    private void DrawPointOnBorder()
    {
        playerRadarPoint.LookAt(destinationObject.transform);
        destinationRadarPoint.transform.position = playerRadarPoint.transform.position + radarRadius * playerRadarPoint.forward;

    }

    private void DrawPointInsideRadar()
    {
        destinationRadarPoint.transform.position = destinationObject.transform.position;
    }

}
