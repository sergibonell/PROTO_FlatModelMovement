using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement3D : MonoBehaviour
{
    private CharacterController controller;
    private PlayerInput input;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private Vector2 relativeMoveInput;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpHeight = 1f;
    [SerializeField] private float bufferThreshhold = 0.5f;

    bool isJumping = false;
    bool bufferedJump = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();

        //input.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputToRelative();

        velocity.x = relativeMoveInput.x * moveSpeed;
        velocity.z = relativeMoveInput.y * moveSpeed;

        if ((isJumping || bufferedJump) && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            isJumping = false;
        }
        else
        {
            velocity.y = controller.isGrounded ? -2f : velocity.y + gravity * Time.deltaTime;
        }
       
        controller.Move(velocity * Time.deltaTime);
    }

    void inputToRelative()
    {
        Vector3 dir = new Vector3(moveInput.x, 0, moveInput.y);
        dir = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * dir;
        relativeMoveInput = new Vector2(dir.x, dir.z);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (controller.isGrounded)
            isJumping = true;
        else
            StartCoroutine(bufferJump());
    }

    IEnumerator bufferJump()
    {
        StopCoroutine(bufferJump());

        bufferedJump = true;
        yield return new WaitForSeconds(bufferThreshhold);
        bufferedJump = false;
    }
}
