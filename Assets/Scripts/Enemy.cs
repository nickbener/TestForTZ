using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public int health;
    public int damage;
    public float minSpeed;
    public float maxSpeed;
    private Transform maxPosition;
    private PlayerController playerController;
    private TextUpdater _textUpdater;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxPosition = GameObject.Find("MaxLine").transform;
        _textUpdater = GameObject.Find("Borders").GetComponent<TextUpdater>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        rb.velocity = Vector2.down * Random.Range(minSpeed, maxSpeed);

        if (transform.position.y <= maxPosition.position.y)
        {
            playerController.Damage(damage);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int _damage)
    {
        health -= _damage;
        if (health <= 0)
        {
            _textUpdater.enCount--;
            Destroy(gameObject);
        }
    }
}