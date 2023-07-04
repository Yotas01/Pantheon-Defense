using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyNamespace{
public class HealthBar : MonoBehaviour{

    [SerializeField] private Slider slider;
    public void UpdateHealthBar(int currentValue, int maxValue){
        slider.value = (float) currentValue/maxValue;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
}