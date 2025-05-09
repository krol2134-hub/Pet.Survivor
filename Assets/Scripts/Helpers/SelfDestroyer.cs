using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Helpers
{
    public class SelfDestroyer : MonoBehaviour
    {
        [SerializeField] private float delay;

        private void Start()
        {
            DestroyWithDelay(this.GetCancellationTokenOnDestroy()).Forget();
        }

        private async UniTaskVoid DestroyWithDelay(CancellationToken token)
        {
            await UniTask.WaitForSeconds(delay, cancellationToken:token);

            if (token.IsCancellationRequested)
                return;
            
            Destroy(gameObject);
        }
    }
}