using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleDrag : MonoBehaviour
{
    Vector2 point;
    float x;
    float y;
    //float z;

    //void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //    OnMouseDrag();
    //    }
    //}

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
}
