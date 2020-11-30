using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.MobackTest.Base.Interactable
{
    public abstract class Interactable : MonoBehaviour
    {
        public abstract void OnInteractEnter(Transform playerPos = null);

        public abstract void OnInteractExit(Transform playerPos = null);
    }
}

