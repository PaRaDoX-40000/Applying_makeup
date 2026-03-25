using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ClickHandler : MonoBehaviour
{
    private Vector2 _screenPos;
    private IClickable _activeClickable;
    public void OnPointerMove(InputAction.CallbackContext context)
    {
        _screenPos = context.ReadValue<Vector2>();
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(_screenPos);
            Vector2 worldPos2D = new Vector2(worldPos.x, worldPos.y);

            Collider2D hitCollider = Physics2D.OverlapPoint(worldPos2D);
            if (hitCollider != null && hitCollider.gameObject.TryGetComponent(out IClickable clickable))
            {
                _activeClickable = clickable;
                _activeClickable.OnPointerDown();
            }
        }
        else if (context.canceled && _activeClickable != null)
        {
            _activeClickable.OnPointerUp();
            _activeClickable = null;
        }
    }
    
}
