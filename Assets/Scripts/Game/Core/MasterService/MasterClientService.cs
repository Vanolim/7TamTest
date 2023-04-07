using System;
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
        private readonly List<CharacterData> _deadCharacterDats = new();

        [Inject]
        private void Construct(GamePhotonService gamePhotonService,
            FinishGameView finishGameView)
        {
            _gamePhotonService = gamePhotonService;
            _finishGameView = finishGameView;
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
            _finishGameView.Test(SetData());
            _finishGameView.Activate();
        }

        private string SetData()
        {
            CharacterData[] sortDeadCharacterDats = _deadCharacterDats.OrderBy(x => x.CountCoins).ToArray();
            
            string data = "";
            for (int i = 0; i < sortDeadCharacterDats.Length; i++)
            {
                data += sortDeadCharacterDats[i].Name + ',';
                data += sortDeadCharacterDats[i].CountCoins + ',';
                data += i + ";";
            }

            return data;
        }

        public void Dispose()
        {
            _gamePhotonService.OnCharacterDied -= AddDiedCharacter;
        }
    }
}