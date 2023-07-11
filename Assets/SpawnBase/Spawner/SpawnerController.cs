using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private List<Instruction> instructions = new List<Instruction>();
        // Start is called before the first frame update
        void Start(){
            StartCoroutine(SpawnWave());
        }

        // Update is called once per frame
        void Update()
        {

        }

        private IEnumerator SpawnWave()
        {
            Debug.Log("Spawning wave");
            foreach (Instruction instruction in instructions){
                for (int i = 0; i < instruction.ammount; i++){
                    Instantiate(instruction.gameObject, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(instruction.secondsBetweenSpawn);
                }
                yield return new WaitForSeconds(instruction.secondsForNextInstruction);
            }
        }
    }

}
