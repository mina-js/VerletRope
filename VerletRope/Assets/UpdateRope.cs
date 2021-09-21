using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRope : MonoBehaviour
{
    Point[] points;
    Stick[] sticks;

    public float width;
    public float height;

    public float gravity;
    public float friction;

    // Start is called before the first frame update
    void Start()
    {
        points = GetComponentsInChildren<Point>();
        sticks = GetComponentsInChildren<Stick>();
    }

    void UpdatePoints()
    {
        foreach (var point in points)
        {
            if (!point.isFixed)
            {
                var vx = (point.x - point.oldX) * friction;
                var vy = (point.y - point.oldY) * friction;

                point.oldX = point.x;
                point.oldY = point.y;

                point.x += vx;
                point.y += vy;
                point.y += gravity;
            }
        }
    }

    void UpdateSticks()
    {
        for(int i = 0; i < 3; i++)
        {
            foreach (var stick in sticks)
            {
                var dx = stick.p1.x - stick.p2.x;
                var dy = stick.p1.y - stick.p2.y;

                var distance = Mathf.Sqrt(dx * dx + dy * dy);
                var difference = stick.length - distance;
                var percent = difference / distance / 2;
                var offsetX = dx * percent;
                var offsetY = dy * percent;

                if (!stick.p1.isFixed)
                {
                    stick.p1.x += offsetX;
                    stick.p1.y += offsetY;
                }

                if (!stick.p2.isFixed)
                {
                    stick.p2.x -= offsetX;
                    stick.p2.y -= offsetY;
                }

            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdatePoints();
        UpdateSticks();
    }
}
