using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarPlayer : MonoBehaviour
{
    #region Public Values
    public Slider slider;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMax(int value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    public void SetCurrent(int value)
    {
        slider.value = value;
    }
}
