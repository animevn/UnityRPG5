﻿using System;
using Script.Combat;
using Script.Core;
 using Script.Movement;
 using UnityEngine;

namespace Script.Controller
{
    // ReSharper disable once InconsistentNaming
    public class AIController : MonoBehaviour
    {
        [SerializeField] private float chaseDistance = 10f;
        [SerializeField] private float suspisionTime = 2f;
        private Fighter fighter;
        private Health health;
        private Mover mover;
        private GameObject player;
        private Vector3 guardPosition;
        private float timeSinceLastSawPlayer;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            mover = GetComponent<Mover>();
            player = GameObject.FindWithTag("Player");
            guardPosition = transform.position;
        }

        private bool InAttackRange()
        {
            return Vector3.Distance(player.transform.position, transform.position) < chaseDistance;
        }

        private void Update()
        {
            if (health.IsDead()) return;
            if (InAttackRange() && fighter.CanAttack(player))
            {
                timeSinceLastSawPlayer = 0;
                fighter.Attack(player);
            }
            else if (timeSinceLastSawPlayer < suspisionTime)
            {
                GetComponent<ActionScheduler>().CancelAction();
            }
            else
            {
                fighter.Cancel();
                mover.StartToMoveTo(guardPosition);
            }
            timeSinceLastSawPlayer += Time.deltaTime;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
