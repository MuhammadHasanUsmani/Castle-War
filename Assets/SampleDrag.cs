using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleDrag : MonoBehaviour
{
    Vector2 lastPosition;
    bool isActive = false;
    Collider2D lastObject;
    Vector2 point;
    float x;
    float y;
    public float speed = 15f;

    private void Start()
    {
        lastPosition = transform.position;

    }
    void OnMouseDrag()
    {
        print("hi");
        x = Input.mousePosition.x;
        y = Input.mousePosition.y;
        //z = gameObject.transform.position.z;

        point = Camera.main.ScreenToWorldPoint(new Vector2(x, y));
        gameObject.transform.position = point;

        //Debug.Log("x: " + point.x + "   y: " + point.y);
    }
    private void OnMouseUp()
    {
        if (isActive)
        {
            transform.position = Vector3.Lerp(transform.position, lastObject.transform.position, speed * Time.deltaTime);
            lastPosition =transform.position = lastObject.transform.position;
            
        }else
        {
            transform.position = lastPosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isActive = true;
        lastObject = collision;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (lastObject == collision)
        { isActive = false; lastObject = null; }
    }
}
