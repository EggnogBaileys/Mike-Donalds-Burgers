using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemyAttack : MonoBehaviour
{
    // A modifiable delay. Do Time.time + attackDelay to get attackTime.
    public float attackDelay = 3.0f;


    // If Time.time reaches AttackTime.
    public float attackTime = 0f;

    // Will determine which pattern the enemy chooses to attack with.
    int attackChoice;

    private void Start()
    {
        attackTime = Time.time + attackTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (attackTime != 0 && Time.time >=attackTime)
        {
            attackTime = 0;
            ChooseAttackPattern();
        }

    }

    void ChooseAttackPattern()
    {
        attackChoice = Random.Range(1, 3);
        Attack(attackChoice);
    }

    void Attack(int attackChoice)
    {
        print(attackChoice);
    }
}
