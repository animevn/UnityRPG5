using System;
using Script.Combat;
using Script.Core;
using UnityEngine;

namespace Script.Controller
{
    // ReSharper disable once InconsistentNaming
    public class AIController : MonoBehaviour
    {
        [SerializeField] private float chaseDistance = 10f;
        private Fighter fighter;
        private Health health;
        private GameObject player;
        

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            player = GameObject.FindWithTag("Player");
        }

        private bool InAttackRange()
        {
            return Vector3.Distance(player.transform.position, transform.position) < chaseDistance;
        }

        private void Update()
        {
            if (health.IsDead()) return;
            if (!InAttackRange() || !fighter.CanAttack(player)) return;
            fighter.Attack(player);
        }
    }
}
