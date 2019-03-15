using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance; //Para evitar tener dos AudioManager después de no destruirlo al cambiar de pantalla//

    void Awake()
    {
        if (instance == null) //Para comprobar al cambiar de pantalla si tenemos o no un AudioManager, en caso de no tenerlo crearlo y en caso de tenerlo destruirlo//
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); //Para evitar eliminar nuestro AudioManager cuando cambiemos de pantalla//

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("MúsicaAmbiente");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) //Esto sirve para cuando escribimos algo mal que no se intente buscar un audio que no existe//
        {
            Debug.LogWarning("Sonido: " + name + " no encontrado!");
            return;
        }

        s.source.Play();
    }
}
