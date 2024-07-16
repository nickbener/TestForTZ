using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackRadius = 5f;
    public float fireRate = 1f; // Скорость стрельбы (выстрелов в секунду)
    public int health;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private Rigidbody2D rb;
    private float nextFireTime;

    public GameObject lose;
    public Text healthText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
    }

    void Update()
    {
        Move();
        Attack();
        healthText.text = "HP: " + health.ToString();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(moveX, moveY) * moveSpeed;
        rb.velocity = move;
    }

    void Attack()
    {
        if (Time.time >= nextFireTime)
        {
            Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(transform.position, attackRadius);
            foreach (var enemyCollider in enemiesInRange)
            {
                Enemy enemy = enemyCollider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    Shoot(enemy.transform);
                    nextFireTime = Time.time + 1f / fireRate; // Устанавливаем время следующего выстрела
                    break;
                }
            }
        }
    }

    public void Damage(int dam)
    {
        health -= dam;
        if (health <= 0)
        {
            lose.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void Shoot(Transform enemyTransform)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetTarget(enemyTransform);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}