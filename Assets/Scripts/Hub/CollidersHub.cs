using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersHub : MonoBehaviour
{
    private PolygonCollider2D polygonCollider;

    void Start()
    {
        // Get or add PolygonCollider2D component
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    void OnDrawGizmos()
    {
        // Draw moon shape using Gizmos
        Gizmos.color = Color.green;

        Vector2[] moonPoints = new Vector2[]
        {
            new Vector2(0, 1),   // Top
            new Vector2(0.5f, 0), // Right tip
            new Vector2(1, 1),   // Top-right
            new Vector2(0, 1),   // Top (closing the shape)
        };

        // Draw the moon shape using Gizmos
        for (int i = 0; i < moonPoints.Length - 1; i++)
        {
            Gizmos.DrawLine(transform.position + (Vector3)moonPoints[i], transform.position + (Vector3)moonPoints[i + 1]);
        }
    }
}
