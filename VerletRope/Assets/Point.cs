using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public float x;
    public float y;
    public float oldX;
    public float oldY;

    public float directionX = 0.1f;
    public float directionY = 0.1f;

    public bool isFixed = false;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        oldX = x + directionX;
        oldY = y + directionY;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFixed) transform.position = new Vector2(x, y);
    }
}
