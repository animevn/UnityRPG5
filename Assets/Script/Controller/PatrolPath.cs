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
                Gizmos.DrawSphere(transform.GetChild(i).position, waypointRadius);  
            }
        }
    }
}