using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LP.MobackTest.Base.Player
{
    public class StateManager : MonoBehaviour
    {
        public static StateManager instance;

        public enum State
        {
            GamePlay,
            DrawBoard
        }

        public State PlayerState;

        // not doing full singleton here
        private void Awake()
        {
            instance = this;
            PlayerState = State.GamePlay;
        }
        

    }
}

