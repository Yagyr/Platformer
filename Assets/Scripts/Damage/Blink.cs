using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;

    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }
    private IEnumerator BlinkEffect()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            Color color = new Color(Mathf.Sin(t * 15) * 0.5f + 0.5f, 0, 0, 0);
            SetColor(color);
            yield return null;
        }
        SetColor(Color.black);
    }

    private void SetColor(Color color)
    {
        for (int i = 0; i < _renderers.Length; i++)
        {
            for (int j = 0; j < _renderers[i].materials.Length; j++)
            {
                _renderers[i].materials[j].SetColor("_EmissionColor", color);
            }
        }
    }
}
