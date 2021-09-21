using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    public float bounce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ccollided!");
        var point = collision.gameObject.GetComponent<Point>();
        //point.colliding = true;
        var vy = point.oldY - point.y;
        //point.y = 0;

        //point.oldY -= bounce; // point.y + vy;
        var contactPoint = collision.contacts[0].point;
        //point.y = contactPoint.y;
        point.oldY = contactPoint.y - vy * bounce;
    }

}
