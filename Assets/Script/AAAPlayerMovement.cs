using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAAPlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 控制移动速度
    public float gravity = -9.81f; // 模拟重力
    public CharacterController controller;

    private Vector3 velocity;

    void Start()
    {
        // 获取角色控制器组件
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 获取输入
        float moveX = Input.GetAxis("Horizontal"); // 左右移动
        float moveZ = Input.GetAxis("Vertical");   // 前后移动

        // 修正后的移动方向（忽略X轴旋转的影响）
        Vector3 move = new Vector3(moveX, 0, moveZ);

        // 将世界空间转换为局部空间
        move = transform.TransformDirection(move);

        // 使用 CharacterController 移动玩家
        controller.Move(move * moveSpeed * Time.deltaTime);

        // 添加重力效果
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


}
