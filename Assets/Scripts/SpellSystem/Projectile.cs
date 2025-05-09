using HealthSystem;
using UnityEngine;

namespace SpellSystem
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed = 10f;

        private float _damage;

        public void Initialize(float damage) => _damage = damage;

        private void Update() => MoveForward();

        private void MoveForward()
        {
            var translation = Vector3.forward * speed * Time.deltaTime;
            transform.Translate(translation);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<IDamageable>(out var damageable))
                return;
            
            damageable.ApplyDamage(_damage);
            Destroy(gameObject);
        }
    }
}