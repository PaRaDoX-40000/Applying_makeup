using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ColorСhanger : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public void ChangeColor(int colorIndex)
    {
        StartCoroutine(ChangeColorCorutine(colorIndex));
    }

    
    private IEnumerator ChangeColorCorutine(int colorIndex)
    {
        while (spriteRenderer.color.a > 0)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a - Time.deltaTime*3);
            yield return null;
        }
        spriteRenderer.sprite = sprites[colorIndex];
       
        while (spriteRenderer.color.a <= 1f)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, spriteRenderer.color.a + Time.deltaTime*3);
            yield return null;
        }
    }
}
