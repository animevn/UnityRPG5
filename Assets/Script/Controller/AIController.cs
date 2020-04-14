using UnityEngine;

namespace Script.Controller
{
    // ReSharper disable once InconsistentNaming
    public class AIController : MonoBehaviour
    {
        [SerializeField] private float chaseDistance = 10f;

        private float DistanceToPlayer()
        {
            var player = GameObject.FindWithTag("Player");
            return Vector3.Distance(player.transform.position, transform.position);
        }

        private void Update()
        {
            if (DistanceToPlayer() < chaseDistance)
            {
                print("Should chase now");
            }
        }
    }
}
