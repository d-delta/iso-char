using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float health = 5;
    public float maxHealth = 5;
    public float damage = 2;
    
    public float attackTimer;
    public float maxAttackTimer = 3.0f;
    private AggroRange aggroRange;
    private NavMeshAgent navMeshAgent;
    public string order = "idle";



    public EnemyCombatRangeTrigger enemyCombatRange;

    public Text healthtxt;

    void Start()
    {
        attackTimer = maxAttackTimer;
        aggroRange = transform.GetChild(0).GetComponent<AggroRange>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyCombatRange = transform.GetChild(1).GetComponent<EnemyCombatRangeTrigger>();
    }

    // Update is called once per frame
    void Update()
    {

        if(enemyCombatRange.enemiesInRange.Count >= 1){
            order = "attack";

        }
        else if(aggroRange.target != null){
            order = "chase";
        }

        else{
            order = "idle";
        }


        if(order == "chase"){
            navMeshAgent.isStopped = false;
            navMeshAgent.destination = aggroRange.target.transform.position;
        }

        if(order == "attack"){
            navMeshAgent.isStopped = true;
            attackTimer -= Time.deltaTime;

            if(attackTimer <= 0){
                aggroRange.target.GetComponent<playermove>().takDamage(damage);
                attackTimer = maxAttackTimer;
            }
        }

        healthtxt.text = health.ToString();
        healthtxt.rectTransform.eulerAngles = new Vector3(0, transform.localRotation.y - 45, 0);


      

        if(health < 1){
            Destroy(this.gameObject);
        }        
    }

    public void takeDamage(float damage){
        health -= damage;
    }

    private void OnDestroy(){

        aggroRange.target.GetComponent<playermove>().EndCombat();
    }


}
