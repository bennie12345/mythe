using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour {
    //restrict the players movement to the screenbounds
    [SerializeField]private Camera _mainCamera;
    private float minX, maxX, minY, maxY;
    private float _playerBoundsHorizontal;
    private float _playerBoundsVertical;
    
    private PolygonCollider2D _polygonCollider2D;

    void Start()
    {
        //setup the bounds
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
        _playerBoundsHorizontal = _polygonCollider2D.bounds.extents.x;
        _playerBoundsVertical = _polygonCollider2D.bounds.extents.y;

        float camDistance = Vector3.Distance(transform.position, _mainCamera.transform.position);
        Vector2 bottomCorner = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = _mainCamera.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x + _playerBoundsHorizontal;
        maxX = topCorner.x - _playerBoundsVertical;
        minY = bottomCorner.y + _playerBoundsHorizontal;
        maxY = topCorner.y - _playerBoundsVertical;
    }

    void Update()
    {
        // Get current position
        Vector3 pos = transform.position;

        // Horizontal contraint
        if (pos.x < minX) pos.x = minX;
        if (pos.x > maxX) pos.x = maxX;

        // Vertical contraint
        if (pos.y < minY) pos.y = minY;
        if (pos.y > maxY) pos.y = maxY;

        // Update position
        transform.position = pos;
    }
}
