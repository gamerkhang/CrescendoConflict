﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public GameObject Wave;
    [Tooltip("In units per second. Default is 1.28 #MagicNumber.")]
    public float Speed = 1.28f;

    private Animator animator;
    private Rigidbody2D player;
    private Transform reticle;
    private float lastShot = -1;

    private byte state = 0; //Idle

    void Start() {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        reticle = transform.Find("Reticle");
    }

    public void move(float directionx,float directiony)
    {
        if (directionx == 0 && directiony == 0) //Not moving
        {
            if (state == 1) //Was moving previously
            {
                state = 0;
                animator.Play("Idle");
            }
        }
        else
        {
            player.MovePosition(new Vector2(transform.position.x + Speed * directionx * Time.fixedDeltaTime, transform.position.y + Speed * directiony * Time.fixedDeltaTime));

            if (state == 0)
            {
                state = 1; //Moving
                animator.Play("Walk");
            }
        }
    }

    public void Rotate(int rotate_speed)
    {
        reticle.RotateAround(transform.position, transform.forward, rotate_speed * 20 * Time.deltaTime);
    }

    public void Shoot()
    {
        if (lastShot == -1 || (Time.time - lastShot) > 1)
        {
            Instantiate(Wave, reticle.position, Quaternion.Euler(0, 0, reticle.rotation.eulerAngles.z));
            reticle.GetComponent<Animator>().Play("Charging", 0, 0);
            lastShot = Time.time;
        }
    }
}

