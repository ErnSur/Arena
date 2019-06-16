using System;
using System.Collections.Generic;
using UnityEngine;

namespace Arena.Photon
{
    public static partial class Game
    {
        private static readonly Dictionary<IPlayer,Color> _colorsInGame = new Dictionary<IPlayer, Color>();
        
        private static readonly Stack<Color> _freeColors = new Stack<Color>
        (new []{
            Color.red,
            Color.green,
            Color.yellow,
            Color.blue
        });

        public static void RegisterPlayer(IPlayer player, out Color playerColor)
        {
            _colorsInGame.Add(player,_freeColors.Pop());
            playerColor = _colorsInGame[player];
        }
        
        public static void UnregisterPlayer(IPlayer player)
        {
            if (!_colorsInGame.ContainsKey(player))
            {
                return;
            }
            
            _freeColors.Push(_colorsInGame[player]);
            _colorsInGame.Remove(player);
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