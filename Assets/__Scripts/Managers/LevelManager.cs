using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player personaje;
    [SerializeField] private Transform puntoReaparicion;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(personaje.PlayerVida.Derrotado)
            {
                personaje.transform.localPosition = puntoReaparicion.position;
                personaje.RestaurarPersonaje();
            }
        }
        
    }
}
