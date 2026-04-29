using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavegacionEntreEscenas : MonoBehaviour
{
    public void cargarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void cargarNivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void cargarNivel2()
    {
        SceneManager.LoadScene("Nivel2");
    }



}
