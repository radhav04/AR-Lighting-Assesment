using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    // Start is called before the first frame update
    public float radius;
    public float circleThickness = 0.02f;

    private void Start()
    {
        var boundary = new GameObject { name = "GeoSample Boundary" };
        var lineRenderer = boundary.AddComponent<LineRenderer>();

        var circleSegments = 360;
        lineRenderer.material.color = new Color(99/255, 131/255, 216/255); // color from figma #6992D8
        lineRenderer.useWorldSpace = false; // lines render around world origin
        lineRenderer.startWidth = circleThickness; // consistent circle thickness
        lineRenderer.endWidth = circleThickness; // consistent circle thickness
        lineRenderer.positionCount = circleSegments + 1; // closes the circle

        var pointCount = circleSegments + 1;
        var points = new Vector3[pointCount];

        for (int i = 0; i < pointCount; ++i)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / circleSegments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius, 0, Mathf.Cos(rad) * radius);
        }

        lineRenderer.SetPositions(points);
    }

}