using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.TerrainTools;

public class BrushController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private GameObject brush;
    [SerializeField] private SpriteRenderer brushTip;
    [SerializeField] private Dragger dragger;
    [SerializeField] private Transform targetPosition;
    [SerializeField] private MovingToPoint movingToPoint;
    [SerializeField] private float successRadius = 1;
    [SerializeField] private ColorÑhanger colorÑhanger;
    [SerializeField] private Animation brushAnimation;

    private int _selectedColorIndex;
    private Vector3 _brushStartPosition;
    private Quaternion _brushStartRotation;
    private Coroutine _moveCoroutine; 

    private void Start()
    {
        _brushStartPosition = brush.transform.position;
        _brushStartRotation = brush.transform.rotation;
    }
   

    public void SelectColor(Color targetColor, int index, Vector3 targetPosition)
    {
        _selectedColorIndex = index;

        if (_moveCoroutine != null) StopCoroutine(_moveCoroutine);
        _moveCoroutine = StartCoroutine(MoveToTarget(targetColor, targetPosition));
    }

    private IEnumerator MoveToTarget(Color targetColor, Vector3 targetPosition)
    {
        Vector3 startPosition = brush.transform.position;

        targetPosition = new Vector3(targetPosition.x, targetPosition.y-0.70f, targetPosition.z) ;
        float distance = Vector3.Distance(startPosition, targetPosition);
        float elapsedTime = 0f;
       
        while (Vector3.Distance(brush.transform.position, targetPosition) > 0.01f)
        {
            elapsedTime += Time.deltaTime;
            float t = (elapsedTime * moveSpeed) / distance;

            brush.transform.position = Vector3.Lerp(startPosition, targetPosition, t);

            yield return null;
        }
        brush.transform.position = targetPosition;  
        StartCoroutine(ChangeColor(targetColor));      
    }
    private IEnumerator ChangeColor(Color targetColor)
    {
        Color startColor = new Color(targetColor.r, targetColor.g, targetColor.b, 0f);
        float elapsedTime = 0f;

        while (brushTip.color.a < 0.6f)
        {
            elapsedTime += Time.deltaTime;
            if (brushTip != null)
            {
                brushTip.color = Color.Lerp(startColor, targetColor, elapsedTime*5 );
            }
            yield return null;
        }
        dragger.StartDragging(brush);
    }

    
    public void StopDragging()
    { 
        dragger.StopDragging();
        if (Vector2.Distance(brush.transform.position, targetPosition.position) < successRadius)
        {
            ApplyMakeup();
        }
        else
        {
            movingToPoint.Move(brush, _brushStartPosition, _brushStartRotation);
            brushTip.color = Color.clear;
        }
    }
    private void ApplyMakeup()
    {
        colorÑhanger.ChangeColor(_selectedColorIndex);
        brushAnimation.Play();
        StartCoroutine(WaitEndAnimation());
    }

    private IEnumerator WaitEndAnimation()
    {
        yield return new WaitForSeconds(0.75f);
        brushTip.color = Color.clear;
        movingToPoint.Move(brush, _brushStartPosition, _brushStartRotation);
    }


}