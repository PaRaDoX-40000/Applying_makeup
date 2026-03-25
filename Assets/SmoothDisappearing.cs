using System.Collections;
using UnityEngine;

public class SmoothDisappearing : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Coroutine _disappearCoroutine;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Disappear()
    {
        if(_disappearCoroutine != null) {StopCoroutine(_disappearCoroutine);}
        _disappearCoroutine = StartCoroutine(DisappearCoroutine());

    }
    private IEnumerator DisappearCoroutine()
    {
        while (spriteRenderer.color.a > 0)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a - Time.deltaTime); 
            yield return null;
        }
    }
}
