using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerVida : VidaBase
{
    public static Action EventoPersonajeDerrotado;
    public bool PuedeSerCurado => Salud < saludMax;


    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            RecibirDaño(10);
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestaurarSalud(10);
        }
    }

    public void RestaurarSalud(float cantidad)
    {
        if(PuedeSerCurado)
        {
            Salud += cantidad;
            if(Salud > saludMax)
            {
                Salud = saludMax;
            }

            ActualizarBarraVida(Salud, saludMax);
        }
    }

    protected override void PersonajeDerrotado()
    {
        //EventoPersonajeDerrotado?.Invoke();

        if(EventoPersonajeDerrotado != null) //Esto es lo mismo que el de arriba
        {
            EventoPersonajeDerrotado.Invoke();
        }
    }

    protected override void ActualizarBarraVida(float vidaActual, float vidaMax)
    {
        
    }
}
