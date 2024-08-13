using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.PowerUps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public float JumpForce
    {
        get => jumpForce;
        set => jumpForce = value;
    }


    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 150000f;
    [SerializeField] Camera playerCamera;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] private InputReader inputReader;
    private Vector2 inputDirection;
    private Vector3 lastMovement;

    private bool isGrounded = true;

    void Awake()
    {
        inputReader.jumpEvent += Jump;
        inputReader.moveEvent += HandleMove;
    }

    private void HandleMove(Vector2 direction)
    {
        inputDirection = direction;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var horizontalVector = inputDirection.x * playerCamera.transform.right;
        var verticalVector = inputDirection.y * playerCamera.transform.forward;

        Vector3 newMovement = horizontalVector + verticalVector;
        newMovement.y = 0;

        if (lastMovement == Vector3.zero && newMovement != Vector3.zero)
        {
            RotatePlayer();
        }

        lastMovement = newMovement;

        var move = newMovement * (speed * Time.deltaTime);
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void RotatePlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(playerCamera.transform.forward);
        rb.transform.rotation = rotation;
    }
}