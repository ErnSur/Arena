using System;
using Mirror;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arena.Mirror
{
    public class PlayerMirror : NetworkBehaviour, IPlayer
    {
        private const string _verticalAxisName = "Vertical";
        private const string _horizontalAxisName = "Horizontal";

        [SerializeField]
        private SpriteRenderer _renderer;

        [SerializeField]
        private float _speed = 0.3f;
        
        private void Awake()
        {
            Game.RegisterPlayer(this, out var playerColor);
            _renderer.color = playerColor;
        }

        private void Update()
        {
            if (!isLocalPlayer)
            {
                return;
            }
            
            MovePlayerOnInput();
        }

        private void MovePlayerOnInput()
        {
            var verticalMovement = Input.GetAxis(_verticalAxisName);
            var horizontalMovement = Input.GetAxis(_horizontalAxisName);

            if (Math.Abs(verticalMovement) > float.Epsilon)
            {
                transform.position += verticalMovement * _speed * Vector3.up;
            }

            if (Math.Abs(horizontalMovement) > float.Epsilon)
            {
                transform.position += horizontalMovement * _speed * Vector3.right;
            }
        }
    }
}