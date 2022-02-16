using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerVida : VidaBase
{
    public static Action EventoPersonajeDerrotado;

    public bool Derrotado {get; private set;}
    public bool PuedeSerCurado => Salud < saludMax;

    private BoxCollider2D _boxCollider2D;

    private void Awake() 
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    protected override void Start()
    {
        base.Start();
        ActualizarBarraVida(Salud, saludMax);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            RecibirDaño(10);
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            RestaurarSalud(10);
        }
    }

    public void RestaurarSalud(float cantidad)
    {
        if(Derrotado)
        {
            return;
        }
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
        _boxCollider2D.enabled = false;
        Derrotado = true;
        //EventoPersonajeDerrotado?.Invoke();

        if(EventoPersonajeDerrotado != null) //Esto es lo mismo que el de arriba
        {
            EventoPersonajeDerrotado.Invoke();
        }
    }

    public void RestaurarPersonaje()
    {
        _boxCollider2D.enabled = true;
        Derrotado = false;
        Salud = saludInicial;
        ActualizarBarraVida(Salud, saludInicial);
    }

    protected override void ActualizarBarraVida(float vidaActual, float vidaMax)
    {
        UIManager.Instance.ActualizarVidaPersonaje(vidaActual, vidaMax);
    }
}
