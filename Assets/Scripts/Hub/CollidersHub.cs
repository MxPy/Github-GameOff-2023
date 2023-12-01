using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidersHub : MonoBehaviour
{
    private PolygonCollider2D polygonCollider;

    void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Vector2[] moonPoints = new Vector2[]
        {
            new Vector2(0, 1), 
            new Vector2(0.5f, 0), 
            new Vector2(1, 1),   
            new Vector2(0, 1),  
        };
        for (int i = 0; i < moonPoints.Length - 1; i++)
        {
            Gizmos.DrawLine(transform.position + (Vector3)moonPoints[i], transform.position + (Vector3)moonPoints[i + 1]);
        }
    }
}
