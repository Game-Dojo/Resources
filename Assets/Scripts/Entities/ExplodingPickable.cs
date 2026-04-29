using UnityEngine;

public class ExplodingPickable : PickableItem
{
    [SerializeField] private GameObject explodingEffect;
    protected override void Interaction()
    {
        var randomPoints = Random.Range(10, 20);
        EventManager.OnItemPicked(randomPoints);
        if (explodingEffect)
        {
            GameObject explosion = Instantiate(explodingEffect, transform.position + Vector3.up * 0.6f, Quaternion.identity);
            explosion.transform.localScale = new Vector3(10,10,10);
        }
        Destroy(this.gameObject);
    }
}
