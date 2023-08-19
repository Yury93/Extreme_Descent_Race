using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartColor : MonoBehaviour
{
    public Renderer renderer;
    public List<Color> colors;

    [ContextMenu("GetRenderer")]
    public void GetRenderer()
    {
        renderer = GetComponent<Renderer>();
    }
    private void Start()
    {
        if(renderer == null)
        renderer = GetComponent<Renderer>();

        if (Application.isMobilePlatform == false)
        {
            StartCoroutine(CorRender());
        }
        else
        {
            renderer.sharedMaterial.color = colors[Random.Range(0, colors.Count)];
        }
    }
    IEnumerator CorRender()
    {
        if (ScoreCalculator.Score == 0)
        {
            yield return new WaitForSeconds(2);
            renderer.material.color = colors[Random.Range(0, colors.Count)];
        }
        else
        {
            renderer.material.color = colors[Random.Range(0, colors.Count)];
        }
    }
}
