using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CreamController : MonoBehaviour, IClickable
{
    [SerializeField] private Dragger dragger;
    [SerializeField] private Transform targetPosition;
    [SerializeField] private SmoothDisappearing smoothDisappearingPimples;
    [SerializeField] private MovingToPoint movingToPoint;
    [SerializeField] private Animation creamAnimation;
    [SerializeField] private float successRadius = 1;
    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    public void OnPointerDown()
    {
        dragger.StartDragging(this.gameObject);
    }

    public void OnPointerUp()
    {
        dragger.StopDragging();
        if (Vector2.Distance(transform.position, targetPosition.position) < successRadius)
        {
            RemovePimples();
        }
        else
        {
            movingToPoint.Move(this.gameObject, _startPosition, _startRotation);
        }

        
    }

    private void RemovePimples()
    {
        smoothDisappearingPimples.Disappear();
        creamAnimation.Play();
        StartCoroutine(WaitEndAnimation());
    }

    private IEnumerator WaitEndAnimation()
    {
        yield return new WaitForSeconds(0.75f);
        movingToPoint.Move(this.gameObject, _startPosition, _startRotation);
    }
}