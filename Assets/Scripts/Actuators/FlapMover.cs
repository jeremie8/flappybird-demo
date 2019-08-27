using UnityEngine;

namespace Actuators
{
    public class FlapMover : MonoBehaviour
    {
        [SerializeField] private Vector2 flapForce = Vector2.up * 5;

        private Rigidbody2D RigidBody { get; set; }
        private void Awake()
        {
            RigidBody = GetComponent<Rigidbody2D>();
        }
        
        public void Flap()
        {
            RigidBody.velocity = flapForce;
        }
    }
}