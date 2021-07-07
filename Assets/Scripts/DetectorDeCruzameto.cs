using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorDeCruzameto : MonoBehaviour {

   [SerializeField] private Jogador jogador;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Inimigo"))
        {
            Debug.Log("");
            Destroy(collider.gameObject);
            jogador.PerdeVida();
        }
        
    }
}
