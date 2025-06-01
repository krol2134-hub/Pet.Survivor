using System;
using Voody.UniLeo;

namespace EcsCore
{
    [Serializable]
    public struct PlayerTag { }
    
    public class PlayerTagProvider : MonoProvider<PlayerTag> { }
}