using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float lookSpeed = 2f;

    private float horizontalInput;
    private float verticalInput;
    private float mouseXInput;
    private float mouseYInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndLook();
        CheckForCursor();
    }

    private void MoveAndLook()
    {
        // get input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        mouseXInput = Input.GetAxis("Mouse X");
        mouseYInput = Input.GetAxis("Mouse Y");

        // move camera
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        transform.position += moveSpeed * Time.deltaTime * moveDirection;

        // look around
        transform.Rotate(Vector3.up, mouseXInput * lookSpeed, Space.World);
        transform.Rotate(Vector3.left, mouseYInput * lookSpeed, Space.Self);

        // fly up and down with space and left ctrl
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.up;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.down;
        }
    }

    private void CheckForCursor()
    {
        // unlock and show the cursor when Escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }
}
