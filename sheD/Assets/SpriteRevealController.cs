
using UnityEngine;

public class SpriteRevealController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private float _fillAmount;

    void Update()
    {
        spriteRenderer.material.SetFloat("_Fill", _fillAmount);
    }
    
    public void SetFillAmount(float value)
    {
        _fillAmount = value;
    }
}

