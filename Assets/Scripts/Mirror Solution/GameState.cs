using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Arena.Mirror
{
    public class GameState : NetworkBehaviour
    {
        public static event Action MyTurnStartEvent;
        public static event Action MyTurnEndEvent;
        private static readonly List<IPlayer> _players = new List<IPlayer>();

        private static readonly Stack<Color> _freeColors = new Stack<Color>
        (new[]
        {
            Color.red,
            Color.green,
            Color.yellow,
            Color.blue
        });
        
        private static IPlayer _localPlayer;

        private static int _currentPlayerTurn;

        public static void RegisterPlayer(IPlayer player)
        {
            player.Color = _freeColors.Pop();
            _players.Add(player);
            
            if (player.isLocalPlayer)
            {
                _localPlayer = player;
            }
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

        public void NextTurn()
        {
            _currentPlayerTurn = _currentPlayerTurn == _players.Count - 1 ? 0 : _currentPlayerTurn + 1;

            if (_players[_currentPlayerTurn] == _localPlayer)
            {
                MyTurnStartEvent?.Invoke();
            }
        }
    }
}