using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp_Mana_Stamina_Player : MonoBehaviour
{
    #region Public Values
    public int HP_Player;
    public int HP_Current_Player;
    
    public int Stamina_Player;
    public int Stamina_Current_Player;

    public int MP_Player;
    public int MP_Current_Player;

    public BarPlayer setBar;

    #endregion

    #region Private Values

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        HP_Current_Player = HP_Player;
        Stamina_Current_Player = Stamina_Player;
        MP_Current_Player = MP_Player;

        setBar.SetMax(HP_Player, Stamina_Player, MP_Player);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            UseMana(20);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseStamina(20);
        }
    }

    void TakeDamage(int damage)
    {
        HP_Current_Player -= damage;
        setBar.SetCurrent(HP_Current_Player, Stamina_Current_Player, MP_Current_Player);
    }

    void UseMana(int ManaToUse)
    {
        MP_Current_Player -= ManaToUse;
        setBar.SetCurrent(HP_Current_Player, Stamina_Current_Player, MP_Current_Player);

    }

    void UseStamina(int StaminaToUse)
    {
        Stamina_Current_Player -= StaminaToUse;
        setBar.SetCurrent(HP_Current_Player, Stamina_Current_Player, MP_Current_Player);

    }
}
