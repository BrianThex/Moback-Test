using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.MobackTest.Base.Interactable
{
    public class WhiteBoard : Interactable
    {
        private Vector3 camLastPos;
        public Transform LookPos;

        private void Update()
        {
            if (Player.StateManager.instance.PlayerState == Player.StateManager.State.DrawBoard)
            {
                Camera cam = Camera.main;
                cam.transform.LookAt(LookPos.position);

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    SaveDrawing();
                    OnInteractExit();
                }
            }
        }
        public override void OnInteractEnter(Transform playerPos = null)
        {
            if (playerPos.position.x > gameObject.transform.position.x)
            {
                SetCameraView(1f);
            }
            else
            {
                SetCameraView(-1f);
            }


            EnableDrawMode();
        }

        public override void OnInteractExit(Transform playerPos = null)
        {
            DisableDrawMode();

            Camera cam = Camera.main;
            cam.transform.position = new Vector3(camLastPos.x, camLastPos.y, camLastPos.z);
        }

        private void EnableDrawMode()
        {
            Player.StateManager.instance.PlayerState = Player.StateManager.State.DrawBoard;
            Cursor.lockState = CursorLockMode.None;

            InteractionIndicator iI = gameObject.GetComponent<InteractionIndicator>();
            iI.labelText = "Press Q to Save and Quit!";

            //enable ability draw mode
            //set autosave listeners

        }

        private void DisableDrawMode()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Player.StateManager.instance.PlayerState = Player.StateManager.State.GamePlay;

            InteractionIndicator iI = gameObject.GetComponent<InteractionIndicator>();
            iI.labelText = "Press E to draw on the board!";

            // auto save picture
        }

        private void SetCameraView(float xPos)
        {
            Camera cam = Camera.main;
            camLastPos = cam.transform.position;
            cam.transform.position = new Vector3(gameObject.transform.position.x + xPos, gameObject.transform.position.y + 1, gameObject.transform.position.z -.5f);
        }

        private void SaveDrawing()
        {
            // save drawing
        }
    }

}

