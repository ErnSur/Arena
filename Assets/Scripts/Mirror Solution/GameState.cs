using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Arena.Mirror
{
    public class GameState : NetworkBehaviour
    {
        private static readonly List<IPlayer> _players = new List<IPlayer>();

        private static readonly Stack<Color> _freeColors = new Stack<Color>
        (new[]
        {
            Color.red,
            Color.green,
            Color.yellow,
            Color.blue
        });

        public static void RegisterPlayer(IPlayer player)
        {
            player.Color = _freeColors.Pop();
            _players.Add(player);
        }

        public static void UnregisterPlayer(IPlayer player)
        {
            if (!_players.Contains(player))
            {
                return;
            }

            _freeColors.Push(player.Color);
            _players.Remove(player);
        }

        [SerializeField]
        private IPlayer _currentPlayerTurn;

        public void NextTurn()
        {
            
        }
    }
}