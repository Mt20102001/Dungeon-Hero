using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarPlayer : MonoBehaviour
{
    #region Public Values
    public Slider sliderHP;
    public Slider sliderSTM;
    public Slider sliderMP;

    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMax(int HP, int STM, int MP)
    {
        sliderHP.maxValue = HP;
        sliderHP.value = HP;

        sliderSTM.maxValue = STM;
        sliderSTM.value = STM;

        sliderMP.maxValue = MP;
        sliderMP.value = MP;
    }

    public void SetCurrent(int HP, int STM, int MP)
    {
        sliderHP.value = HP;
        sliderSTM.value = STM;
        sliderMP.value = MP;
    }
}
