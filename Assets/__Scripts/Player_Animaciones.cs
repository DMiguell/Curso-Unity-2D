using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animaciones : MonoBehaviour
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerCaminar;

    private Animator _animator;
    private Player_Movimiento _player_movimiento;

    //private readonly int direccionX = Animator.StringToHash("X"); // Esto es crear texto dentro de una variable, donde podemos colocarla en lugares donde nos pide text
    private readonly int derrotado = Animator.StringToHash("Derrotado");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player_movimiento = GetComponent<Player_Movimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        ActualizaLayers();

        if(_player_movimiento.EnMovimiento == false)
        {
            return;
        }

        _animator.SetFloat("Move X", _player_movimiento.DireccionMovimiento.x);
        _animator.SetFloat("Move Y", _player_movimiento.DireccionMovimiento.y);
    }

    private void ActivarLayer(string nombreLayer)
    {
        for(int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0);
        }

        _animator.SetLayerWeight(_animator.GetLayerIndex(nombreLayer), 1);
    }

    private void ActualizaLayers()
    {
        if(_player_movimiento.EnMovimiento)
        {
            ActivarLayer(layerCaminar);
        }
        else
        {
            ActivarLayer(layerIdle);
        }
    }

    private void PersonajeDerrotadoRespuesta()
    {
        if(_animator.GetLayerWeight(_animator.GetLayerIndex(layerIdle)) == 1)
        {
            _animator.SetBool("Derrotado", true);
        }
    }

    private void OnEnable() 
    {
        PlayerVida.EventoPersonajeDerrotado += PersonajeDerrotadoRespuesta;
    }

    private void OnDisable()
    {
                PlayerVida.EventoPersonajeDerrotado -= PersonajeDerrotadoRespuesta;

    }
}
