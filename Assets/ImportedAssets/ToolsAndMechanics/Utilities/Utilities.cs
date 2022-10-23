using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

namespace ToolsAndMechanics.Utilities
{
    public static class Utilities
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void SetActive(this List<GameObject> list, bool active)
        {
            foreach (var obj in list)
            {
                obj.SetActive(active);
            }
        }

        public static float GetDistance2D(Transform t1, Transform t2)
        {
            return GetDistance2D(t1.position, t2.position);
        }

        public static float GetDistance2D(Vector3 pos1, Vector3 pos2)
        {
            return Vector2.Distance(new Vector2(pos1.x, pos1.z), new Vector2(pos2.x, pos2.z));
        }

        public static bool IsDistanceLess(Vector3 pos1, Vector3 pos2, float distance)
        {
            float sqrDistance = Vector3.SqrMagnitude(pos1 - pos2);
            return sqrDistance <= distance * distance;
        }

        public static bool IsDistanceLess2D(Vector3 pos1, Vector3 pos2, float distance)
        {
            Vector2 p1 = new Vector2(pos1.x, pos1.z);
            Vector2 p2 = new Vector2(pos2.x, pos2.z);
            float sqrDistance = Vector2.SqrMagnitude(p1 - p2);
            return sqrDistance <= distance * distance;
        }

        public static bool IsPointInQuad(Vector3 TL, Vector3 TR, Vector3 BL, Vector3 BR, Vector3 pos)
        {
            return (pos.x > TL.x && pos.z < TL.z) &&
                (pos.x < TR.x && pos.z < TR.z) &&
                (pos.x > BL.x && pos.z > BL.z) &&
                (pos.x < BR.x && pos.z > BR.z);
        }

        public static bool IsPointInCircle(Vector3 pos1, float minRadius, float maxRadius, Vector3 pos2)
        {
            Vector2 p1 = new Vector2(pos1.x, pos1.z);
            Vector2 p2 = new Vector2(pos2.x, pos2.z);
            float sqrDistance = Vector2.SqrMagnitude(p1 - p2);
            return sqrDistance <= maxRadius * maxRadius && sqrDistance >= minRadius * minRadius;
        }
    }
}