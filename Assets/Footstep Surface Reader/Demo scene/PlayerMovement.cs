using UnityEngine;

namespace FSR
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Camera _camera;
        [SerializeField] private float speed = 1;
        [SerializeField] private float jumpForce = 1;
        [SerializeField] private float sensitivity = 1;
        [SerializeField] private FSR_Player fSR_Player;
        [SerializeField] private float stepfrequency = 0.5f;
        private float stepTimer;
        float rotationX = 0F;
        float rotationY = 0F;
        private Vector2 inputDirection;

        void FixedUpdate()
        {
            inputDirection = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                inputDirection.y += 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                inputDirection.x -= 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                inputDirection.y -= 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                inputDirection.x += 1;
            }

            inputDirection.Normalize();

            _rigidbody.velocity = transform.TransformDirection(new Vector3(inputDirection.x, _rigidbody.velocity.y / speed, inputDirection.y)) * speed;


            if (Input.GetKey(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector3.up * jumpForce);
            }
        }

        private void Update()
        {
            stepTimer += Time.deltaTime;
            if (stepTimer > stepfrequency && _rigidbody.velocity.magnitude > 0.1f)
            {
                stepTimer = 0;
                fSR_Player.step();
            }

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            rotationY += Input.GetAxis("Mouse X") * sensitivity;
            rotationX += Input.GetAxis("Mouse Y") * sensitivity;

            transform.eulerAngles = new Vector3(0, rotationY, 0);

            rotationX = Mathf.Clamp(rotationX, -45, 45);

            _camera.transform.eulerAngles = new Vector3(-rotationX, _camera.transform.eulerAngles.y, _camera.transform.eulerAngles.z);
        }
    }
}
