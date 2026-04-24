using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference clickAction;
    
    [SerializeField] private Transform marker;
    
    private NavMeshAgent _agent;
    private LineRenderer _lineRenderer;
    
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    private void OnEnable()
    {
        clickAction.action.performed += OnClick;
    }
    
    private void OnDisable()
    {
        clickAction.action.performed -= OnClick;
    }
    
    private void OnClick(InputAction.CallbackContext obj)
    {
        var mainCamera = Camera.main;
        var ray = mainCamera.ScreenPointToRay(moveAction.action.ReadValue<Vector2>());
        if (!Physics.Raycast(ray, out RaycastHit hit)) return;
        if (!hit.collider) return;
        
        marker.position = new Vector3(hit.point.x, 0, hit.point.z);
        
        if (NavMesh.SamplePosition(hit.point, out NavMeshHit navMeshHit,10, NavMesh.AllAreas))
        {
            _agent.SetDestination(hit.point);    
        }
        
        Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 10f);
    }

    public void SetLineDestination(Vector3 destination)
    {
        _lineRenderer.SetPosition(1, destination);
    }
}
