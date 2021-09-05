using System;
using UnityEngine;


namespace Runes.Modals
{
    [CreateAssetMenu(fileName = "New Player Modal", menuName = "Modals/Player Modal")]
    public class PlayerModal : ScriptableObject
    {
        #region Editor
        [SerializeField]
        private float _increamentalValue = 20f;

        [SerializeField]
        private float _castMagicPrice = 20f;

        [SerializeField]
        private float _damage = 25f;

        [SerializeField]
        private Transform[] _drawPattern;
        #endregion

        #region Properties
        public float MagicCost => _castMagicPrice;
        public float RegenerateAmount => _increamentalValue;
        public float Damage => _damage;
        public Transform[] DrawPattern => _drawPattern;
        #endregion

    }
}