using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Dragger : MonoBehaviour
{
    [SerializeField] private float followSpeed = 20f;
    [SerializeField] private float rotationIntensity = 15f;
    private Vector3 _currentInputPos;
    private bool _isDragging;
    private GameObject _draggingObject;

    public void OnPointerMove(InputAction.CallbackContext context)
    {
        _currentInputPos = context.ReadValue<Vector2>();
    }
    public void StartDragging(GameObject draggingObject) 
    {
        _isDragging = true;
        _draggingObject = draggingObject;
    }  
    public void StopDragging()
    {
        _isDragging = false;
    }
    private void Update()
    {
        if (_isDragging)
        {

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(_currentInputPos);
            mouseWorldPos.z = _draggingObject.transform.position.z;

            _draggingObject.transform.position = Vector3.Lerp(_draggingObject.transform.position, mouseWorldPos, Time.deltaTime * followSpeed);

            float tiltZ = (_draggingObject.transform.position.x - mouseWorldPos.x) * rotationIntensity;
            Quaternion targetRot = Quaternion.Euler(0, 0, tiltZ);
            _draggingObject.transform.rotation = Quaternion.Lerp(_draggingObject.transform.rotation, targetRot, Time.deltaTime * followSpeed);
        }
    }
}