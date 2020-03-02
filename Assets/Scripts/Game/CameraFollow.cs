using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 摄像机跟踪
/// </summary>
public class CameraFollow : MonoBehaviour
{
    private Transform target;   //玩家
    private Vector3 offset; 
    private Vector2 velocity;

    private void Update()
    {
        if (target == null && GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            offset = target.position - transform.position;
        }
    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            //平滑移动
            float posX = Mathf.SmoothDamp(transform.position.x,
                target.position.x - offset.x, ref velocity.x, 0.05f);
            float posY = Mathf.SmoothDamp(transform.position.y,
               target.position.y - offset.y, ref velocity.y, 0.05f);
            //防止抖动
            if (posY > transform.position.y)
                transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }
}
