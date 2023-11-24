using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 500;

    void Start()
    {
        
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        transform.eulerAngles += Vector3.up * mouseX * _rotateSpeed * Time.deltaTime;
    }
}
