﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.MobackTest.Base.Player
{
    public class FPMovement : MonoBehaviour
    {
        [SerializeField] float speed;
        Rigidbody rb;
        [SerializeField] float sprintMultiplier = 1.5f;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (StateManager.instance.PlayerState == StateManager.State.GamePlay)
            {
                float x = Input.GetAxisRaw("Horizontal");
                float z = Input.GetAxisRaw("Vertical");

                Vector3 moveBy = transform.right * x + transform.forward * z;

                float actualSpeed = speed;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    actualSpeed *= sprintMultiplier;
                }

                rb.MovePosition(transform.position + moveBy.normalized * actualSpeed * Time.deltaTime);
            }
        }

    }
}

