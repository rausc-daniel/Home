
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSortingLayer : MonoBehaviour
{
    private void Awake()
    {
        var renderers = FindObjectsOfType<SpriteRenderer>();
        var id = SortingLayer.NameToID("Foreground");
        for (var i = 0; i < renderers.Length; i++)
        {
            var spriteRenderer = renderers[i];
            if (spriteRenderer.sortingLayerID != id)
                continue;
            if (spriteRenderer.GetComponentInParent<PlayerController>() || spriteRenderer.GetComponent<Sister>())
                continue;
            spriteRenderer.sortingOrder = -(int) (spriteRenderer.transform.position.z * 100);
            renderers[i] = spriteRenderer;
        }
    }
}
