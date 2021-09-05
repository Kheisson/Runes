using Runes.Modals;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Runes.Views
{
    public class CastRuneButton : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Button _btn;

        [SerializeField]
        private RuneDrawingFieldView _view;

        [SerializeField]
        private MannaBarView _mannaBar;

        [SerializeField]
        private PlayerModal _playerModal;

        [SerializeField]
        private bool _shouldDamage;

        [SerializeField]
        private HealthBarView _healthBar;
        #endregion

        #region Fields

        #endregion

        #region Methods

        private void Awake()
        {
            _view.BeginDraw += OnRuneBeginDraw;
            _view.EndDraw += OnRuneEndDraw;
        }

        private void OnDestroy()
        {
            _view.BeginDraw -= OnRuneBeginDraw;
            _view.EndDraw -= OnRuneEndDraw;
        }

        private void OnRuneBeginDraw()
        {
            _btn.interactable = false;
        }

        private void OnRuneEndDraw()
        {
            _btn.interactable = true;
        }

        public void OnButtonClicked()
        {
            _mannaBar.OnCast(_playerModal);
            _view.RunePoints = _playerModal.DrawPattern;
            if (_mannaBar.HasEnoughManna)
            {
                _view.DrawRune();
                if (!_shouldDamage)
                {
                    _healthBar.Heal();
                }
                else
                {
                    _healthBar.Damage(_playerModal.Damage);
                }
            }
        }
        #endregion
    }
}
