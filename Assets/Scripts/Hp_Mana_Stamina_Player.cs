using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp_Mana_Stamina_Player : MonoBehaviour
{
    #region Public Values
    public int HP_Player;
    public int HP_Current_Player;
    
    public int Stamina_Player;
    public int Stamina_Current_Player;

    public int MP_Player;
    public int MP_Current_Player;

    public BarPlayer setBarHP;
    public BarPlayer setBarSTM;
    public BarPlayer setBarMP;

    public Text textHP_Max;
    public Text textHP_Current;

    public Text textSTM_Max;
    public Text textSTM_Current;

    public Text textMP_Max;
    public Text textMP_Current;

    public static Hp_Mana_Stamina_Player instance;
    #endregion

    #region Private Values
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;
    #endregion

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        HP_Current_Player = HP_Player;
        Stamina_Current_Player = Stamina_Player;
        MP_Current_Player = MP_Player;

        textHP_Max.text = "/" + HP_Player.ToString();
        textHP_Current.text = HP_Current_Player.ToString();
        
        textSTM_Max.text = "/" + Stamina_Player.ToString();
        textSTM_Current.text = Stamina_Current_Player.ToString();

        textMP_Max.text = "/" + MP_Player.ToString();
        textMP_Current.text = MP_Current_Player.ToString();

        setBarHP.SetMax(HP_Player);
        setBarSTM.SetMax(Stamina_Player);
        setBarMP.SetMax(MP_Player);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(20);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Stamina_Player += 100;
            setBarSTM.SetMax(Stamina_Player);

            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenSTM());

            setBarSTM.SetCurrent(Stamina_Current_Player);
            textSTM_Current.text = Stamina_Current_Player.ToString();

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            UseMana(20);
        }

        textHP_Max.text = "/" + HP_Player.ToString();
        textSTM_Max.text = "/" + Stamina_Player.ToString();
        textMP_Max.text = "/" + MP_Player.ToString();
    }

    public void TakeDamage(int damage)
    {
        if (HP_Current_Player - damage > 0)
        {
            HP_Current_Player -= damage;
        }
        else
        {
            HP_Current_Player = 0;
        }
        setBarHP.SetCurrent(HP_Current_Player);
        textHP_Current.text = HP_Current_Player.ToString();
    }

    public void UseStamina(int StaminaToUse)
    {
        if (Stamina_Current_Player - StaminaToUse > 0)
        {
            Stamina_Current_Player -= StaminaToUse;
            
            if (regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenSTM());
        }
        else
        {
            Stamina_Current_Player = 0;
        }
        setBarSTM.SetCurrent(Stamina_Current_Player);
        textSTM_Current.text = Stamina_Current_Player.ToString();
    }

    public void UseMana(int ManaToUse)
    {
        if (MP_Current_Player - ManaToUse > 0)
        {
            MP_Current_Player -= ManaToUse;
        }
        else
        {
            MP_Current_Player = 0;
        }
        setBarMP.SetCurrent(MP_Current_Player);
        textMP_Current.text = MP_Current_Player.ToString();
    }

    private IEnumerator RegenSTM()
    {
        yield return new WaitForSeconds(2);

        while (Stamina_Current_Player < Stamina_Player)
        {
            Stamina_Current_Player += Stamina_Player / 50;
            if (Stamina_Current_Player > Stamina_Player)
            {
                Stamina_Current_Player = Stamina_Player;
            }
            setBarSTM.SetCurrent(Stamina_Current_Player);
            textSTM_Current.text = Stamina_Current_Player.ToString();
            yield return regenTick;
        }
        regen = null;
    }
}
