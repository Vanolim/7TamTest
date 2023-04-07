using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class MasterClientService : IDisposable,
        IInitializable
    {
        private GamePhotonService _gamePhotonService;
        private FinishGameView _finishGameView;
        private readonly List<CharacterData> _deadCharacterDats = new();

        [Inject]
        private void Construct(GamePhotonService gamePhotonService,
            FinishGameView finishGameView)
        {
            _gamePhotonService = gamePhotonService;
            _finishGameView = finishGameView;
            _gamePhotonService.OnCharacterDied += AddDiedCharacter;
        }

        private void AddDiedCharacter(CharacterData characterData)
        {
            _deadCharacterDats.Add(characterData);
            Debug.Log($"{_deadCharacterDats.Count} -- {PhotonNetwork.CurrentRoom.Players.Count}");
            TryFinished();
        }

        private void TryFinished()
        {
            if (_deadCharacterDats.Count >= PhotonNetwork.CurrentRoom.Players.Count)
            {
                FinishGame();
            }
        }

        private void FinishGame()
        {
            _finishGameView.Activate();
        }

        public void Dispose()
        {
            _gamePhotonService.OnCharacterDied -= AddDiedCharacter;
        }

        public void Initialize()
        {
            var players = PhotonNetwork.CurrentRoom.Players;
            Debug.Log(11111);
            foreach (var VARIABLE in players.Values)
            {
                Character cha = (Character)VARIABLE.CustomProperties["character"];
                Debug.Log(cha.gameObject.name);
            }
        }
    }
}