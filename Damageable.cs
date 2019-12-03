using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [Tooltip("Multiplier to apply to the received damage")]
    [Range(0, 10)]
    public float CriticalDamageMultiplier = 1f;

    public Health health { get; private set; }
    
    
    void Awake()
    {
        // find the health component either at the same level, or higher in the hierarchy
        health = GetComponent<Health>();
        if (!health)
        {
            health = GetComponentInParent<Health>();
        }
    }

    //public void InflictDamage(float damage, bool isCritical, GameObject damageSource)
    public void InflictDamage(float damage, bool isCritical)
    {

        if (health)
        {
            var totalDamage = damage;

            // Critical Hit
            if (!isCritical)
            {
                totalDamage *= CriticalDamageMultiplier;
            }

            // Apply Damage
            //health.TakeDamage(totalDamage, damageSource);
            health.TakeDamage(totalDamage);
        }
    }


}
