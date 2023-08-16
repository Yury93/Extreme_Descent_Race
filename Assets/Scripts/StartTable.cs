using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTable : MonoBehaviour
{
    [SerializeField] private Renderer lightRenderer;
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private GameObject startModel;

    IEnumerator Start()
    {
        var material = lightRenderer.sharedMaterial;
        material.color = Color.gray;
        material.SetColor("_EmissionColor", Color.gray);
        yield return new WaitForSeconds(0.5f);
        material.SetColor("_EmissionColor", Color.red);
        material.color = Color.red;
        yield return new WaitForSeconds(1f);
        material.SetColor("_EmissionColor", Color.yellow);
        material.color = Color.yellow;
        yield return new WaitForSeconds(1f);
        material.SetColor("_EmissionColor", Color.green);
        material.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        Destroy(startModel.gameObject);
        particleSystem.gameObject.SetActive(true);
        Destroy(gameObject, 2f);
    }
}
