using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalCheck : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D rd;

    [Header("��ⷶΧ")]
    public float checkRadius;
    public LayerMask ground;
    
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        rd = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CheckGround();
    }
    private void CheckGround()
    {
        controller.isGround = Physics2D.OverlapCircle(transform.position, checkRadius, ground);
    }
}
