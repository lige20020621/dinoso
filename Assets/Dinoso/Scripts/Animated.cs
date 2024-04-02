using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animated : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private int frame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(Animate());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Animate()
    {
        if (GameManager.Instance == null) yield break;
        while (true){
            frame++;
            if (frame >= sprites.Length){
                frame = 0;
            }
            spriteRenderer.sprite = sprites[frame];
            float delay = 1f / GameManager.Instance.gameSpeed;
            yield return new WaitForSeconds(delay);
        }
    }
}
