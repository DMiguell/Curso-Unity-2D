using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerVida PlayerVida {get; private set;}
    public Player_Animaciones Player_Animaciones{get; private set;}

    private void Awake() 
    {
        PlayerVida = GetComponent<PlayerVida>();
        Player_Animaciones = GetComponent<Player_Animaciones>();
    }

    public void RestaurarPersonaje()
    {
        PlayerVida.RestaurarPersonaje();
        Player_Animaciones.RevivirPersonaje();
    }
}
