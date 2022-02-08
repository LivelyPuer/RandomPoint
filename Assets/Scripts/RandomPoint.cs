using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Haze;
using UnityEngine;

namespace LivelyPuer.RandomPoint
{
    public class RandomPoint
    {
        public static Vector2 GetRandomPoint(PolygonCollider2D polygonCollider2D)
        {
            List<Triangulator.Triangle> _triangles = Triangulator.Triangulate(polygonCollider2D.points.ToList());
            Triangulator.Triangle triangle = _triangles[Random.Range(0, _triangles.Count)];
            Vector2 onePoint = Vector2.zero;
            Vector2 twoPoint = Vector2.zero;
            switch (Random.Range(0, 3))
            {
                case 0:
                    onePoint = triangle.a;
                    twoPoint = triangle.b;
                    break;
                case 1:
                    onePoint = triangle.b;
                    twoPoint = triangle.c;
                    break;
                case 2:
                    onePoint = triangle.a;
                    twoPoint = triangle.c;
                    break;
            }

            Vector2 center = triangle.centerOfMass();
            Vector2 randomBetween2Vector = RandomPointBetween2Points(onePoint, twoPoint);
            Vector2 randomPoint = RandomPointBetween2Points(center, randomBetween2Vector);
            return randomPoint;
        }

        private static Vector3 RandomPointBetween2Points(Vector3 start, Vector3 end)
        {
            return (start + Random.Range(0f, 1f) * (end - start));
        }
    }
}