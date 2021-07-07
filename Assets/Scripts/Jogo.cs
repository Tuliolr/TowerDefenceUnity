using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour {

    [SerializeField] private GameObject torrePrefab;
    [SerializeField] private GameObject gameOver;
    [SerializeField]private Jogador jogador;

    private void Start()
    {
        gameOver.SetActive(false);
    }

    private void Update()
    {
        if(JogoAcabou())
        {
            gameOver.SetActive(true);
        }
        else {

            if(ClicouComBotaoPrimario())
        {
            ConstroiTorre();
        }
        }
    }

    private bool JogoAcabou()
    {
        return !jogador.EstaVivo();
    }

    public void RecomecaJogo()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    private bool ClicouComBotaoPrimario()
    {
        return Input.GetMouseButtonDown(0);
    }

    private void ConstroiTorre()
    {
        Vector3 posicaoDoClique = Input.mousePosition;
        RaycastHit elementoAtingidoPeloRaio = DisparaRaioCameraAteUmPonto(posicaoDoClique);

        if(elementoAtingidoPeloRaio.collider != null)
        {
            Vector3 posicaoDeCriacaoDaTorre = elementoAtingidoPeloRaio.point;
            Instantiate(torrePrefab, posicaoDeCriacaoDaTorre, Quaternion.identity);
        }
    }

    private RaycastHit DisparaRaioCameraAteUmPonto(Vector3 pontoInicial)
    {
       Ray raio = Camera.main.ScreenPointToRay(pontoInicial);
        RaycastHit elementoAtingidoPeloRaio;
        float comprimentoMaximoDoRaio = 100.0f;
        Physics.Raycast(raio, out elementoAtingidoPeloRaio, comprimentoMaximoDoRaio);

        return elementoAtingidoPeloRaio;
    }
}
