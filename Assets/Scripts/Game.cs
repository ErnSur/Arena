using System;
using System.Collections.Generic;
using UnityEngine;

namespace Arena
{
    public static class Game
    {
        private static readonly List<IPlayer> _players = new List<IPlayer>();

        public static void RegisterPlayer(IPlayer player, out Color playerColor)
        {
            _players.Add(player);
            playerColor = GetPlayerColor(_players.Count);
        }

        private static Color GetPlayerColor(int playerNumber)
        {
            switch (playerNumber)
            {
                case 1:
                    return Color.red;
                case 2:
                    return Color.green;
                case 3:
                    return Color.yellow;
                case 4:
                    return Color.blue;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}