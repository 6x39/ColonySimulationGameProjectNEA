using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileAttributes : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float toughness; // this is going to relate to the values of each character's strength. Since I can only control character 1, I will only be using one character's attributes. 
    int time = 0;

    void InitialiseHealth(float amount)
    {
        maxHealth = amount;
        currentHealth = maxHealth;
    }

    public void AlterHealth(float amount)
    {
        currentHealth -= amount;
        time = 0;
    }

    void GenerateHealth()
    {
        if (currentHealth != maxHealth)
        {
            currentHealth += 1;
        }
    }

    void Start()
    {
        System.Random rand = new System.Random();
        float randVal = rand.Next(2, 8);
        InitialiseHealth(randVal);
    }

    void UpdateHealthBar()
    {
        // First I need to get the position of the tile game object. then I need to make an offset and place it a value beneath it.
        // then I need to 
    }

    void FixedUpdate()
    {
        time++;
        if (time > 100)
        {
            GenerateHealth();
        }

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
