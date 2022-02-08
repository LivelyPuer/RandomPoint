using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LivelyPuer.RandomPoint;

public class ShowRandomPoints : MonoBehaviour
{
    public int countPoints = 100;
    public List<Vector2> points = new List<Vector2>();
    public PolygonCollider2D polygonCollider2D;
    void Start()
    {
        for (int i = 0; i < countPoints; i++)
        {
            points.Add(RandomPoint.GetRandomPoint(polygonCollider2D));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (points.Count != 0)
        {
            foreach (Vector2 point in points)
            {
                Gizmos.DrawSphere(point, 0.05f);
            }
        }
    }
}
