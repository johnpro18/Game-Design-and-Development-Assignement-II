using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    private Color myColor;
    private CharacterHealth myCharacterHealth;

    public int enemyHealth = 5;
    public int enemyDamage = 1;
    public float flashTime = 0.2f;

    // Start is called before the first frame update
    public void Start()
    {
        myCharacterHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myColor = mySpriteRenderer.color;
    }   

    // Update is called once per frame
    public void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
       
        enemyHealth -= damage;
        FlashColor(flashTime);
    }

    private void FlashColor(float time)
    {
        mySpriteRenderer.color = Color.red;
        Invoke("ResetColor", time);
    }

    private void ResetColor()
    {
        mySpriteRenderer.color = myColor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if(myCharacterHealth != null)
            {
                myCharacterHealth.TakeDamage(enemyDamage);
            }
            
        }
    }
}
