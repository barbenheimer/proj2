using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Player player;
    public Image fillImage;
    private Slider healthbar;

    void Awake()
    {
        healthbar = GetComponent<Slider>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float fillValue = (float)player.currentHp / (float)player.maxHp;
        //if (player.currentHp != 10)
        //{
        //    Debug.Log("hit");
        //}
        healthbar.value = fillValue;
        if(fillValue <= healthbar.maxValue / 5)
        {
            fillImage.color = Color.red;
        }
    }
}
