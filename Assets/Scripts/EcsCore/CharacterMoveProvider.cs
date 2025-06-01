using System;
using UnityEngine;
using Voody.UniLeo;

namespace EcsCore
{
    [Serializable]
    public struct CharacterMoveComponent
    {
        public CharacterController CharacterController;
        public float Speed;
    }
    
    public class CharacterMoveProvider : MonoProvider<CharacterMoveComponent> { }
}