using System;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

namespace Gameplay
{
    public class Grabber : MonoBehaviour
    {
        [SerializeField] private LayerMask moveAbleLayer;
        [SerializeField] private bool enableMoveAble;

        private Camera _mainCamera;
        private MoveableObject _hoveringObject;
        private MoveableObject _selectedObject;

        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (!enableMoveAble) return;

            if (_selectedObject == null)
            {
                var hit = MouseRayCast();
                if (hit.collider)
                {
                    if (_hoveringObject == null)
                    {
                        _hoveringObject = hit.collider.gameObject.GetComponentInParent<MoveableObject>();
                        _hoveringObject.IsHovering();
                    }
                }
                else
                {
                    if (_hoveringObject) _hoveringObject.NotHovering();
                    _hoveringObject = null;
                }
            }

            if (Input.GetMouseButtonDown(0) && _hoveringObject != null)
            {
                _selectedObject = _hoveringObject;
                _hoveringObject = null;

                _selectedObject.IsHovering();
                _selectedObject.IsSelected();
            }
            else if (Input.GetMouseButtonUp(0) && _selectedObject != null)
            {
                _selectedObject.NotSelected();
                _selectedObject = null;
            }

            if (_selectedObject != null)
            {
                var selectedObjectPos = _selectedObject.transform.position;
                var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                    _mainCamera.WorldToScreenPoint(selectedObjectPos).z);
                var worldPosition = _mainCamera.ScreenToWorldPoint(position);

                selectedObjectPos = new Vector3(worldPosition.x, selectedObjectPos.y, worldPosition.z);
                _selectedObject.transform.position = selectedObjectPos;
            }
        }

        private RaycastHit MouseRayCast()
        {
            var screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _mainCamera.farClipPlane);
            var screenMousePosNear =
                new Vector3(Input.mousePosition.x, Input.mousePosition.y, _mainCamera.nearClipPlane);

            var worldMousePosFar = _mainCamera.ScreenToWorldPoint(screenMousePosFar);
            var worldMousePosNear = _mainCamera.ScreenToWorldPoint(screenMousePosNear);

            if (Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out var hit, Mathf.Infinity,
                    moveAbleLayer))
            {
                Debug.DrawRay(worldMousePosNear, worldMousePosFar - worldMousePosNear, Color.green);
            }
            else
            {
                Debug.DrawRay(worldMousePosNear, worldMousePosFar - worldMousePosNear, Color.red);
            }

            return hit;
        }
    }
}