using System.Collections;
using UnityEngine;

public class MovingToPoint : MonoBehaviour
{
    [SerializeField] private float speed;
    void Start()
    {
        
    }

    public void Move(GameObject movingObject, Vector3 point, Quaternion startRotation)
    {
        StartCoroutine(MoveCoroutine(movingObject, point, startRotation));
    }
    private IEnumerator MoveCoroutine(GameObject movingObject, Vector3 point, Quaternion startRotation)
    {
        while (Vector3.Distance(movingObject.transform.position, point) > 0.01f)
        {
            movingObject.transform.position = Vector3.Lerp(movingObject.transform.position, point, Time.deltaTime * speed);
            movingObject.transform.rotation = Quaternion.Lerp(movingObject.transform.rotation, startRotation, Time.deltaTime * speed);
            yield return null;
        }
        movingObject.transform.position = point;
        movingObject.transform.rotation = startRotation;
        movingObject = null;
    }
    
}
