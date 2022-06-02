using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth; 

    public HealthBar healthBar;
    protected Animator myAnim;

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(2);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        myAnim.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            myAnim.SetTrigger("Death");
            GetComponent<CharacterController>().enabled = false;
        }
    }
}
