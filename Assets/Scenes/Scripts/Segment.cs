using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment
{
    public Segment parent;
    public Segment child;

    Point root;
    Point tail;

    public float x;
    public float y;

    public float angle;

    float selfAngle;

    float len;

    public Segment(float x, float y, float len, float angle)
    {
        this.x = x;
        this.y = y;
        this.len = len;
        this.angle = angle;
        selfAngle = angle;
        root = new Point(x, y);
        CalculateTail();
        parent = null;
    }

    public Segment(Segment parent, float len, float angle)
    {
        this.parent = parent;
        root = this.parent.tail.Copy;
        this.len = len;
        this.angle = angle;
        selfAngle = angle;
        CalculateTail();
    }

    void CalculateTail() {
        float dx = len * Mathf.Cos(angle);
        float dy = len * Mathf.Sin(angle);

        tail = new Point(root.x + dx, root.y + dy);
    }

    public Vector3 GetRoot() {
        return new Vector3(root.x, root.y);
    }


    public Vector3 GetTail()
    {
        return new Vector3(tail.x, tail.y);
    }

    public void Draw() {
        Gizmos.DrawLine(GetRoot(), GetTail());
    }
    float xOff = Random.Range(0, 100);
    public void Wiggle(){    
        selfAngle = Mathf.PerlinNoise(xOff, xOff);
        xOff += 0.01f;
        //selfAngle += 0.01f;
    }

    public void Update() {
        angle = selfAngle;
        if (parent != null)
        {
            root = parent.tail.Copy;
            angle += parent.angle;
        }
        CalculateTail();
    }

    public float GetAngle() {
        return angle + (parent != null ? parent.GetAngle() : 0);
    }
}

public struct Point
{
	public float x;
	public float y;
	public Point(float x, float y)
	{
		this.x = x;
		this.y = y;
	}

    public Point Copy{
        get {
            return new Point(x, y);
        }
    }
}
