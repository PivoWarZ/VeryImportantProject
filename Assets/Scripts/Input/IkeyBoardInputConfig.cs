using UnityEngine;

namespace ShootEmUp
{ 
    internal interface IkeyBoardInputConfig
    {
        public KeyCode Shoot { get; }
        public KeyCode Left { get;}
        public KeyCode Right { get;}
    }
}