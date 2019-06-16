using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace Arena
{
    public class Player : MonoBehaviour
    {
        private const string _verticalAxisName = "Vertical";
        private const string _horizontalAxisName = "Horizontal";

        [SerializeField]
        private float _speed = 0.3f;

        void Update()
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