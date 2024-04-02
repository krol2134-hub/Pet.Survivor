using System.Collections;
using UnityEngine;

namespace Helpers
{
    public class SelfDestroyer : MonoBehaviour
    { 
        [SerializeField] private float delay;

        private void Start() => StartCoroutine(DestroyWithDelay());

        private IEnumerator DestroyWithDelay()
        {
            yield return new WaitForSeconds(delay);
            
            Destroy(gameObject);
        }
    }
}
