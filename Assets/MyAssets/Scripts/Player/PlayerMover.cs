using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMover : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 3.5f;
    float cameraPitch = 0.0f;
    [SerializeField] Camera pCam;
    [SerializeField] bool lockCursor = true;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField] CharacterController controller = null;
    [SerializeField] float sprintSpeed = 12f;
    [SerializeField] float Walkfastness;
    [SerializeField] [Range(0f, 0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] [Range(0f, 0.5f)] float mouseSmoothTime = 0.3f;
    Rigidbody rb;

    float velocityY = 0.0f;

    public Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Walkfastness += walkSpeed;
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
        
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);
        pCam.transform.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement()
    {
        if (Input.GetButton("Sprint") == true)
        {

            Walkfastness = sprintSpeed;
        }
        else
        {
            Walkfastness = walkSpeed;
        }

        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (controller.isGrounded)
            velocityY = 0.0f;

        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * Walkfastness + Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);
    }

   
}

   


