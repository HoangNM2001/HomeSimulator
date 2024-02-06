using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Gameplay
{
    public class MoveableObject : MonoBehaviour
    {
        [SerializeField] private Outline outline;
        [SerializeField] private Transform visual;

        private bool _isHovering;
        private Vector3 _defaultPos;
        private Vector3 _selectedPos;

        private void Start()
        {
            outline.enabled = false;
            _isHovering = false;
            _defaultPos = visual.localPosition;
            _selectedPos = new Vector3(_defaultPos.x, _defaultPos.y + 0.05f, _defaultPos.z);
        }

        public void IsSelected()
        {
            visual.localPosition = _selectedPos;
        }

        public void NotSelected()
        {
            visual.localPosition = _defaultPos;
        }

        public void IsHovering()
        {
            if (_isHovering) return;
            _isHovering = true;
            outline.enabled = true;
            // Debug.LogError("IsHovering");
        }

        public void NotHovering()
        {
            if (!_isHovering) return;
            _isHovering = false;
            outline.enabled = false;
            // Debug.LogError("NotHovering");
        }
    }
}