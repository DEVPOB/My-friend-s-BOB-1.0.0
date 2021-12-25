using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    private Vector2 mouseDirection;
    public Camera sceneCamera;
    public Weapon weapon;
    public CameraMain cam;
    public float cooldown;
    float lastshot;
    [SerializeField] GameObject player;
    [SerializeField] GameObject pausemenu;
    void Update()
    {
        ProcessInputs();
    }
    void FixedUpdate()
    {
        move();

    }
    void ProcessInputs()
    {
        // Player movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
        // Movemouse position
        mouseDirection = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastshot < cooldown)
            {
                return;
            }
            lastshot = Time.time;
            weapon.Fire();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausemenu.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;
            Time.timeScale = 0f;
        }

    }
    void move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
        Vector2 aimDirection = mouseDirection - rb.position;
        float aimangle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimangle;

    }

}
