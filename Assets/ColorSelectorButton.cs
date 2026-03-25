using UnityEngine;

public class ColorSelectorButton : MonoBehaviour, IClickable
{
    [SerializeField] private BrushController brush; 
    [SerializeField] private Color buttonColor;      
    [SerializeField] private int colorIndex;         

    public void OnPointerDown()
    {
        brush.SelectColor(buttonColor, colorIndex, transform.position);
    }

    public void OnPointerUp()
    {
        brush.StopDragging();
    }
    
}