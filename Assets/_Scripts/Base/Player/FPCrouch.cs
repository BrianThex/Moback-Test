﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.MobackTest.Base.Player
{
    public class FPCrouch : MonoBehaviour
    {
        [SerializeField] float crouchHeight;
        [SerializeField] float lyingHeight;
        [SerializeField] float normalHeight;

        void Update()
        {
            if (StateManager.instance.PlayerState == StateManager.State.GamePlay)
            {
                Vector3 newScale = new Vector3(transform.localScale.x, normalHeight, transform.localScale.z);

                if (Input.GetKey(KeyCode.C))
                {
                    newScale.y = crouchHeight;
                }
                else if (Input.GetKey(KeyCode.Z))
                {
                    newScale.y = lyingHeight;
                }

                transform.localScale = newScale;
            }

        }
    }
}

