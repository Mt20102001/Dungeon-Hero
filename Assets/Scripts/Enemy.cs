using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Public Values
    public Animator animator;
    public AnimationClip dead;
    public SpriteRenderer SrEnemy;
    public int maxHealth = 100;
    #endregion

    #region Private Values
    private int currentHealth;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Die");
        animator.SetBool("isDead", true);
        foreach (Collider2D c in GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
        SrEnemy.sortingOrder = 0;
        GetComponent<Enemy_behaviour>().enabled = false;
        Invoke("AfterDie", dead.length);
    }

    void AfterDie()
    {
        animator.speed = 0;
        Destroy(this.gameObject, 2f);
    }

}
