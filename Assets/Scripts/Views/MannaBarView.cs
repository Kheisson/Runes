using System;
using Infra;
using Runes.Modals;
using UnityEngine;
using UnityEngine.UI;

namespace Runes.Views
{
    public class MannaBarView : MonoBehaviour
    {
        #region Editor
        [SerializeField]
        private Slider _mannaBar;

        [SerializeField]
        private float _regenerationPeriod = 2f;

        [SerializeField]
        private PlayerModal _playerModal;
        #endregion

        #region Methods

        private void Awake()
        {
            TimePulseService.Instance.TiggerEvery(_regenerationPeriod, AddManna);
        }

        public void OnCast(PlayerModal playerModal)
        {
            _playerModal = playerModal;
            if (_mannaBar.value >= _playerModal.MagicCost)
            {
                UseManna();
                HasEnoughManna = true;
                return;
            }
            HasEnoughManna = false;
        }

        private void UseManna()
        {
            if (_playerModal.MagicCost > _mannaBar.value)
            {
                return;
            }
            _mannaBar.value -= _playerModal.MagicCost;
        }

        private void AddManna()
        {
            _mannaBar.value += _playerModal.RegenerateAmount;
        }
        #endregion

        #region Properties
        public bool HasEnoughManna;
        #endregion

    }
}