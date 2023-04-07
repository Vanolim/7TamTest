using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace TapTest
{
    public class MasterClientService : IDisposable
    {
        private GamePhotonService _gamePhotonService;
        private FinishGameView _finishGameView;
        private CoroutineService _coroutineService;
        private readonly List<CharacterData> _deadCharacterDats = new();

        [Inject]
        private void Construct(GamePhotonService gamePhotonService,
            FinishGameView finishGameView, CoroutineService coroutineService)
        {
            _gamePhotonService = gamePhotonService;
            _finishGameView = finishGameView;
            _coroutineService = coroutineService;
            _gamePhotonService.OnCharacterDied += AddDiedCharacter;
            _finishGameView.Deactivate();
        }

        private void AddDiedCharacter(CharacterData characterData)
        {
            _deadCharacterDats.Add(characterData);
            TryFinished();
        }

        private void TryFinished()
        {
            if (_deadCharacterDats.Count < PhotonNetwork.CurrentRoom.Players.Count)
            {
                Character[] characters = Object.FindObjectsOfType<Character>();
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
            SetData();
            _finishGameView.Activate();
            _coroutineService.StartCoroutine(Wait());
        }

        private IEnumerator Wait()
        {
            yield return new WaitForSeconds(5);
            PhotonNetwork.LoadLevel("Lobby");
        }

        private void SetData()
        {
            foreach (var VARIABLE in _deadCharacterDats)
            {
                Debug.Log(VARIABLE.CountCoins);
            }
            
            CharacterData[] sortDeadCharacterDats = _deadCharacterDats.OrderBy(x => x.CountCoins).ToArray();
            
            foreach (var VARIABLE in sortDeadCharacterDats)
            {
                Debug.Log(VARIABLE.CountCoins);
            }

            for (int i = 0; i < sortDeadCharacterDats.Length; i++)
            {
                _finishGameView.Test(sortDeadCharacterDats[i].Name, sortDeadCharacterDats[i].CountCoins.ToString(), i);
            }
        }

        public void Dispose()
        {
            _gamePhotonService.OnCharacterDied -= AddDiedCharacter;
        }
    }
}