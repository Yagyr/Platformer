using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private Image _damageImage;

    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }
    private IEnumerator ShowEffect()
    {
        for (float t = 1; t > 0; t -= Time.deltaTime * 2f)
        {
            _damageImage.enabled = true;
            _damageImage.color = new Color(0.4905f, 0f, 0f, t);
            yield return null;
        }
        _damageImage.enabled = false;
    }
}
