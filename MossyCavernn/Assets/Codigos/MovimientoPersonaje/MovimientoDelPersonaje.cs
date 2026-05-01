using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDelPersonaje : MonoBehaviour
{
    public AccionesDeEntrada controles;

    public Vector2 direccion;
    public Rigidbody2D rb2d;
    public float velocidadMovimiento = 6;
    public bool mirandoderecha = true;
    public float fuerzaSalto = 6;
    public LayerMask queEsSuelo;
    public Transform controladorSuelo;
    public Vector3 dimensionesCaja;
    public bool enSuelo;

    private void Awake()
    {
        controles = new();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        controles.Enable();
        controles.Jugador.Saltar.started += _ => Saltar();
    }

    private void OnDisable()
    {
        controles.Disable();
        controles.Jugador.Saltar.started -= _ => Saltar();
    }

    private void Update()
    {
        direccion = controles.Jugador.Movimiento.ReadValue<Vector2>();
        AjustarRotacion(direccion.x);
        enSuelo = Physics2D.OverlapBox(controladorSuelo.position, dimensionesCaja, 0f, queEsSuelo);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(direccion.x * velocidadMovimiento, rb2d.velocity.y);
    }

    private void Girar()
    {
        mirandoderecha = !mirandoderecha;

        Vector3 scala = transform.localScale;

        scala.x = scala.x *= -1;

        transform.localScale = scala;
    }

    private void AjustarRotacion(float direccionx)
    {
        if(direccionx > 0 && !mirandoderecha)
        {
            Girar();
        }
        else if (direccionx < 0 && mirandoderecha)
        {
            Girar();
        }
    }

    private void Saltar()
    {
        if (enSuelo)
        {
            rb2d.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(controladorSuelo.position, dimensionesCaja);
    }
}
