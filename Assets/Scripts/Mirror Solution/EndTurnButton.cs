using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Arena.Mirror.UI
{
    public class EndTurnButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
            
            
        }

        private void OnClick()
        {
            Debug.Log($"Button was Clicked");
        }
    }
}