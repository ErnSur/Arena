using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Arena
{
    public class ArenaGameController : MonoBehaviourPunCallbacks
    {
        public static ArenaGameController Instance { get; private set; }

        [SerializeField]
        private GameObject _playerPrefab;

        private void Awake()
        {
            Instance = this;
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.JoinOrCreateRoom("DemoRoom", new RoomOptions() { MaxPlayers = 4 },null);
        }

        public override void OnConnected()
        {
            PhotonNetwork.Instantiate(_playerPrefab.name, new Vector3(0f,0f,0f), Quaternion.identity);
        }

        public void SpawnPlayer()
        {
        }
    }
    
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