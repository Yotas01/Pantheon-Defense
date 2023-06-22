using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField]
        private List<Instruction> instructions = new List<Instruction>();
        private float spawnTime = 2f;
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
                    Debug.Log("Spawning " + instruction.gameObject.name + " number " + i+1);
                    Instantiate(instruction.gameObject, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(spawnTime);
                }
            }
        }
    }

}
