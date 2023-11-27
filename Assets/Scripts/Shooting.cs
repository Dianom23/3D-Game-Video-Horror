using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _distance = 100;
    [SerializeField] private LayerMask _shootingLayer;
    [SerializeField] private Animator _pistolAnimator;
    [SerializeField] private float _shotDelay = 0.3f;
    [SerializeField] private ParticleSystem _muzzleFlash;
    [SerializeField] private AudioSource _audioSource;

    private float _timerShotDelay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timerShotDelay += Time.deltaTime;


        if (Input.GetMouseButtonDown(0) && _timerShotDelay >= _shotDelay)
        {
            _timerShotDelay = 0;
            _pistolAnimator.SetTrigger("Shot");
            _muzzleFlash.Play();
            _audioSource.Play();

            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _shootingLayer))
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
