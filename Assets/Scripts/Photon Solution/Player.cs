using System;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arena.Photon
{
    public class Player : MonoBehaviour
    {
        private const string _verticalAxisName = "Vertical";
        private const string _horizontalAxisName = "Horizontal";

        [SerializeField]
        private SpriteRenderer _renderer;

        [SerializeField]
        private float _speed = 0.3f;

        private PhotonView _photonView;

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
            Debug.Log($"Player {_photonView.Owner.ActorNumber} Joined");
            
            _renderer.color = Game.GetPlayerColor(_photonView.Owner.ActorNumber);
        }

        void Update()
        {
            if (!_photonView.IsMine)
            {
                return;
            }
            
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