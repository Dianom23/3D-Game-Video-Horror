using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 500;
    private float _angle;

    void Start()
    {
        
    }

    void Update()
    {
        float mouseY = Input.GetAxisRaw("Mouse Y");
        _angle += mouseY * _rotateSpeed * Time.deltaTime;
        _angle = Mathf.Clamp(_angle, -40, 40);
        transform.localEulerAngles = Vector3.left * _angle;
    }
}
