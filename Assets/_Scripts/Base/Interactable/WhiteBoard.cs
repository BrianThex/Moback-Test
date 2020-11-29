using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.MobackTest.Base.Interactable
{
    public class WhiteBoard : Interactable
    {
        public override void OnInteractEnter(Transform playerPos = null)
        {

            SetCameraView(playerPos);

            EnableDrawMode();
        }

        public override void OnInteractExit(Transform playerPos = null)
        {
            throw new System.NotImplementedException();
        }

        private void EnableDrawMode()
        {   //enable ability draw mode
            //set autosave listeners

        }

        private void SetCameraView(Transform playerPos)
        {

        }
    }

}

