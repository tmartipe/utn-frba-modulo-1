using System;
using System.Collections;
using System.Collections.Generic;
using EnemiesLogic;
using Unity.VisualScripting;
using UnityEngine;

public class WarriorController : EnemyController
{
    public float attackRadius;
    public Transform attackPosition;
    protected override void Attack()
    {
        anim.SetTrigger("Attack");
        StartCoroutine(nameof(AttackCoroutine));
    }

    IEnumerator AttackCoroutine()
    {
        yield return new WaitForSeconds(.5f);
        Collider[] colliders = Physics.OverlapSphere(attackPosition.position, attackRadius);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                PlayerLife playerLife = collider.GetComponent<PlayerLife>();
                playerLife.TakeDamage(1);
            }
        }
    }
}
