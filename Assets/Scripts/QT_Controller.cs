using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QT_Controller : MonoBehaviour
{
    public GameObject pointPrefab;
    private int numPoints = 0;

    private Rectangle rootSQ;
    private QuadTree qt;

    void Start()
    {
        rootSQ = new Rectangle(8, 8, 16, 16);
        qt = new QuadTree(rootSQ, 0);

        rootSQ.DrawRectangle();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = GetMouseWorldPosition();
            worldPos.z = 0;


            bool inserted = qt.InsertPoint(worldPos);
            if (!inserted)
            {
                Debug.Log("Point was outside the bounds of the QuadTree.");
            }
            else
            {
                GameObject point = Instantiate(pointPrefab, worldPos, Quaternion.identity);
                numPoints++;
            }
        }

        //if (Input.GetMouseButtonDown(1))
        //{
        //    qt.ConstructQuadTree(); 
        //}
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
