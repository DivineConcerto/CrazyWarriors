using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerController : MonoBehaviour
{
    [Header("基本组件")]
    private Rigidbody2D rd;
    public PlayerInputControl inputSystem;
    [Header("基本参数")]
    public float speed;
    public Vector2 direction;
    public float jumpForce;
    [Header("角色状态")]
    public bool isGround;
    
    // 程序流程
    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        inputSystem = new PlayerInputControl();
        inputSystem.Player.Jump.started += Jump;

    }
    private void OnEnable()
    {
        inputSystem.Enable();
       
    }
    private void OnDisable()
    {
        inputSystem.Disable();
    }
    private void Update()
    {
        direction = inputSystem.Player.Move.ReadValue<Vector2>();

    }
    private void FixedUpdate()
    {
        Move();
        CheckState();
    }

    // 角色行为
    private void Move()
    {
       rd.velocity = new Vector2 (direction.x * speed * Time.deltaTime, rd.velocity.y);
    }
    private void CheckState()
    {
        if (direction.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        if (direction.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
    }
    private void Jump(InputAction.CallbackContext obj)
    {
        if (isGround == false)
            return;
        rd.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }


}
