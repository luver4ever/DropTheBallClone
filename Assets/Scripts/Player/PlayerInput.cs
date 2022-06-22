using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Vector2 _direction;

    public UnityAction<Vector2> DirectionSetted;

    private void Update()
    {
        var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
            _direction = transform.position - mousePosition;
        if (Input.GetMouseButtonUp(0))
            DirectionSetted?.Invoke(-_direction);
    }
}
