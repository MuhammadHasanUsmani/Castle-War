using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public Draggable LastDragged => _lastDragged;
    private bool _isDragActive = false;
    private Vector2 _screenPosition;
    private Vector3 _worldPosition;
    private Draggable _lastDragged;

    
    // Start is called before the first frame update
    void Awake()
    {
        DragController[] controllers = FindObjectsOfType<DragController>();
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDragActive)
        {
            if (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
            {
                print("up");
                Drop();
                return;
            }
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);
            print("drag");
        }
        else if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
            
        }
        else
        {
            return;
        }
        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _lastDragged = draggable;
                    InitDrag();
                }
            }
        }

    }

    void InitDrag()
    {
        _lastDragged.LastPosition = _lastDragged.transform.position;
        UpdateDragStatus(true);
    }
    void Drag()
    {
        _lastDragged.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
        
    }
    void Drop()
    {
        UpdateDragStatus(false);
    }

    void UpdateDragStatus(bool IsDragging)
    {
        _isDragActive = _lastDragged.IsDragging = IsDragging;
        _lastDragged.gameObject.layer = IsDragging ? Layer.Dragging : Layer.Default;
        //if (IsDragging)
        //{
        //    gameObject.layer = Layer.Dragging;
        //}
        //else
        //{
        //    gameObject.layer = Layer.Default;
        //}
    }
}
