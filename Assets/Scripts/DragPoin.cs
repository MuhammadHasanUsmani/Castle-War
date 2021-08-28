using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPoin : MonoBehaviour
{
    Vector2 startPoint;
    private bool mouseUp = true;

    private void Start()
    {
        startPoint = this.transform.position;
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (mouseUp)
        {
            if (other.gameObject.tag == "Box")
            {
                print("Collision");
            }

        }
    }
    private void OnMouseUp()
    {
        mouseUp = true;
    }

    private void OnMouseDown()
    {
        mouseUp = false;
    }

}
