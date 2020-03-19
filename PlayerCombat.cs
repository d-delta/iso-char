using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    playermove pm;

    bool moveSpeedBuff = false;

    float maxMoveSpeedTimer = 10;
    float moveSpeedTimer;

    List <GameObject> AOEhits;

    // Start is called before the first frame update

    void Start()
    {

        pm = GetComponent<playermove>();

        moveSpeedTimer = maxMoveSpeedTimer;

        AOEhits = new List<GameObject>();


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q) && !moveSpeedBuff)
        {

            moveSpeedBuff = true;
            pm.agent.speed += 2.5f;

        }
        if (moveSpeedBuff)
        {
            moveSpeedTimer -= Time.deltaTime;
            if(moveSpeedTimer <= 0)
            {
                moveSpeedBuff = false;
                pm.agent.speed -= 2.5f;
                moveSpeedTimer = maxMoveSpeedTimer;
            }
        }



        
    }
}
