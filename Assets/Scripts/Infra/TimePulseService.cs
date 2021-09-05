using System;
using System.Collections;
using UnityEngine;

namespace Infra
{
    public class TimePulseService
    {
        #region Fields
        private static TimePulseService _instance;
        #endregion

        #region Properties
        public static TimePulseService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TimePulseService();
                }
                return _instance;
            }
        }
        #endregion

        #region Constructor
        private TimePulseService()
        {

        }
        #endregion

        #region Methods
        public Coroutine TiggerEvery(float time, Action triggerCallback)
        {
            return CoroutineService.Instance.StartCoroutine(TriggerEveryCoroutine(time, triggerCallback));
        }

        public Coroutine TriggerOnce(float duration, Action triggerCallback)
        {
            return CoroutineService.Instance.StartCoroutine(TriggerOnceCoroutine(duration, triggerCallback));
        }

        private IEnumerator TriggerEveryCoroutine(float time, Action triggerCallback)
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(time);
                triggerCallback?.Invoke();
            }
        }

        private IEnumerator TriggerOnceCoroutine(float duration, Action triggerCallback)
        {
            var end = Time.time + duration;
            while(Time.time <= end)
            {
                triggerCallback?.Invoke();
                yield return null;
            }
        }
        #endregion

    }
}
