using System;
using Script.Combat;
using UnityEngine;

namespace Script.Controller
{
    // ReSharper disable once InconsistentNaming
    public class AIController : MonoBehaviour
    {
        [SerializeField] private float chaseDistance = 10f;
        private Fighter fighter;
        private GameObject player;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
        }

        private bool InAttackRange()
        {
            return Vector3.Distance(player.transform.position, transform.position) < chaseDistance;
        }

        private void Update()
        {
            if (InAttackRange() && fighter.CanAttack(player))
            {
                print("Start attact");
                fighter.Attack(player);
            }
        }
    }
}
