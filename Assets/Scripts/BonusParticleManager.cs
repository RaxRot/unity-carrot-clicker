using System;
using UnityEngine;
using UnityEngine.Pool;

public class BonusParticleManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject bonusParticlePrefab;
    [SerializeField] private float timeToDestroyBonus = 1f;
    
    [Header("Pooling")]
    private ObjectPool<GameObject> bonusParticlesPool;

    private void Start()
    {
        bonusParticlesPool = new ObjectPool<GameObject>(CreateFunction,ActionOnGet,ActionOnRelease,ActionOnDestroy);
    }
    
    private GameObject CreateFunction()
    {
        return Instantiate(bonusParticlePrefab,transform);
    }
    private void ActionOnGet(GameObject bonusParticle)
    {
        bonusParticle.SetActive(true);
    }
    
    private void ActionOnRelease(GameObject bonusParticle)
    {
        bonusParticle.SetActive(false);
    }
    private void ActionOnDestroy(GameObject bonusParticle)
    {
        Destroy(bonusParticle);
    }
    

    private void OnEnable()
    {
        InputManager.onCarrotClickedPosition += CarrotClickedCallback;
    }

    private void OnDisable()
    {
        InputManager.onCarrotClickedPosition -= CarrotClickedCallback;
    }

    private void CarrotClickedCallback(Vector2 position)
    {
        GameObject bonusParticleInst = bonusParticlesPool.Get();
        bonusParticleInst.transform.position = position;
        LeanTween.delayedCall(1,()=> bonusParticlesPool.Release(bonusParticleInst));
    }
}
