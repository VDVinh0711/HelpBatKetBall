using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.05f;

        var points = new Vector3[2];
        points[0] = Camera.main.ScreenToWorldPoint(new Vector3(ScreenInfo.Width / 2, 0, 10));
        points[1] = Camera.main.ScreenToWorldPoint(new Vector3(ScreenInfo.Width / 2, ScreenInfo.Height, 10));

        lineRenderer.positionCount = points.Length;
        lineRenderer.SetPositions(points);
    }
}
