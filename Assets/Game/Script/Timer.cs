using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private int min = 7;
    private int seg = 30;



    [SerializeField] TextMeshProUGUI tiempo;
    //private int life = 100;

    public float restante;
    private bool EnMarcha;

    private void Awake()
    {
        restante = (min * 60) + seg;
        EnMarcha = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnMarcha)
        {
            restante -= Time.deltaTime;
            if (restante < 1)
            {
                EnMarcha = true;
                SceneManager.LoadScene("Derrota");


                Cursor.lockState = CursorLockMode.None;
            }


            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{00:00} : {01:00}", tempMin, tempSeg);
        }
    }
}