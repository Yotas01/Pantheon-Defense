using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace MyNamespace
{
    public class DraugrController : MonoBehaviour, IEnemyBehaviour
    {

        [SerializeField] private float moveSpeed;
        [SerializeField] private Rigidbody2D rb;
        public Transform[] waypoints { get; set; }
        [SerializeField] public int maxHealth;
        public int currentHealth;
        [SerializeField] public HealthBar healthBar;
        private int currentWaypointIndex = 0;

        private void Awake() {
            rb = GetComponent<Rigidbody2D>();
            healthBar = GetComponentInChildren<HealthBar>();
            currentHealth = maxHealth;
            Debug.Log("Max health: " + maxHealth + " current health: " + currentHealth);
        }

        // Start is called before the first frame update
        void Start()
        {
            moveSpeed = moveSpeed * 0.001f;
            gameObject.tag = "Enemy";
            GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");
            waypoints = waypointObjects.ToList().OrderBy(obj => obj.name).Select(obj => obj.transform).ToArray();
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }

        // Update is called once per frame
        void Update(){
            moveToWaypoint();
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void moveToWaypoint(){
            if (waypoints.Length > 0 && currentWaypointIndex < waypoints.Length)
            {
                // Calculate direction towards the current waypoint
                Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
                direction.Normalize();
                // Move the enemy towards the current waypoint
                transform.Translate(direction * moveSpeed);
                // Check if the enemy has reached the current waypoint and update the currentWaypointIndex
                if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f){
                    currentWaypointIndex++;
                }
            }

        }

        public void damage(int damage)
        {
            currentHealth -= damage;
            Debug.Log("Max health: " + maxHealth + " current health: " + currentHealth);
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }

        public void heal(int heal)
        {
            currentHealth += heal;
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }

}