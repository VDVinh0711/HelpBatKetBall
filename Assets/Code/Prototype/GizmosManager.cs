using UnityEngine;

public class GizmosManager : Singleton<GizmosManager>
{
   [field:SerializeField] public bool IsDrawGizmos { get; private set; } = true;
}