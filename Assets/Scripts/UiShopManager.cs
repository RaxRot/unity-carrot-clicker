using System;
using TMPro;
using UnityEngine;

public class UiShopManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField]private RectTransform shopPanel;

    [SerializeField] private TextMeshProUGUI totalCarrots;
    
    [Header("Settings")]
    private Vector2 openPosition;
    private Vector2 closePosition;
    
    private void OnEnable()
    {
        CarrotManager.onCarrotChanged += UpdateCarrotText;
    }

    private void OnDisable()
    {
        CarrotManager.onCarrotChanged -= UpdateCarrotText;
    }

    private void UpdateCarrotText(double value)
    {
        totalCarrots.text = value.ToString();
    }

    private void Start()
    {
        openPosition=Vector2.zero;
        closePosition = new Vector2(shopPanel.rect.width, 0);
        
        shopPanel.anchoredPosition = closePosition;
    }

    public void OpenShop()
    {
        LeanTween.cancel(shopPanel);
        LeanTween.move(shopPanel, openPosition, 0.5f).setEase(LeanTweenType.easeInOutSine);
    }

    public void CloseShop()
    {
        LeanTween.cancel(shopPanel);
        LeanTween.move(shopPanel, closePosition, 0.5f).setEase(LeanTweenType.easeInOutSine);
    }
}
