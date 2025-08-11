using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class FMODResumen
{
    /*
     * Te mando un pequeño resumen de lo que fui recolectando como lo mÁs util durante estos meses.
     *
     * Para saber como configurar los sliders de los volumenes lo mejor es ver la clase -VolumeSetter-
     * Creo que es bastante claro y simple
     */
}

/****************************************************************************************************************
 * Para usar eventos OneShot lo que mas me ha servido es seleccionar el evento necesario desde la lista
 * del editor mediante un EventReference.
 * Luego reproducirlo mediante un PlayOneShot en la posición dada (generalmente el objeto que hace ese sonido)
 *///************************************************************************************************************
public class UsarEventosOneShot : MonoBehaviour
{
    [SerializeField] private EventReference eventoSfx;
    [SerializeField] private GameObject objeto;

    private void SfxPlay()
    {
        var posicionDeReproduccion = objeto.transform.position;

        //En un punto definido del espacio
        RuntimeManager.PlayOneShot(eventoSfx, posicionDeReproduccion);

        //En un objeto que tal vez se mueva. Es como si le ensartas el sonido a un gameobject y si el 
        //objeto se mueve el sonido se mueve con el.
        RuntimeManager.PlayOneShotAttached(eventoSfx, objeto);
    }
}




/****************************************************************************************************************
 * Para los loops que tengo que controlar cuando empiezan o cuando terminan suelo crear instancias de los eventos.
 *///************************************************************************************************************

public class CrearInstanciasDeEventos : MonoBehaviour
{
    [SerializeField] private EventReference eventoEnLoop;

    private void PlayInstance()
    {

        //creo la instancia
        EventInstance instanceSfx = RuntimeManager.CreateInstance(eventoEnLoop);


        //Si necesito que se reproduzca en una posicion fija en el espacio
        var posicionDeReproduccion = Vector3.zero;
        instanceSfx.set3DAttributes(RuntimeUtils.To3DAttributes(posicionDeReproduccion));

        //Si necesito que se reproduzca "persiguiendo" aun objeto, le pasas su transform
        RuntimeManager.AttachInstanceToGameObject(instanceSfx, this.transform);


        //seteo de un parámetro en caso de ser necesario:
        //NOTA:El nombre del parámetro y que hace cada valor o que controla hay que acordarlo con Marco
        float valorDelParametro = 1f;
        instanceSfx.setParameterByName("NombreDelParametro", valorDelParametro);


        //Para reproducir el sonido
        instanceSfx.start();


        //Para detenerlo existen dos formas, uno que lo para al toque: STOP_MODE.INMEDIATE o STOP_MODE.ALLOWFADEOUT 
        //que permite si el enveto tiene algun modulador que desaparezca suavemente.
        instanceSfx.stop(STOP_MODE.ALLOWFADEOUT);


        //Liberar recursos. Normalmente para no seguir ocupando un canal de audio lo mejor es que si un sonido no
        //se va a volver a utilizar en el futuro,  detenerlo lo mejor es liberar la instancia.
        instanceSfx.release();


    }
}

/*
 * El StudioEventEmitter es un componente que funciona similar a un AudioSource.
 * Vos ahi podes determinar cuando se comienza o termina de reproducir el sonido.
 * Sin embargo tambien se puede usar por codigo.
 *
 * El unico problema es que a pesar que hay info de como alterar los parámetros con un
 * Emitter, no he logrado que funcionara.
 *
 * Tambien es util para modificar el alcance de los audios 3D (distancia mínima y máxima)
 * como el del audio source
 */

public class ReproducirDesdeElStudioEventEmitter : MonoBehaviour
{
    [SerializeField] private StudioEventEmitter eventEmitter;

    private void PararUnEventEmiter()
    {
        //detener un emmiter
        eventEmitter.Stop();

        //reproducir un emmiter
        eventEmitter.Play();


    }

}
