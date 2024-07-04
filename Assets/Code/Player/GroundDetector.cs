using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
     private float _groundDetectorDistance = 0.4f;  
    [SerializeField] private LayerMask _groundLayerMask;

    public bool IsGrounded { get; private set; }

    private void Update() => 
        IsGrounded = Physics2D.Raycast(transform.position, Vector2.down, _groundDetectorDistance, _groundLayerMask)
        || Physics2D.Raycast(transform.position, new Vector2(-1,-1), _groundDetectorDistance, _groundLayerMask)
        || Physics2D.Raycast(transform.position, new Vector2(1,-1), _groundDetectorDistance, _groundLayerMask);

    private void OnDrawGizmos()
    {
        if (!GizmosManager.Instance.IsDrawGizmos) return;
        
        Gizmos.color = IsGrounded ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * _groundDetectorDistance);
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(-1,-1,0) * _groundDetectorDistance);
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(1,-1,0) * _groundDetectorDistance);
    }
}
