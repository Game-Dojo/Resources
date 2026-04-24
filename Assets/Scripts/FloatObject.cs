using DG.Tweening;
using UnityEngine;

public class FloatObject : MonoBehaviour
{
    [SerializeField] private float positionVariationRange = 0.2f;
    private const float MaxDuration = 5.0f;
    
    private void Start()
    {
        var duration = Random.Range(3.5f, MaxDuration);
        transform.DOMoveY(positionVariationRange * -1.0f, duration).SetRelative().SetEase(Ease.InQuad).SetLoops(-1, LoopType.Yoyo);
    }
}
