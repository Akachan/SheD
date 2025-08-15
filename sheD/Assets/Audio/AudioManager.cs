// Aseg�rate de tener la integraci�n de FMOD en tu proyecto
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        // --- Singleton Pattern ---
        // La instancia est�tica p�blica que ser� accesible desde cualquier otro script.
        public static AudioManager Instance { get; private set; }

        [SerializeField] private EventReference mainMusicRef;
        private EventInstance _musicEventInstance;

        private Player _player;





        // Nombre exacto del par�metro global en FMOD Studio
        public string globalParameterName = "GameState";

        // Valor que quieres asignar
        public float newValue = 0f;

    
        private void Awake()
        {
            Singleton();
            FindPlayerReference();

           
        }

        private void Update()
        {
            CheckSnakeState();
            
        }
        private void Singleton()
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
                Debug.Log("AudioManager: Se encontr� otra instancia, esta ha sido destruida.");
            }
        }

        public void SetGlobalParameter(float value)
        {
            FMOD.Studio.System system = RuntimeManager.StudioSystem;
            // Cambia el valor del par�metro global
            system.setParameterByName(globalParameterName, value);
        }


        void CheckSnakeState()
        {
            
            if (_player == null) return;
            
            int state = 0;
            state = _player.IsCamuflaged ? 1 : 0;

            // Cambia el valor del par�metro global
            
            
            FMOD.Studio.System system = RuntimeManager.StudioSystem;
            // Cambia el valor del par�metro global
            system.setParameterByName("GlobalSnakeState", state);
            
            
        }

  
        //ESTO ES LLAMADO CUANDO SE CAMBIA UNA ESCENA
        
        //Setea la musica para el main Menú
        public void SetMainMenuMusic()
        {
            Debug.Log("SetGamePlayMusic");
            SetGlobalParameter(0);
        }

        //Setea la musica para el juego y como es llamado en la carga de una nueva escena
        //tambien busca la referencia al player
        public void SetGamePlayMusic()
        {
            Debug.Log("SetGamePlayMusic");
            SetGlobalParameter(1);
            FindPlayerReference();
        }

        private void FindPlayerReference()
        {
            _player = FindFirstObjectByType<Player>();
            if (_player == null)
            {
                Debug.LogWarning("El jugador no ha sido encontrado en la escena");
            }

        }
        
        public void SetPauseBgm()
        {
           Debug.Log("SetPauseBgm");
           
           //todo: poner la musica de pausa
        }

        public void RemovePauseBgm()
        {
            Debug.Log("RemovePauseBgm");
            
            //todo: volver a poner la música de gameplay
        }

        public void SetProximityBgm(float newRatio)
        {
            var ratio = newRatio;
            
            //esta linea hace que el 1 sea cuando el enemigo está super cerca y 0 cuando está fuera de rango
            //Si querés invertirlo simplemente comentá esta linea :D
            ratio = 1 - ratio;
            
            Debug.Log($"SetProximityRatio {ratio}");
            
            //todo: poner el BGM de proximidad
            
        }

    


        // --- L�gica de FMOD ---
        // Un m�todo de ejemplo para reproducir un sonido 2D (One-Shot).
        public void PlayOneShot(EventReference soundEvent)
        {
            // Verifica que la referencia del evento no est� vac�a antes de intentar reproducirlo.
            if (!soundEvent.IsNull)
            {
                RuntimeManager.PlayOneShot(soundEvent);
            }
        }



    }
}