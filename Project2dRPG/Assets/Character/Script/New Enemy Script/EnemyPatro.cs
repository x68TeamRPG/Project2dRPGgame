using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveDistance = 2f;     // 動く幅
    public float moveSpeed = 2f;        // 動く速さ

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = startPos + new Vector3(offset, 0, 0);
    }
}