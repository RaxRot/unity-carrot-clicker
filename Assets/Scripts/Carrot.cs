using System;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform carrot;
    private void OnEnable()
    {
        InputManager.onCarrotClicked += CarrotClickedCallBack;
    }

    private void OnDisable()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallBack;
    }

    private void CarrotClickedCallBack()
    {
        LeanTween.cancel(carrot.gameObject);

        carrot.localScale = Vector3.one*0.7f;

        LeanTween.scale(carrot.gameObject, Vector3.one * 0.85f, 0.08f)
            .setEase(LeanTweenType.easeOutQuad)
            .setLoopPingPong(1);
    }
}
