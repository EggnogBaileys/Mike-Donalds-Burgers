using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Exclamation mark warning to indicate attack locations.
    public GameObject warning;

    Warning warningScript;


    // Modifiable attack delays. How long the warning shows up before the actual attack.
    public float attackDelay = 1.0f;
    public float attackDelaySlow = 1.5f;
    public float attackDelayFast = 0.75f;

    // Number of attack patterns. Is public, so can be tweaked per enemy type.
    public int attackNumber = 3;

    // Will determine which pattern the enemy chooses to attack with.
    int attackChoice;

    // Floats representing potential places where the enemy can attack (can definitely be increased)
    float leftAttack = -6.5f;
    float middleAttack = 0;
    float rightAttack = 6.5f;


    bool canAttack;


    private void Start()
    {
        warningScript = warning.GetComponent<Warning>();
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (canAttack)
        {
            ChooseAttackPattern();
        }

    }

    void ChooseAttackPattern()
    {
        attackChoice = Random.Range(1, attackNumber+1);
        Attack(attackChoice);
    }



    // This function could be defined within a public script designed for specific enemy types.
    // For now I'll have it here.
    void Attack(int attackChoice)
    {
        canAttack = false;
        print(attackChoice);

        if (attackChoice == 1)
        {
            FullSwipe();
        }
        else if (attackChoice == 2)
        {
            SideSwipes();
        }
        else if (attackChoice == 3)
        {
            SideSwipesMirrored();   
        }
    }

    void FullSwipe()
    {
        // 1 swipe to the left, 1 in the middle, 1 to the right.
        StartCoroutine(FullSwipeC());
    }

    IEnumerator FullSwipeC()
    {
        int attackChance = Random.Range(1, 3);
        if (attackChance == 1)
        {
            warning.transform.position = new Vector3(leftAttack, -1.6f, -4.5f);
        }
        else if (attackChance == 2)
        {
            warning.transform.position = new Vector3(rightAttack, -1.6f, -4.5f);
        }
        yield return new WaitForSeconds(attackDelay);

        // Initiate enemy attack collision. (Set active on current position)
        // Within that collision's script, if the potlid does not enter collision, damage player.

        warning.transform.position = new Vector3(middleAttack, -1.6f, -4.5f);
        yield return new WaitForSeconds(attackDelay);

        // Initiate enemy attack collision. 

        if (attackChance == 1)
        {
            warning.transform.position = new Vector3(rightAttack, -1.6f, -4.5f);
        }
        else if (attackChance == 2)
        {
            warning.transform.position = new Vector3(leftAttack, -1.6f, -4.5f);
        }

        // Initiate enemy attack collision. 

        // Small delay before next attack can start.
        warning.transform.position = new Vector3(-20f, -1.6f, -4.5f);
        yield return new WaitForSeconds(0.75f);
        // This makes sure the enemy will initiate their next attack.
        canAttack = true;
    }

    void SideSwipes()
    {
        // 1 Swipe to the left, 1 to the right, followed by another to the left.
        StartCoroutine(SideSwipesC());
    }

    IEnumerator SideSwipesC()
    {
        warning.transform.position = new Vector3(leftAttack, -1.6f, -4.5f);
        yield return new WaitForSeconds(attackDelay);

        warning.transform.position = new Vector3(rightAttack, -1.6f, -4.5f);
        yield return new WaitForSeconds(attackDelay);

        warning.transform.position = new Vector3(leftAttack, -1.6f, -4.5f);
        yield return new WaitForSeconds(attackDelay);

        warning.transform.position = new Vector3(-20f, -1.6f, -4.5f);
        yield return new WaitForSeconds(0.75f);
        canAttack = true;
    }

    void SideSwipesMirrored()
    {
        // 1 Swipe to the right, 1 to the left, followed by another to the right.
        StartCoroutine(SideSwipesMirroredC());
    }

    IEnumerator SideSwipesMirroredC()
    {
        warning.transform.position = new Vector3(rightAttack, -1.6f, -4.5f);
        yield return new WaitForSeconds(attackDelay);

        warning.transform.position = new Vector3(leftAttack, -1.6f, -4.5f);
        yield return new WaitForSeconds(attackDelay);

        warning.transform.position = new Vector3(rightAttack, -1.6f, -4.5f);
        yield return new WaitForSeconds(attackDelay);

        warning.transform.position = new Vector3(-20f, -1.6f, -4.5f);
        yield return new WaitForSeconds(0.75f);
        canAttack = true;
    }


}
