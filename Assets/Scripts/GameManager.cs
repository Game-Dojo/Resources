using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private int _cannonBalls = 0;
    
    private void Awake()
    {
        if (!_instance)
            _instance = this;
        else
            Destroy(this.gameObject);
        
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
        EventManager.ItemPicked += OnItemPicked;
    }
    
    private void OnDisable()
    {
        EventManager.ItemPicked -= OnItemPicked;
    }
    
    private void OnItemPicked(int bulletsCount)
    {
        _cannonBalls += bulletsCount;
        EventManager.OnScoreUpdate(_cannonBalls);
        print("Event Score Update");
    }


    public static GameManager GetInstance() => _instance;
}
