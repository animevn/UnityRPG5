using Script.Core;
using Script.Movement;
using UnityEngine;

namespace Script.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] private float weaponRange = 1.5f;
        [SerializeField] private float timeBetweenAttack = 1f;
        [SerializeField] private float healthPerHit = 10f;
        // ReSharper disable once InconsistentNaming
        private Transform target;
        private float timeSinceLastAttack = 0;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;
            var isInRange = Vector3.Distance(transform.position, target.position) > weaponRange;
            if (isInRange)
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehavior();
            }

        }

        private void AttackBehavior()
        {
            if (!(timeSinceLastAttack > timeBetweenAttack)) return;
            // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
            GetComponent<Animator>().ResetTrigger("stopAttack");
            // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
            GetComponent<Animator>().SetTrigger("attack");
            timeSinceLastAttack = 0;
        }
        
        private void Hit()
        {
            if (target != null)
            {
                var enemyHealth = target.GetComponent<Health>();
                enemyHealth.TakeDamage(healthPerHit);
                if ((int)enemyHealth.GetHealth() == 0) Cancel();
            }
            
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void Cancel()
        {
            // ReSharper disable once Unity.PreferAddressByIdToGraphicsParams
            GetComponent<Animator>().SetTrigger("stopAttack");
            target = null;
        }

       
    }
}
