using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public Slider healthSlider;

    public Timer temporizador;
    private float hp;


    private void Start()
    {
        hp = 100;
        UpdateHealthUI();
    }

    private void Update()
    {
        if (hp > 100)
        {
            hp = 100; //pone limite a la cantidad de vida
        }

        if (hp <= 0 )
        {
            SceneManager.LoadScene("GameOver");

            Cursor.lockState = CursorLockMode.None;
        }
        UpdateHealthUI();

        if(hp > 0 && temporizador.restante < 1) 
        {
            Debug.Log("victoria");
        }

    }

    public void RecibirDanio(float dmg)
    {
        hp -= dmg;
        UpdateHealthUI();
    }

    //public void Curar(float heal)
    //{
    //    hp += heal;
    //    UpdateHealthUI();
    //}

    void UpdateHealthUI()
    {
        hp = Mathf.Clamp(hp, 0, 100);
        healthSlider.value = hp;

    }
}
