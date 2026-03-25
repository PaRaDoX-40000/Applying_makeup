using UnityEngine;

public class MakeupTabButton : MonoBehaviour, IClickable
{
    [SerializeField] private int tabIndex; 
    [SerializeField] private MakeupPanelManager manager; 
    [SerializeField] private SpriteRenderer buttonSpriteRenderer;    
    [SerializeField] private Sprite normalSprite; 
    [SerializeField] private Sprite activeSprite; 

    public void OnPointerDown()
    {
        manager.SelectTab(tabIndex);
    }

    public void OnPointerUp()
    {
    }
    public void SetActiveState(bool isActive)
    {
        if (buttonSpriteRenderer == null) return;
        if (isActive)
        {
            buttonSpriteRenderer.sprite = activeSprite;
        }
        else
        {
            buttonSpriteRenderer.sprite = normalSprite;
        }
    }
}