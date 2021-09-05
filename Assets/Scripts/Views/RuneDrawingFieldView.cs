using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runes.Views
{
    public class RuneDrawingFieldView : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Transform[] _runePoints;

        [SerializeField]
        private Transform _runeBrush;

        [SerializeField]
        [Range(0f, 1f)]
        private float _drawTime = 0.5f;

        #endregion


        #region Properties
        public Transform[] RunePoints { get => _runePoints; set => _runePoints = value; }
        #endregion

        #region Events
        public event Action BeginDraw;
        public event Action EndDraw;
        #endregion

        #region Fields
        private Stack<Vector3> _drawingPath = new Stack<Vector3>();
        #endregion

        #region Functions
        public void DrawRune()
        {
            GenerateDrawingPath();
            _runeBrush.position = _drawingPath.Pop();
            DrawRuneInternal();
        }

        private void GenerateDrawingPath()
        {
            _drawingPath.Clear();

            for (var i = _runePoints.Length - 1; i >= 0; i--)
            {
                _drawingPath.Push(_runePoints[i].position);
            }
        }

        private void DrawRuneInternal()
        {
            BeginDraw?.Invoke();
            if (_drawingPath.Count > 0)
            {
                var fromPoint = _runeBrush.position;
                var nextPoint = _drawingPath.Pop();
                StartCoroutine(DrawLine(_runeBrush, fromPoint, nextPoint, _drawTime, DrawRuneInternal));
            }
            else
            {
                EndDraw?.Invoke();
            }
        }

        private IEnumerator DrawLine(Transform runeBrush, Vector3 fromPoint, Vector3 toPoint, float inTime,
            Action endCallback)
        {
            var startTime = Time.time;
            var moveFactor = 0f;
            do
            {
                runeBrush.position = Vector3.Lerp(fromPoint, toPoint, moveFactor);
                moveFactor = (Time.time - startTime) / inTime;
                yield return null;
            }
            while (moveFactor < 1f);
            endCallback?.Invoke();
        }
        #endregion
    }
}