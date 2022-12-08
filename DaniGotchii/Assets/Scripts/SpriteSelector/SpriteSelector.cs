using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSelector : MonoBehaviour
{
    [System.Serializable]
    class SelectableSprite
    {
        [SerializeField] public string spriteName;
        [SerializeField] public Sprite sprite;
    }

    [SerializeField] private List<SelectableSprite> sprites = new List<SelectableSprite>();

    [SerializeField] private SpriteRenderer spriteRenderer = null;

    private void Start()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DisplaySprite(string spriteName)
    {
        if (spriteRenderer == null)
            return;

        for (int i = 0; i < sprites.Count; i++)
        {
            if (sprites[i].spriteName == spriteName)
            {
                spriteRenderer.sprite = sprites[i].sprite;
                return;
            }
        }
    }
}
