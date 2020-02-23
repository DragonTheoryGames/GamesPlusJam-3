using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private EnemySight sight;

    private Vector3 NPCLastSeen;

    private void Start()
    {
        sight = GetComponent<EnemySight>();
    }

    public void FollowTarget()
    {

    }
}
