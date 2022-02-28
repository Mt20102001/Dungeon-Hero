using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    #region Public Values
    public float moveSpeed;
    public int damageBullet;
    #endregion

    #region Private Values
    private GameObject target;
    private Rigidbody2D rb;
    private Vector2 moveDiretion;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        moveDiretion = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDiretion.x, moveDiretion.y);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            target.gameObject.GetComponent<Hp_Mana_Stamina_Player>().TakeDamage(damageBullet);
            Destroy(gameObject);
        }

        if (target.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
