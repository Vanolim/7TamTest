using System.Linq;
using Zenject;

namespace TapTest
{
    public class HigscoresService
    {
        private HigscoresView _higscoresView;

        [Inject]
        private void Construct(HigscoresView higscoresView)
        {
            _higscoresView = higscoresView;
        }

        public void SetData(CharacterData[] characterDatas)
        {
            CharacterData[] sortDeadCharacterDats = 
                characterDatas.OrderByDescending(x => x.CountCoins).ToArray();

            for (int i = 0; i < sortDeadCharacterDats.Length; i++)
            {
                _higscoresView.Test(sortDeadCharacterDats[i].Name, sortDeadCharacterDats[i].CountCoins.ToString(), i);
            }
        }

        public void DeactivateView() => _higscoresView.Deactivate();
        public void ActivateView() => _higscoresView.Activate();
    }
}