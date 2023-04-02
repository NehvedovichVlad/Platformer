using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private Image _damageImage;

    public void StartEffect()
    {
        StartCoroutine(ShowEffect()); 
    }
    private IEnumerator ShowEffect()
    {
        _damageImage.enabled = true;

        for (float t = 1; t > 0f; t -= Time.deltaTime)
        {
            _damageImage.color = new Color(1, 0, 0, t);

            yield return null;
        }

        _damageImage.enabled = false;
    }
}
  