using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace EcsCore
{
    public sealed class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;

        private EcsSystems _fixedUpdateSystems;
        private EcsSystems _updateSystems;
        private EcsSystems _lateUpdateSystems;

        private void Start()
        {
            _world = new EcsWorld();

            _fixedUpdateSystems = new EcsSystems(_world);
            _updateSystems = new EcsSystems(_world);
            _lateUpdateSystems = new EcsSystems(_world);

            _fixedUpdateSystems.ConvertScene();
            _updateSystems.ConvertScene();
            _lateUpdateSystems.ConvertScene();
            
            AddUpdateSystems();
            
            _fixedUpdateSystems.Init();
            _updateSystems.Init();
            _lateUpdateSystems.Init();
        }

        private void OnDestroy()
        {
            _fixedUpdateSystems.Destroy();
            _updateSystems.Destroy();
            _lateUpdateSystems.Destroy();
        }

        private void Update()
        {
            _fixedUpdateSystems.Run();
            _updateSystems.Run();
            _lateUpdateSystems.Run();
        }

        private void AddUpdateSystems()
        {
            _updateSystems.Add(new PlayerInputSystem());
            _updateSystems.Add(new MovementSystem());
        }
    }
}
