using System.Collections;
using UnityEngine;

public class LipstickСontroller : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Dragger dragger;
    [SerializeField] private Transform targetPosition;
    [SerializeField] private MovingToPoint movingToPoint;
    [SerializeField] private float successRadius = 1;
    [SerializeField] private GameObject lipstickForAnimation;
    [SerializeField] private Animation lipstickAnimation;
    [SerializeField] private ColorСhanger colorСhanger;


    private int _selectedColorIndex;
    private GameObject _selectedLipstick;
    private Vector3 _selectedLipstickStartPosition;
    private Quaternion _selectedLipstickStartRotation;
    public void SelectColor(GameObject lipstick, int index)
    {
        _selectedColorIndex = index;
        _selectedLipstick = lipstick;
        _selectedLipstickStartPosition = lipstick.transform.position;
        _selectedLipstickStartRotation = lipstick.transform.rotation;
        dragger.StartDragging(lipstick);
    }

    public void StopDragging()
    {
        dragger.StopDragging();
        if (Vector2.Distance(_selectedLipstick.transform.position, targetPosition.position) < successRadius)
        {
            ApplyMakeup();
        }
        else
        {
          movingToPoint.Move(_selectedLipstick, _selectedLipstickStartPosition, _selectedLipstickStartRotation);
        }
    }
    private void ApplyMakeup()
    {
        colorСhanger.ChangeColor(_selectedColorIndex);
        _selectedLipstick.SetActive(false);
        lipstickForAnimation.GetComponent<SpriteRenderer>().sprite = _selectedLipstick.GetComponent<SpriteRenderer>().sprite;
        lipstickForAnimation.SetActive(true);

        lipstickAnimation.Play();
        StartCoroutine(WaitEndAnimation());
    }

    private IEnumerator WaitEndAnimation()
    {
        yield return new WaitForSeconds(0.75f);
        _selectedLipstick.transform.position = _selectedLipstick.transform.position;
        _selectedLipstick.transform.rotation = _selectedLipstick.transform.rotation;
        _selectedLipstick.SetActive(true);
        lipstickForAnimation.SetActive(false);
        movingToPoint.Move(_selectedLipstick, _selectedLipstickStartPosition, _selectedLipstickStartRotation);

    }
}
