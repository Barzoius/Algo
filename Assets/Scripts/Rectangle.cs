using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle
{
    public Color lineColor = Color.white;
    public float lineWidth = 0.05f;

    public float centerX;
    public float centerY;
    public float width;
    public float height;


    public Rectangle(float X, float Y, float w, float h)
    {
        this.centerX = X;
        this.centerY = Y;
        this.width = w;
        this.height = h;
    }

    public bool isInside(Vector3 point)
    {

        float left = centerX - width / 2;
        float right = centerX + width / 2;
        float bottom = centerY - height / 2;
        float top = centerY + height / 2;


        return (point.x >= left && point.x <= right && point.y >= bottom && point.y <= top);

    }


    public void DrawRectangle()
    {

        Vector3 botL = new Vector3(centerX - width / 2, centerY - height / 2, 0);
        Vector3 botR = new Vector3(centerX + width / 2, centerY - height / 2, 0);
        Vector3 topL = new Vector3(centerX - width / 2, centerY + height / 2, 0);
        Vector3 topR = new Vector3(centerX + width / 2, centerY + height / 2, 0);


        GameObject rootLine = new GameObject("RootSquare");
        LineRenderer lineRenderer = rootLine.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 5;
        lineRenderer.loop = true;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;


        Material lineMat = new Material(Shader.Find("Unlit/Color"));
        lineMat.color = lineColor;
        lineRenderer.material = lineMat;


        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;

        Vector3[] squarePoints = {
            botL,
            botR,
            topR,
            topL,
            botL
        };

        lineRenderer.SetPositions(squarePoints);
    }
}
