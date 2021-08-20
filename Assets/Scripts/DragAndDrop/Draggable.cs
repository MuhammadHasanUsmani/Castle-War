using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool IsDragging;
    public Vector3 LastPosition;
    //public Vector3 firstPosition;
    private Collider2D _collider;
    private DragController _dragController;
    private float _movmentTime = 15f;
    Vector2 initialPosition;
    private System.Nullable<Vector3> _movmentDestination;
    private void Start()
    {
        initialPosition = transform.position;
        _collider = GetComponent<Collider2D>();
        _dragController = FindObjectOfType<DragController>();
    }
    private void FixedUpdate()
    {
        if (_movmentDestination.HasValue)
        {
            if (IsDragging)
            {
                _movmentDestination = null;
                return;
            }
            if (transform.position ==_movmentDestination)
            {
                gameObject.layer = Layer.Default;
                _movmentDestination = null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, _movmentDestination.Value, _movmentTime * Time.fixedDeltaTime);
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, _movmentTime * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Draggable collidedDraggable = other.GetComponent<Draggable>();

        if (collidedDraggable != null && _dragController.LastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = other.Distance(_collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
        }
        if (other.CompareTag("ValidDrop"))
        {
            _movmentDestination = other.transform.position;
        }
        //else if (other.CompareTag("InvalidDrop"))
        //{
        //    _movmentDestination = LastPosition;
        //}
        //else
        //{
        //    _movmentDestination = firstPosition;
        //}
    }
}
