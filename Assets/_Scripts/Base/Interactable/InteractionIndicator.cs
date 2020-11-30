using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.MobackTest.Base.Interactable
{
    public class InteractionIndicator : MonoBehaviour
    {
        private bool hasCollided = false;
        public string labelText = string.Empty;

        private Transform playerXfornm;

        private void Update()
        {
            if (hasCollided)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    gameObject.GetComponent<WhiteBoard>().OnInteractEnter(playerXfornm);
                }
            }
        }

        private void OnGUI()
        {
            if (hasCollided == true)
            {
                GUIStyle textSize = new GUIStyle("box");
                textSize.fontSize = 25;
                GUI.Box(new Rect(140, Screen.height - 50, Screen.width - 300, 120), labelText, textSize);
            }
        }

        private void OnTriggerEnter(Collider c)
        {
            if (c.gameObject.tag == "Player")

            {
                hasCollided = true;
                playerXfornm = c.gameObject.transform;
                labelText = "Press E to draw on the board!";
            }
        }

        private void OnTriggerExit(Collider other)
        {
            hasCollided = false;
        }
    }
}

