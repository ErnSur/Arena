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
        }

        public override void OnConnected()
        {
            Debug.Log($"OnConnected");
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log($"OnConnectedToMaster");
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinedRoom()
        {
            Debug.Log($"Joined to Room");
            PhotonNetwork.Instantiate(_playerPrefab.name, new Vector3(0f, 0f, 0f), Quaternion.identity);
            base.OnJoinedRoom();
        }
        
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

            // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 4});
        }

        public void SpawnPlayer()
        {
            if (PhotonNetwork.IsConnected)
            {
                Debug.Log($"PLayer Is Connected already");
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                // #Critical, we must first and foremost connect to Photon Online Server.
                PhotonNetwork.GameVersion = "version1";
                PhotonNetwork.ConnectUsingSettings();
            }
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