using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private Transform cameraPivot;

    private Vector2 moveInput;
    private Vector2 lookInput;
    private float xRotation;
    private Rigidbody rigid;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();

        //Cursor.lockState = CursorLockMode.Locked;     // 마우스 잠그기
        //Cursor.visible = false;                       // 마우스 잠그기
    }

    public override void OnStartClient()
    {
        if (IsOwner)
        {
            GetComponent<PlayerInput>().enabled = true;
        }
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    private void Update()
    {
        if (IsOwner)
        {
            Look();
        }
    }

    private void FixedUpdate()
    {
        if (IsOwner)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 dir = transform.forward * moveInput.y + transform.right * moveInput.x;
        rigid.MovePosition(rigid.position + dir * moveSpeed * Time.fixedDeltaTime);
    }

    void Look()
    {
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 70f);
        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
