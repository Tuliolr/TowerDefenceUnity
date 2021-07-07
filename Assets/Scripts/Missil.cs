using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missil : MonoBehaviour {
    private float velocidade = 10;
    private Inimigo alvo;
    [SerializeField]private int pontoDeDanos;
    

	// Use this for initialization
	void Start () {
       
        AutoDestroiDepoisDeSegundo(2);
    }
	
	// Update is called once per frame
	void Update () {
        Anda();
        if(alvo != null)
        {
            AlteraDirecao();
        }
        
		
	}

    private void Anda ()
    {
        Vector3 posicaoAtual = transform.position;
        Vector3 deslocamento = transform.forward * Time.deltaTime * velocidade;
        transform.position = posicaoAtual + deslocamento;
    }

    private void AlteraDirecao()
    {
        Vector3 posicaoAtual = transform.position;
        Vector3 posicaoDoAlvo = alvo.transform.position;
        Vector3 direcaoDoAlvo = posicaoDoAlvo - posicaoAtual;
        transform.rotation = Quaternion.LookRotation(direcaoDoAlvo);
    }

    private void AutoDestroiDepoisDeSegundo(float segundos)
    {
        Destroy(this.gameObject, segundos);
    }

    public void DefineAlvo(Inimigo inimigo)
    {
        alvo = inimigo;
    }

    private void OnTriggerEnter(Collider elementoColidido)
    {
        if(elementoColidido.CompareTag("Inimigo"))
            {
            Destroy(this.gameObject);
            // Destroy(elementoColidido.gameObject);

            Inimigo inimigo = elementoColidido.GetComponent<Inimigo>();
            inimigo.RecebeDano(pontoDeDanos);

            }
       
    }
}
