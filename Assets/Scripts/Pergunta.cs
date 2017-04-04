using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
//GIT
public class Pergunta : MonoBehaviour {
	public Animator menino;
	public Animator galina;
	public Animator galina2;
	public Animator galina3;

	public Text pergunta;
	public Text b1;
	public Text b2;
	public Text b3;
	//  public Text n;

	public int idPergunta;
	public string questoes;
	public int respA;
	public int respB;
	public int respC;
	public int certa;
	public Questao q;

	public int nivel;
	private Moeda din;
	public int tenta;

	public bool proxima;

	public static float velocidade; //velocidade do movimento do objeto

	public GameObject g1;
	public GameObject g2;
	public GameObject g3;

	public Galinha galinha1;
	public Galinha galinha2;
	public Galinha galinha3;

	private int pontosOperacao;
	private string operacaoAtual;

	public Pergunta()
	{
		
	}


	void Start () {
		din = FindObjectOfType (typeof(Moeda)) as Moeda;
		//verdicia se tem moedas salvas - se tem atualiza
		idPergunta = 0;


	
		if (PlayerPrefs.HasKey ("op")) {
			operacaoAtual = PlayerPrefs.GetString ("op");
		}
		else{
		
			operacaoAtual = "+";
		}
		//Aqui tem a definição do nível - pode passar de um a quatro
		//definido no hub de entrada

		if (PlayerPrefs.HasKey ("nivel")) {
			nivel = PlayerPrefs.GetInt ("nivel");
		}
		else{

			nivel = 1;
		}
		 q = QuestaoAleatoria.aleatoria (operacaoAtual, nivel);
		tenta = 3;
		pontosOperacao = 0;




		this.pergunta.text = q.questoes;
		this.b1.text = q.respA + "";
		this.b2.text = q.respB + "";
		this.b3.text = q.respC + "";


		//posicao original -- -46 / 141 / 307


		galinha1 = new Galinha (g1, 200, 31 - 46.0f);
		galinha1.attribuirAnimation (galina);
		galinha2 = new Galinha (g2, 250, 31+16f);
		galinha2.attribuirAnimation (galina2);
		galinha3 = new Galinha (g3, 300, 31+73f);
		galinha3.attribuirAnimation (galina3);
		velocidade = -1.08f;
		proxima = false;



	}

	public void trocaOperacao()
	{
		
		comandosBasicos cb = new comandosBasicos ();
		int estrelas;
	
		estrelas = 0;//desconsiderarei temporariamente
		switch (operacaoAtual) {

		case "+":
			
			PlayerPrefs.SetInt ("estrelas"+(estrelas+1).ToString(), calcularEstrelas ());
			//operacaoAtual = "-";

			cb.carregaCena ("Fim");
			break;
		case "-":
			PlayerPrefs.SetInt ("estrelas"+(estrelas+2).ToString(), calcularEstrelas ());
			//operacaoAtual = "*";

			cb.carregaCena ("Fim");
			break;
		case "*":
			PlayerPrefs.SetInt ("estrelas"+(estrelas+3).ToString(), calcularEstrelas ());
			//operacaoAtual = "/";

			cb.carregaCena ("Fim");
			break;
		case "/":
			PlayerPrefs.SetInt ("estrelas"+(estrelas+4).ToString(), calcularEstrelas ());
			//operacaoAtual = "%";

			cb.carregaCena ("Fim");		
			break;
		case "%":
			PlayerPrefs.SetInt ("estrelas"+(estrelas+5).ToString(), calcularEstrelas ());
			//operacaoAtual = null;
			//perguntas = misturado;

			cb.carregaCena ("Parabens");
			break;

		default:
			break;
		}




	}

	void proximaPergunta()
	{

		idPergunta += 1;

		//verifica se é fim de jogo

		if (idPergunta==5) {
			trocaOperacao ();
			proxima = false;
		} else {
			proxima = true;
			tenta = 3;

			q = QuestaoAleatoria.aleatoria (operacaoAtual, nivel);
		}




	}

	public void exibeTitulo()
	{
		pergunta.text = q.questoes;
	}


	public void verificaResposta(string alternativa)
	{
		menino.SetBool("erra", false);
		menino.SetBool("erra2", false);
		menino.SetBool("acerta", false);
		bool certa;
		int valor = 1;
		switch (alternativa) {
		case "A": 
			if(q.certa == q.respA )
			{

				din.adicionaValor( valor * tenta);
				menino.SetBool("acerta", true);
				//grava o valor das moedas
				PlayerPrefs.SetInt("moedas", din.dinheiro);
				PlayerPrefs.Save();
				pontosOperacao += valor * tenta;
				proximaPergunta();
				galinha1.setMovimento ("E");
				galinha2.setMovimento ("D");
				galinha3.setMovimento ("D");
				certa = true;//aquiiiiii
				//aqui a animacao que deu certo

			}
			else
			{
				//aqui a animacao que deu errado
				animaErro();

				if(tenta != 1){
					tenta = tenta - 1;
				}
			}
			break;
		case "B":
			if(q.certa == q.respB)
			{
				din.adicionaValor(valor * tenta);
				menino.SetBool("acerta", true);
				PlayerPrefs.SetInt("moedas", din.dinheiro);
				PlayerPrefs.Save();
				pontosOperacao += valor * tenta;
				proximaPergunta();
					certa = true;
				galinha1.setMovimento ("D");
				galinha2.setMovimento ("E");
				galinha3.setMovimento ("D");

			}
			else{
				animaErro();
				if(tenta != 1){
					tenta = tenta - 1;
				}
			}
			break;
		case "C": 
			if(q.certa == q.respC)
			{
				din.adicionaValor(valor * tenta);
				menino.SetBool("acerta", true);
				PlayerPrefs.SetInt("moedas", din.dinheiro);
				PlayerPrefs.Save();
				pontosOperacao += valor * tenta;
				proximaPergunta();
				certa = true;
				galinha1.setMovimento ("D");
				galinha2.setMovimento ("D");
				galinha3.setMovimento ("E");

			}else
			{
				animaErro();
				if(tenta != 1){
					tenta = tenta - 1;
				}
			}
			break;
		}



	}


	// Update is called once per frame
	void FixedUpdate () {

		galinha1.andarGalinha ();
		galinha2.andarGalinha ();
		galinha3.andarGalinha ();

		if (galinha1.parado && galinha2.parado && galinha3.parado) {
			if (proxima) {

				this.pergunta.text = q.questoes;
				this.b1.text = q.respA + "";
				this.b2.text = q.respB + "";
				this.b3.text = q.respC + "";
				proxima = false;
				menino.SetBool("acerta", false);
				galinha1.setMovimento ("I");
				galinha2.setMovimento ("I");
				galinha3.setMovimento ("I");
			} 

		}

	}

	private int calcularEstrelas()
	{
		int estrelas;
		pontosOperacao += 3;
		if (pontosOperacao>= 13) {
			estrelas = 3;
		} else if (pontosOperacao >= 10) {
			estrelas = 2;
		} else {
			estrelas = 1;
		}
		pontosOperacao = 0;
		return estrelas;

	}

	private void animaErro()
	{
		switch (tenta) {

		case 3:
			menino.SetBool ("erra", true);
			break;
		case 2:
			menino.SetBool ("erra2", true);
			break;
		case 1:
			menino.SetBool ("erra", true);
			break;

		default:
			break;
		}
	}

}