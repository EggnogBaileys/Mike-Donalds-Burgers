using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour
{
    // Physical game object references for each.
    public GameObject spatula;
    public GameObject potlid;

    public Animator animator;

    // This collider appears as a hitbox. If the hitbox interacts with an exposed enemy sprite, it will damage the enemy.
    public GameObject attackHitbox;

    // Potlid's rigidbody;
    Rigidbody pRigid;

    // Respective speeds for both items.
    public float spatulaSpeed = 40f;
    public float potSpeed = 112f;

    // In case we want to make enemies capable of freezing the spatula.
    bool canMoveSpatula = true;

    // Determines whether the spatula is swinging.
    // (The swing collision's position should not update with the mouse movement, but be set to the current position when first clicking).
    public bool swinging;
    
    // currentTime will update to the value of Time.time when the spatula is being swung.
    float currentTime = 10000f;
    // countdown acts as a sort of swing delay for the spatula so it cannot be swung again. 
    // the animation will play and you cannot swing again until the animation finishes.
    float countdown = 0.5f;

    // determines when the countdown will end (currentTime plus countdown).
    float endTimer;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the attack hitbox isn't active right away.
        attackHitbox.SetActive(false);
        pRigid = potlid.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // Potlid and Spatula movement
        PotlidMove();
        SpatulaMove();
        SyncAnimator();

        // Checks the swing delay to see when it should end the timer.
        if (swinging)
        {
            // Maybe we can replace this with WaitForSeconds(), which I only learned existed recently after making this.
            currentTime = Time.time;
            SwingTimer();
        }

    }

    void PotlidMove()
    {
        if (potlid.transform.position.x >= -9.0 && Input.GetKey(KeyCode.A))
        {
            pRigid.AddForce(-potSpeed * Time.deltaTime * 20f, 0, 0);
        }
        else if (potlid.transform.position.x <= 9.0 && Input.GetKey(KeyCode.D))
        {
            pRigid.AddForce(potSpeed * Time.deltaTime * 20f, 0, 0);
        }

        // This adds a sort of 'bounce' to push the shield back into view if you pull it too far offscreen.
        // If you don't want the bounce at all, comment these two lower if checks out and everything else should work fine.
        else if (potlid.transform.position.x <= -10.0)
        {
            pRigid.AddForce((potSpeed/2) * Time.deltaTime * 20f, 0, 0);
        }
        else if (potlid.transform.position.x >= 10.0)
        {
            pRigid.AddForce((-potSpeed/2) * Time.deltaTime * 20f, 0, 0);
        }
    }

    void SpatulaMove()
    {
        // Sets the spatula's x position to that of the mouse.
        if (canMoveSpatula)
        {
            MouseCheck(spatula);
        }

        // If you aren't swinging, clicking the left mouse button will allow you to swing again.
        if (!swinging && Input.GetMouseButtonDown(0))
        {
            SwingSpatula();
        }
    }

    void SwingSpatula()
    {
        // This should make the animator play it's.
        swinging = true;

        // Sets the timer to finish the attack.
        currentTime = Time.time;
        endTimer = Time.time + countdown;

        // Sets the attack hitbox active when swinging.
        attackHitbox.SetActive(true);
        // Sets its transform to wherever the spatula was when it swung, and keeps it there until the attack timer finishes or it hits something.
        MouseCheck(attackHitbox);
    }

    // Swing delay (match animation time to be as quick or slightly shorter than the delay countdown)
    void SwingTimer()
    {
        if (currentTime >= endTimer)
        {
            // Ensures you can swing again and the previous attack hitbox is deactivated.
            attackHitbox.SetActive(false);
            swinging = false;
        }
    }

    // Function that moves the referenced game object to the current x position of the mouse.
    public void MouseCheck(GameObject obj)
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, -6.69f, 10f));
        obj.transform.position = wantedPos;
    }

    void SyncAnimator()
    {
        animator.SetBool("isSwinging", swinging);
    }


}
