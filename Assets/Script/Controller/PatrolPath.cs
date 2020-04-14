using System;
using UnityEngine;

namespace Script.Controller
{
    public class PatrolPath: MonoBehaviour
    {
        [SerializeField] private float waypointRadius = 0.2f;
        
        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(GetWaypoint(i), waypointRadius);
                if (i < transform.childCount - 1)
                {
                    Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(i + 1));
                }
                else
                {
                    Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(0));
                }
            }
        }

        private Vector3 GetWaypoint(int i)
        {
            return transform.GetChild(i).position;
        }
    }
}