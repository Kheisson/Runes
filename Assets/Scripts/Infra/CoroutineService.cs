using System.Collections;
using UnityEngine;

namespace Infra
{
    public class CoroutineService
    {
        #region Internals
        private class CoroutineServiceBehaviour : MonoBehaviour
        {

        }
        #endregion

        #region Fields
        private static CoroutineService _instance;

        private CoroutineServiceBehaviour _behaviour;
        #endregion

        #region Methods
        private static CoroutineService CreateInstance()
        {
            var go = new GameObject("Coroutine Serivce");
            var monoBeh = go.AddComponent<CoroutineServiceBehaviour>();

            return new CoroutineService(monoBeh);
        }

        public Coroutine StartCoroutine(IEnumerator coroutineBody)
        {
            return _behaviour.StartCoroutine(coroutineBody);
        }

        public void StopCoroutine(Coroutine runningCoroutine)
        {
            _behaviour.StopCoroutine(runningCoroutine);
        }

        #endregion

        #region Constructors

        private CoroutineService(CoroutineServiceBehaviour behaviour)
        {
            _behaviour = behaviour;
        }

        #endregion


        #region Properties
        public static CoroutineService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = CreateInstance();
                }
                return _instance;
            }
        }
        #endregion
    }
}
