using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickableItem : MonoBehaviour
{
    private SphereCollider _sphereCollider;
    private readonly Vector3 _offsetPosition = new Vector3(0, 0.1f, 0);
    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<PlayerController>(out PlayerController player)) return;
        transform.SetParent(player.transform);
        _sphereCollider.enabled = false;

        transform.DOLocalMove(Vector3.zero, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            var randomPoints = Random.Range(1, 3);
            EventManager.OnItemPicked(2);
            print("HOLA");
            gameObject.SetActive(false);
        }).OnUpdate(() =>
        {
            player.SetLineDestination(transform.localPosition + _offsetPosition);
        });
    }
}