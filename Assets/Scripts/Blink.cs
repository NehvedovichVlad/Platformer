using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] Renderer [] _renderers;

    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    } 

    private IEnumerator BlinkEffect()
    {
        for (float t = 0; t  < 1; t += Time.deltaTime)
        {
            SetColor(new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));
            yield return null;

        }
        SetColor(Color.clear);
    }

    private void SetColor(Color newColor)
    {
        for (int i = 0; i < _renderers.Length; i++)
        {
            for (int n = 0; n < _renderers[i].materials.Length; n++)
            {
                _renderers[i].materials[n].SetColor("_EmissionColor", newColor);
            }
        }
    }
}
 