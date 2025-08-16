using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPath : MonoBehaviour
{
    [SerializeField] private Color color;
    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = color;
            Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(GetNextIndex(i)));
        }
    }

    public Vector3 GetWaypoint(int i)
    {
        return transform.GetChild(i).position;
    }

    public int GetNextIndex(int i)
    {
        return i + 1 < transform.childCount ? i + 1 : 0;
    }
}
