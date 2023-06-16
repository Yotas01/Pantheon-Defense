using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace{
    public class ArrowController : MonoBehaviour{


        [SerializeField] public Rigidbody2D rb;
        public Transform target;
        public int damage;
        public float projectileSpeed = 6f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update(){
        }

        void FixedUpdate() {
            if (target != null){
                Vector2 direction = (target.position - transform.position).normalized;
                transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
                rb.velocity = direction * projectileSpeed;
            }
        }

        //Check if the arrow collides with an enemy
        void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.tag == "Enemy")
            {
                IEnemyBehaviour enemyBehaviour = other.GetComponent<IEnemyBehaviour>();
                enemyBehaviour.damage(damage);
                Destroy(gameObject);
            }
        }

        //If the arrow hasn't hit an enemy, destroy it after 5 seconds
        void OnBecameInvisible(){
            Destroy(gameObject, 5f);
        }
    }

}