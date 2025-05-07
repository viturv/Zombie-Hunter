    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AI;
    using UnityEngine.UIElements;

    public class EnemyAI : MonoBehaviour
    {
        Transform Target;
        [SerializeField] float ChaseRange= 5f;
        [SerializeField] float lookspeed = 1f;
        string targetTag = "Player";

        NavMeshAgent navMeshAgent;
        float DistanceToTarget;
        bool IsProvoked;


        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            Target = GameObject.FindWithTag(targetTag)?.transform;
        }
        
        
        void Update()
        {
        
            DistanceToTarget = Vector3.Distance(Target.position, transform.position);

            if(IsProvoked)
            {
                EngageTarget();
            }        
            else if (DistanceToTarget <= ChaseRange)
            {
                IsProvoked = true;
            }
        }

        public void EnemyDamageTaken()
        {
            IsProvoked = true;
        }

        private void EngageTarget()
        {
            FaceTarget();
            if(DistanceToTarget>= navMeshAgent.stoppingDistance)
            {
                ChaseTarget();
            }

            if(DistanceToTarget<=navMeshAgent.stoppingDistance)
            {
                AttackEnemy();   
            }
        }

        private void ChaseTarget()
        {
            GetComponent<Animator>().SetBool("attack",false);
            GetComponent<Animator>().SetTrigger("move");
            navMeshAgent.SetDestination(Target.position);
        }


        private void AttackEnemy()
        {
            GetComponent<Animator>().SetBool("attack",true);   
        }

        private void FaceTarget()
        {
            Vector3 direction = (Target.position - transform.position).normalized;
            Quaternion lookrotation = Quaternion.LookRotation(new Vector3 (direction.x , 0 , direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation , lookrotation , Time.deltaTime* lookspeed);
        }

        void OnDrawGizmos()
        {
            Gizmos.color= new Color(1, 0, 0, 1);
            Gizmos.DrawWireSphere(transform.position, ChaseRange);
        }
    }
