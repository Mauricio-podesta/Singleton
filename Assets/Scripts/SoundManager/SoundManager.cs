using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

// El singleton en este caso es el soundManagaer
public class SoundManager : MonoBehaviour
{ 
   //Aca creo la variable que guardara la clase singleton
    public static SoundManager Instance;

    public AudioSource audioSourcePrefab;
  
    // Aca se crea el método donde guardo la info en la variable   
    public void GetInstance()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    //Aca el método se aplica.
    private void Awake()
    {
        GetInstance();
    }
public void PlaySound(AudioClip clip, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(clip, position);
        Debug.Log($"Sound: {clip} played at position {position}");
    }


}
