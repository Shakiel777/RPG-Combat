// Copyright 2017 - David Rood
// A-Gen-C Entertainment (AGC)
// Shakiel@roadrunner.com

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;

    float damageInflicted;

    public void SetDamage(float damage)
    {
        damageInflicted = damage;
    }

    void OnTriggerEnter(Collider collider)
    {
        Component damageableComponent =  collider.gameObject.GetComponent(typeof(IDamageable));
        // print("damageableComponent = " + damageableComponent);

        if (damageableComponent)
        {
            (damageableComponent as IDamageable).TakeDamage(damageInflicted);
        }
        Destroy(gameObject);
    }

}
