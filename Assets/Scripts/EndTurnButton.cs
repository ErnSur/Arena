using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arena.UI
{
    // For Each Player
    [RequireComponent(typeof(Button))]
    public class EndTurnButton : MonoBehaviour
    {
        [SerializeField]
        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnClick()
        {
            
        }
    }
}

namespace Arena
{
    // Synced Between players
    public static class Game
    {
        public static Player[] PresentPlayers;

        public static Player ActiveTurn = Player.None;
        
        public enum Player
        {
            None,
            Red,
            Green,
            Yellow,
            Blue
        }
    }
}