using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Image _foreground;
    [SerializeField] private Text _text;

    public void StartCharge()
    {
        _background.color = new Color(1, 1, 1, 0.2f);
        _foreground.enabled = true;
        _text.enabled = true;
    }

    public void StopCharge()
    {
        _background.color = new Color(1, 1, 1, 1f);
        _foreground.enabled = false;
        _text.enabled = false;
    }

    public void SetChargeValue(float currentCharge, float maxCharge)
    {
        _foreground.fillAmount = currentCharge / maxCharge;
        _text.text = Mathf.Ceil(maxCharge - currentCharge).ToString();
    }
    
}
