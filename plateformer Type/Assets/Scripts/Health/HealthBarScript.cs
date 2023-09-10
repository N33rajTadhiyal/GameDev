using System.Collections;
using System.Collections.Generic;
using  UnityEngine.UI;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] private HealthSystem Playerhealth;
    [SerializeField] private Image TotalHealthBar;
    [SerializeField] private Image CurrentHealhBar;
   

   void Start()
   {

   }
    void Update()
    {
        
        CurrentHealhBar.fillAmount=Playerhealth.CurrentHealth/5;
    }
    public void SetMaxHealthBar(float Health)
    {
      TotalHealthBar.fillAmount=Health/5;
    }
}  
