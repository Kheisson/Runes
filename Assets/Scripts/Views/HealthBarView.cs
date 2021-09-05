using UnityEngine;
using Runes.Modals;
using UnityEngine.UI;
using Infra;

namespace Runes.Views
{
    public class HealthBarView : MonoBehaviour
    {
        #region Editor
        [SerializeField]
        private Slider _healthBar;

        [SerializeField]
        private float _regenerationPeriod = 3f;
        #endregion

        #region Methods

        public void Heal()
        {
            TimePulseService.Instance.TriggerOnce(_regenerationPeriod, IncreaseHealth);
        }

        public void Damage(float hitpoints)
        {
            _healthBar.value -= hitpoints;
        }

        private void IncreaseHealth()
        {
            _healthBar.value += 0.25f;
        }
        #endregion

    }
}
