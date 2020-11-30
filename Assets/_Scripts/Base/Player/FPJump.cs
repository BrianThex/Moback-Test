using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.MobackTest.Base.Player
{
    public class FPJump : MonoBehaviour
    {
        Rigidbody rb;
        [SerializeField] float jumpForce;
        [SerializeField] Transform groundChecker;
        [SerializeField] float checkRadius;
        [SerializeField] LayerMask groundLayer;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (StateManager.instance.PlayerState == StateManager.State.GamePlay)
            {
                if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
            }
        }

        bool IsOnGround()
        {
            Collider[] colliders = Physics.OverlapSphere(groundChecker.position, checkRadius, groundLayer);

            if (colliders.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

