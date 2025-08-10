using UnityEngine;
using FMODUnity; // Asegúrate de tener la integración de FMOD en tu proyecto

public class AudioManager : MonoBehaviour
{
    // --- Singleton Pattern ---
    // La instancia estática pública que será accesible desde cualquier otro script.
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("AudioManager: Creada nueva instancia del Singleton.");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("AudioManager: Se encontró otra instancia, esta ha sido destruida.");
        }
    }

    // --- Lógica de FMOD ---
    // Un método de ejemplo para reproducir un sonido 2D (One-Shot).
    public void PlayOneShot(EventReference soundEvent)
    {
        // Verifica que la referencia del evento no esté vacía antes de intentar reproducirlo.
        if (!soundEvent.IsNull)
        {
            RuntimeManager.PlayOneShot(soundEvent);
        }
    }
}