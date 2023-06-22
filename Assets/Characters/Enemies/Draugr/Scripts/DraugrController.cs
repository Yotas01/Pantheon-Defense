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
        [SerializeField] private Vector3 destination;
        public Transform[] waypoints { get; set; }
        [SerializeField] public int health;
        private int currentWaypointIndex = 0;

        // Start is called before the first frame update
        void Start()
        {
            moveSpeed = moveSpeed * 0.001f;
            rb = GetComponent<Rigidbody2D>();
            gameObject.tag = "Enemy";
            GameObject[] waypointObjects = GameObject.FindGameObjectsWithTag("Waypoint");
            waypoints = waypointObjects.ToList().OrderBy(obj => obj.name).Select(obj => obj.transform).ToArray();
        }

        // Update is called once per frame
        void Update(){
            moveToWaypoint();
            if (health <= 0)
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
            health -= damage;
        }

        public void heal(int heal)
        {
            health += heal;
        }
    }

}