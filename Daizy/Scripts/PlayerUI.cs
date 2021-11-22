using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
public Text temperature;
public Text time;
public Text date;
public HUDBar healthBar;
[SerializeField] public int healthMax = 100;
[SerializeField] public int healthCurrent = 0;
public HUDBar staminaBar;
[SerializeField] public int staminaMax = 100;
[SerializeField] public int staminaCurrent = 0;
public HUDBar foodBar;
[SerializeField] public int foodMax = 100;
[SerializeField] public int foodCurrent = 0;
public HUDBar thirstBar;
[SerializeField] public int thirstMax = 100;
[SerializeField] public int thirstCurrent =0;

    private void Start() 
    {
    healthCurrent = healthMax;

    healthBar.SetMaxValue(healthMax);
  
    staminaCurrent = staminaMax;

    staminaBar.SetMaxValue(staminaMax);
  
    foodCurrent = foodMax;

    foodBar.SetMaxValue(foodMax);
   
    thirstCurrent = thirstMax;

    thirstBar.SetMaxValue(thirstMax);
   
    }

    private void Update() 
    {
        
    }

private void takeDamage(int damage)
    {

    healthCurrent -= damage;

    healthBar.SetMaxValue(healthCurrent);

    }
    private void takeSamDamage(int fatigue)
    {

    staminaCurrent -= fatigue;

    staminaBar.SetMaxValue(staminaCurrent);

    }

}
