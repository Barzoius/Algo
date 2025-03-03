using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuadTree
{
    public Rectangle rect;
    private bool divided;
    public List<Vector3> points = new List<Vector3>();

    private QuadTree NE_Child;
    private QuadTree NW_Child;
    private QuadTree SW_Child;
    private QuadTree SE_Child;

    private const int MAX_POINTS = 1;
    private const int MAX_DEPTH = 4;

    public int depth;

    public LinkedList<string> deque = new LinkedList<string>();

    public QuadTree(Rectangle rect, int depth, LinkedList<string> deque = null)
    {
        this.rect = rect;
        this.divided = false;
        this.depth = depth;
        this.deque = deque ?? new LinkedList<string>();
    }


    public bool InsertPoint(Vector3 point)
    {
        if (!this.rect.isInside(point))
        {
            return false;
        }


        if (this.points.Count < MAX_POINTS)
        {
            deque.AddFirst("Inserted");
            this.points.Add(point);
            return true;
        }


        if (!divided)
        {

            if(this.depth == MAX_DEPTH)
            {
                deque.AddFirst("Tried to devide but reached max deopth");
                this.points.Add(point);
                return true;
            }

            Subdivide();
        }


        return NE_Child.InsertPoint(point) || NW_Child.InsertPoint(point) || SW_Child.InsertPoint(point) || SE_Child.InsertPoint(point);

    }

    private void Subdivide()
    {
        this.divided = true;

        deque.AddFirst("Subdivided");

        float x = rect.centerX;
        float y = rect.centerY;
        float w = rect.width / 2;
        float h = rect.height / 2;

        Rectangle NE_Rect = new Rectangle(x + w / 2, y + h / 2, w, h); 
        NE_Rect.DrawRectangle();
        NE_Child = new QuadTree(NE_Rect, depth + 1, deque);

        Rectangle NW_Rect = new Rectangle(x - w / 2, y + h / 2, w, h);  
        NW_Rect.DrawRectangle();
        NW_Child = new QuadTree(NW_Rect, depth + 1, deque);

        Rectangle SW_Rect = new Rectangle(x - w / 2, y - h / 2, w, h);  
        SW_Rect.DrawRectangle();
        SW_Child = new QuadTree(SW_Rect, depth + 1, deque);

        Rectangle SE_Rect = new Rectangle(x + w / 2, y - h / 2, w, h);  
        SE_Rect.DrawRectangle();
        SE_Child = new QuadTree(SE_Rect, depth + 1, deque);

        // Move existing points into correct children
        for (int i = points.Count - 1; i >= 0; i--)
        {
            Vector3 p = points[i];
            if (NE_Child.InsertPoint(p) || NW_Child.InsertPoint(p) || SW_Child.InsertPoint(p) || SE_Child.InsertPoint(p))
            {
                points.RemoveAt(i);
            }
        }
    }


}
