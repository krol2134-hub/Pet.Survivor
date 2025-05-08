using System.Collections.Generic;
using UnityEngine;

namespace Core.UpdateServices
{
    public class UpdateService : MonoBehaviour
    {
        private readonly List<IUpdatable> _updatables = new();
        private readonly List<ILateUpdatable> _lateUpdatables = new();

        public void RegisterUpdateable(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }
        
        public void RegisterLateUpdateable(ILateUpdatable lateUpdatable)
        {
            _lateUpdatables.Add(lateUpdatable);
        }
        
        private void Update()
        {
            foreach (var updatable in _updatables)
            {
                updatable.Update();
            }
        }
        
        private void LateUpdate()
        {
            foreach (var lateUpdatable in _lateUpdatables)
            {
                lateUpdatable.LateUpdate();
            }
        }
    }
}