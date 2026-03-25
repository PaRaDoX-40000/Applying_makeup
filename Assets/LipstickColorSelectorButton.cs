using UnityEngine;

public class LipstickColorSelectorButton : MonoBehaviour, IClickable
{
    [SerializeField] private Lipstick—ontroller lipstick—ontroller; 
    [SerializeField] private int colorIndex;       

    public void OnPointerDown()
    {
        lipstick—ontroller.SelectColor(this.gameObject, colorIndex);
    }

    public void OnPointerUp()
    {
        lipstick—ontroller.StopDragging();
    }
}
