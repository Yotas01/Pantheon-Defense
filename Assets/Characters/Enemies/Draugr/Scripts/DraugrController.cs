using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public class DraugrController : MonoBehaviour, IEnemyBehaviour
    {

        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Rigidbody2D rb;
        public int health { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            gameObject.tag = "Enemy";
            health = 100;
        }

        // Update is called once per frame
        void Update()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveY = Input.GetAxis("Vertical");

            rb.velocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void damage(int damage)
        {
            health -= damage;
        }

        public void heal(int heal)
        {
            health += heal;
        }
    }

}