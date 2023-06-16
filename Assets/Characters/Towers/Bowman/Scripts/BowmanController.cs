using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public class BowmanController : MonoBehaviour
    {

        [SerializeField] private GameObject projetilePrefab;
        private Transform target;
        private int damage = 10;

        // Start is called before the first frame update
        void Start()
        {
            GameObject targetObject = GameObject.FindGameObjectWithTag("Enemy");
            target = targetObject.transform;
            InvokeRepeating("ShootProjectile", 0f, 2f);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void ShootProjectile()
        {
            Debug.Log("Shooting projectile at target:" + target.position + " from position:" + transform.position);
            Vector2 direction = (target.position - transform.position).normalized;
            GameObject projectile = Instantiate(projetilePrefab, transform.position, Quaternion.identity);
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            projectile.transform.rotation = targetRotation;
            projectile.GetComponent<ArrowController>().damage = damage;
            projectile.GetComponent<ArrowController>().target = target;
        }
    }

}
