using UnityEngine;

namespace Arena
{
    public interface IPlayer
    {
        Color Color { get; set; }
        bool isLocalPlayer { get; }
    }
}