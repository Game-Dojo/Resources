using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class PickableItem : MonoBehaviour
{
    private SphereCollider _sphereCollider;
    private readonly Vector3 _offsetPosition = new Vector3(0, 0.1f, 0);

    private PlayerController _player;
    private void Awake()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!_player && other.TryGetComponent<PlayerController>(out PlayerController player))
        {
            _player = player;
        }

        if (!_player) return;
        
        transform.SetParent(_player.transform);
        _sphereCollider.enabled = false;
        Pickup();
    }

    private void Pickup()
    {
        transform.DOLocalMove(Vector3.zero, 0.5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            Interaction();
            gameObject.SetActive(false);
        }).OnUpdate(() =>
        {
            _player.SetLineDestination(transform.localPosition + _offsetPosition);
        });
    }

    protected virtual void Interaction()
    {
        var randomPoints = Random.Range(1, 3);
        EventManager.OnItemPicked(randomPoints);
    }

    private void OnDestroy()
    {
        transform.DOKill(true);
    }
}