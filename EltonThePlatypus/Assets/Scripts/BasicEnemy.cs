using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public bool isActive;
    public float cooldownTime;
    private float currentCooldown;
    public GameObject projectilePrefab;
    void Start()
    {
        currentCooldown = cooldownTime;
    }

    void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
            return;
        }

        Instantiate(projectilePrefab,transform.position, Quaternion.identity, null);
        currentCooldown = cooldownTime;
    }
}
