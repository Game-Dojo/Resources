using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public enum AmmoType
    {
        Fire,
        Ice
    }
    
    [SerializeField] private AmmoType ammoType = AmmoType.Fire;
}
