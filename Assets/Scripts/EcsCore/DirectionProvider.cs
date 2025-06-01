using System;
using UnityEngine;
using Voody.UniLeo;

namespace EcsCore
{
    [Serializable]
    public struct DirectionComponent
    {
        public Vector2 Direction;
    }
    
    public class DirectionProvider : MonoProvider<DirectionComponent> { }
}