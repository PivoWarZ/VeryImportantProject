using System;
using UnityEngine;

namespace ShootEmUp
{ 
        [Serializable]
        public class InputConfig : IkeyBoardInputConfig
        {
            [SerializeField] private KeyCode _shoot;
            [SerializeField] private KeyCode _left;
            [SerializeField] private KeyCode _right;

            public KeyCode Shoot => _shoot;
            public KeyCode Left => _left;
            public KeyCode Right => _right;
        }
}