using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public int maxShield = 10;
    public int currentShield;

    public HealthBar healthBar;
    public ShieldBar shieldBar;
    protected Animator myAnim;
    private BoxCollider2D myBoxCollider;
    private Rigidbody2D myRigidbody;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
        currentHealth = maxHealth;
        currentShield = maxShield;
        healthBar.SetMaxHealth(maxHealth);
        shieldBar.SetMaxShield(maxShield);
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(2);
        }

        if (Input.GetKeyDown(KeyCode.R) && currentHealth <= 0)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        healthBar.SetHealth(maxHealth);
        shieldBar.SetShield(maxShield); currentHealth = maxHealth;
        currentShield = maxShield;
        healthBar.SetMaxHealth(maxHealth);
        shieldBar.SetMaxShield(maxShield);
        myAnim.SetTrigger("Idle");
        GetComponent<CharacterController>().enabled = true;
        GetComponent<CharacterWeapon>().enabled = true;
    }

    public void TakeDamage(int damage)
    {
        if(currentShield > 0)
        {
            currentShield -= damage;
            shieldBar.SetShield(currentShield);
            myAnim.SetTrigger("Hurt");
        }
        else
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            myAnim.SetTrigger("Hurt");

            if (currentHealth <= 0)
            {
                myAnim.SetTrigger("Death");
                //GetComponent<BoxCollider2D>().enabled = false;
                Vector2 deathSize = new Vector2(0.5f, 0.3f);
                myBoxCollider.size = deathSize;
                GetComponent<CharacterController>().enabled = false;
                GetComponent<CharacterWeapon>().enabled = false;
            }
        }
    }
}
