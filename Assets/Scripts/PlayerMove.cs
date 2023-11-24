using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private CharacterController _controller;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 moveInput = new Vector2(horizontal, vertical).normalized;
        Vector3 directionMove = new Vector3(moveInput.x, 0, moveInput.y);
        directionMove = transform.TransformDirection(directionMove);
        _controller.SimpleMove(directionMove * _speed);
    }
}
