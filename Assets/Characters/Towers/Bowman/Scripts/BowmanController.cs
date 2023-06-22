using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyNamespace
{
    public class BowmanController : MonoBehaviour
    {

        [SerializeField] private GameObject projetilePrefab;
        private GameObject targetObject;
        private Transform target;
        [SerializeField] private int damage;

        // Start is called before the first frame update
        void Start()
        {
            targetObject = GameObject.FindGameObjectWithTag("Enemy");
            target = targetObject.transform;
            InvokeRepeating("ShootProjectile", 0f, 2f);
        }

        // Update is called once per frame
        void Update(){
            if(targetObject == null){
                targetObject = GameObject.FindGameObjectWithTag("Enemy");
                target = targetObject.transform;
            }
        }

        private void ShootProjectile()
        {
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
