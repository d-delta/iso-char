using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class playermove : MonoBehaviour
{
    // Start is called before the first frame update

    
    public bool moving = false;
    public bool attacking = false;
    public bool inCombatRange = false;
    public CombatRangeTrigger combatRangeTrigger;
    public GameObject target;
    public string order = "";
    public float attackTimer = 2.0f;
    public float maxAttackTimer = 2.0f;
    public float maxHealth = 99999;
    public float health;

    public Text playerHealthText;



    public NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent < NavMeshAgent >();
        health = maxHealth;


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1)){
            RaycastHit hit;


            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)){
                // agent.destination = hit.point;
                print(hit.collider.gameObject.tag);

                if (hit.collider.gameObject.tag == "EN"){
                    order = "attack";
                    target = hit.collider.gameObject;
                }

                if (hit.collider.gameObject.tag == "FLOOR"){
                    order = "move";
                    this.move(hit);
                }
            }
        }
        if (order == "attack"){
            agent.destination = target.transform.position;
            if (combatRangeTrigger.enemiesInRange.Contains(target)){
                agent.isStopped = true;
                attacking = true;
                
            }
            else {
                agent.isStopped = false;
                attacking = false;
            }
        }
        else {
            attacking = false;
        }


        // if (moving){
        //     agent.isStopped = false;
        // }
        // else{
        //     agent.isStopped = true;
        // }

        if (attacking){
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0){
                target.GetComponent< Enemy >() .health -= 1;
                attackTimer = maxAttackTimer;
            }
        }

        playerHealthText.text = health.ToString();

    }

    public void move(RaycastHit hit){
        agent.isStopped = false;
        agent.destination = hit.point;

    }

    public void takDamage(float damage){
        health -= damage;
    }

    public void EndCombat(){

        order = "";
        target = null;

    }
}
