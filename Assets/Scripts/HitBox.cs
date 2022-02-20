using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    #region Public Value
    public int attackDamage;
    #endregion

    #region Private Value
    private GameObject Enemy;
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy = other.gameObject;
            Enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
}
