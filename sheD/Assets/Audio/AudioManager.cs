using UnityEngine;
using FMODUnity; // Asegúrate de tener la integración de FMOD en tu proyecto
using FMOD.Studio;
using static UnityEngine.Rendering.DebugUI;

public class AudioManager : MonoBehaviour
{
    // --- Singleton Pattern ---
    // La instancia estática pública que será accesible desde cualquier otro script.
    public static AudioManager Instance { get; private set; }

    [SerializeField] private EventReference mainMusicRef;
    private EventInstance _musicEventInstance;

    private Player _player;





    // Nombre exacto del parámetro global en FMOD Studio
    public string globalParameterName = "GameState";

    // Valor que quieres asignar
    public float newValue = 0f;

    void Start()
    {
        SetGlobalParameter(newValue);
    }

    public void SetGlobalParameter(float value)
    {
        FMOD.Studio.System system = RuntimeManager.StudioSystem;
        // Cambia el valor del parámetro global
        system.setParameterByName(globalParameterName, value);
    }




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


        _player = FindObjectOfType<Player>();

    }

    private void Update()
    {
        CheckSnakeState();
    }


    void CheckSnakeState()
    {
        int state = 0;
        if (_player.IsCamuflaged)
        {
            state = 1;
        }
        else
        {
            state = 0;
        }

        FMOD.Studio.System system = RuntimeManager.StudioSystem;
        // Cambia el valor del parámetro global
        system.setParameterByName("GlobalSnakeState", state);

        //_musicEventInstance.setParameterByName("SnakeState", state);
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