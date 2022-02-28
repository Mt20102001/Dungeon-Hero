using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    #region Public Value
    public int attackDamage;
    public bool IsMonster;
    #endregion

    #region Private Value
    private GameObject RoleOfGameObject;
    private string role;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMonster)
        {
            role = "Player";
        }
        else
        {
            role = "Enemy";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == role)
        {
            RoleOfGameObject = other.gameObject;
            if (IsMonster)
            {
                RoleOfGameObject.GetComponent<Hp_Mana_Stamina_Player>().TakeDamage(attackDamage);
            }
            else
            {
                RoleOfGameObject.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }
    }
}
