using UnityEngine;

namespace Players
{
    public class PlayerCameraView : MonoBehaviour
    {
        [SerializeField] private Camera camera;
        [SerializeField] private Player player;
        
        private void LateUpdate()
        {
            UpdateCameraPosition();
        }

        private void UpdateCameraPosition()
        {
            var currentPosition = camera.transform.position;
            var playerPosition = player.transform.position;
            camera.transform.position = new Vector3(playerPosition.x, currentPosition.y, playerPosition.z);
        }
    }
}