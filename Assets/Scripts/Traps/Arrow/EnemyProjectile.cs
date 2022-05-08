using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : EnemyDamage 
{
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifeTime;
    
    public void ActiveProjectile()
    {
        lifeTime = 0;
        gameObject.SetActive(true);
    }
    void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision); //Execute logic from parent script first
        gameObject.SetActive(false);//When this hits any oject deactivate this
    }
}
