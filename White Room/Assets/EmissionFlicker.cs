using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionFlicker : MonoBehaviour
{
    private Renderer render;
    private Material material;
    public bool isFlickering = false;
    public float timeDelay;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        material = render.material;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFlickering == false)
        {
            StartCoroutine(FlickeringEmission());
        }
    }

    IEnumerator FlickeringEmission()
    {
        isFlickering = true;
        material.DisableKeyword("_EMISSION");
        timeDelay = Random.Range(0.1f, 0.3f);
        yield return new WaitForSeconds(timeDelay);
        material.EnableKeyword("_EMISSION");
        timeDelay = Random.Range(0.1f, 0.3f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;

    }
}
