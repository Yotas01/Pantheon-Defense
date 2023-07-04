using System.Security.AccessControl;
using UnityEngine;

namespace MyNamespace
{
    [System.Serializable]
    public class Instruction
    {
        public int ammount;
        public GameObject gameObject;
        public int secondsBetweenSpawn;
        public int secondsForNextInstruction;
        public Instruction(int ammount, GameObject gameObject, int secondsBetweenSpawn, int secondsForNextInstruction)
        {
            this.ammount = ammount;
            this.gameObject = gameObject;
            this.secondsBetweenSpawn = secondsBetweenSpawn;
            this.secondsForNextInstruction = secondsForNextInstruction;
        }
    }
}
