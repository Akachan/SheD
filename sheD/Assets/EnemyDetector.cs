using System;
using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    [SerializeField ] [Range(0f, 5f )]private float minDistanceToDetect = 20f;
    private List<Transform> _enemies;
    private bool _isInTheArea;
    private float _colliderRadius;
    private float _distanceToCompute;
 
    


    private void Awake()
    {
        _colliderRadius = GetComponent<CircleCollider2D>().radius*GetComponentInParent<Player>().transform.localScale.x;
        _enemies = new List<Transform>();
    }
    



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemigo detectado");
            _enemies.Add(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemigo fuera de alcance");
            _enemies.Remove(other.transform);

            if (_enemies.Count == 0)
            {
                AudioManager.Instance.SetProximityBgm(1);
            }
        }
        
        //si está vació pasar el parametro 0
        
        
    }

    private void FixedUpdate()
    {
        // fijarse si hay enemigos
        if(_enemies.Count == 0) return;
        
        //Ver cual está mas cerca
        var enemyDistance = GetCloserEnemyDistance();

        //Calcular el ratio
        var ratio = CalculateRatio(enemyDistance);

        //pasar parámetro
        AudioManager.Instance.SetProximityBgm(ratio);
        
    }



    private float GetCloserEnemyDistance()
    {
        var minDistance = Mathf.Infinity;
    
      

        foreach (var enemy in  _enemies)
        {
            //calcular distancia
            var sqrDistance = Vector2.SqrMagnitude(enemy.position - transform.position);
            
            //fijarse si es mas chica que el minimo
            if (sqrDistance < minDistance)
            {
                minDistance = sqrDistance;
                
            }
        }

        return Mathf.Sqrt(minDistance);

    }
    private float CalculateRatio(float enemyDistance)
    {
       
        var ratio = Mathf.Clamp((enemyDistance - minDistanceToDetect) / (_colliderRadius - minDistanceToDetect), 0f, 1f);

        return ratio;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minDistanceToDetect);
    }
}
