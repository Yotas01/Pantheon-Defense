using System.Security.AccessControl;
using UnityEngine;

namespace MyNamespace
{
    [System.Serializable]
    public class Instruction
    {
        public int ammount;
        public GameObject gameObject;
        public Instruction(int ammount, GameObject gameObject)
        {
            this.ammount = ammount;
            this.gameObject = gameObject;
        }
    }
}
