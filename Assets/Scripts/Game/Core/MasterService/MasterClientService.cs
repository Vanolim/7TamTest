using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace TapTest
{
    public class MasterClientService : IDisposable,
        IInitializable
    {
        private GamePhotonService _gamePhotonService;
        private LobbyPhotonService _lobbyPhotonService;
        private HigscoresService _higscoresService;
        private CoroutineService _coroutineService;
        private float _waitFinishedLoadLobbyValue;

        private readonly List<CharacterData> _deadCharacterDats = new();

        [Inject]
        private void Construct(GamePhotonService gamePhotonService, HigscoresService higscoresService, 
            CoroutineService coroutineService, LobbyPhotonService lobbyPhotonService,
            GameSetting gameSetting)
        {
            _gamePhotonService = gamePhotonService;
            _higscoresService = higscoresService;
            _coroutineService = coroutineService;
            _lobbyPhotonService = lobbyPhotonService;
            _waitFinishedLoadLobbyValue = gameSetting.WaitBootstrapperScene;
        }

        private void AddDeadCharacter(CharacterData characterData)
        {
            _deadCharacterDats.Add(characterData);
            TryGameFinished();
        }

        private void TryGameFinished()
        {
            if (_deadCharacterDats.Count < PhotonNetwork.CurrentRoom.Players.Count)
            {
                Character[] characters = Object.FindObjectsOfType<Character>(true);
                if(characters.Length == 1)
                    characters[0].Died();
            }
            else
            {
                FinishGame();
            }
        }

        private void FinishGame()
        {
            _higscoresService.SetData(_deadCharacterDats.ToArray());
            _higscoresService.ActivateView();
            _coroutineService.StartCoroutine(WaitLoadLobby());
        }

        private IEnumerator WaitLoadLobby()
        {
            yield return new WaitForSeconds(_waitFinishedLoadLobbyValue);
            _lobbyPhotonService.LoadLobby();
        }

        public void Dispose()
        {
            _gamePhotonService.OnCharacterDied -= AddDeadCharacter;
        }

        public void Initialize()
        {
            _gamePhotonService.OnCharacterDied += AddDeadCharacter;
            _higscoresService.DeactivateView();
        }
    }
}