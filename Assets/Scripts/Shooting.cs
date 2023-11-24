using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _distance = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance))
            {
                print(hitInfo.collider.name);

                if (hitInfo.collider.TryGetComponent(out Enemy enemy))
                    enemy.GetDamage(1);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance))
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(ray.origin, ray.direction * _distance);
            Gizmos.DrawSphere(hitInfo.point, 0.1f);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray.origin, ray.direction * _distance);
        }
    }
}
