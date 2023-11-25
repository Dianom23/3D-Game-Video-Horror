using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _distance = 100;
    [SerializeField] private Animator _pistolAnimator;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _delayShot = 1f;

    private float _timer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && _timer >= _delayShot)
        {
            _timer = 0;

            Ray ray = new Ray(transform.position, transform.forward);
            _pistolAnimator.SetTrigger("Shot");
            _muzzleFlash.Play();
            _audioSource.Play();

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
