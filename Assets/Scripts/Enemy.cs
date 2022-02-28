using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Public Values
    public bool RangedAttack;
    public Animator animator;
    public AnimationClip dead;
    public SpriteRenderer SrEnemy;
    public int maxHealth;
    public bool IsDelayAfterDie;
    public float DelayAfterDieOfTime;
    #endregion

    #region Private Values
    private int currentHealth;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        if (!IsDelayAfterDie)
        {
            DelayAfterDieOfTime = 0f;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (RangedAttack)
        {
            this.gameObject.GetComponent<Enemy_Ranged_Attack>().CancelInvoke();
            Invoke("CancelInvokeEnemyRangedAttack", this.gameObject.GetComponent<Enemy_Ranged_Attack>().HurtAnimation.length);
        }
        animator.SetBool("Attack", false);
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
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
        Destroy(this.gameObject, DelayAfterDieOfTime);
    }

    void CancelInvokeEnemyRangedAttack()
    {
        this.gameObject.GetComponent<Enemy_Ranged_Attack>().CancelInvoke();
    }
}
