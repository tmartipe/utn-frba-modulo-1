using System.Collections;
using System.Collections.Generic;
using EnemiesLogic;
using UnityEngine;

public class LichController : EnemyController
{
    public Transform rayOrigin;
    public LineRenderer lineRenderer;
    public float laserDuration;

    protected override void Awake()
    {
        base.Awake();
        lineRenderer = GetComponentInChildren<LineRenderer>();
    }
    protected override void Attack()
    {
        anim.SetTrigger("Attack");
        StartCoroutine(nameof(AttackCoroutine));
    }

    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(.5f);
        RaycastHit hit;
        lineRenderer.SetPosition(0, rayOrigin.position);
        if (Physics.Raycast(rayOrigin.position, player.transform.position- transform.position, out hit, 5f))
        {
            lineRenderer.SetPosition(1, hit.point);
            if (hit.collider.CompareTag("Player"))
            {
                PlayerLife playerLife = hit.collider.GetComponent<PlayerLife>();
                playerLife.TakeDamage(2);
            }
        }
        else
        {
            lineRenderer.SetPosition(1, rayOrigin.position + (transform.forward * 5f));
        }
        StartCoroutine(ShootLaser());
    }

    IEnumerator ShootLaser()
    {
        lineRenderer.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        lineRenderer.enabled = false;
    }
    
}
