
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;

public class ManterPerguntas  {

	List<Questao> perguntasSoma;
	List<Questao> perguntasMisturado;
	List<Questao> perguntasDivisao;
	List<Questao> perguntasMultiplicacao;
	List<Questao> perguntasSubtracao;

	public ManterPerguntas(){
		this.escreverPerguntasIniciais ();
		this.carregarPerguntas ();
	}

	public void escreverPerguntasIniciais(){

		perguntasSoma = new List<Questao> ();

		perguntasSoma.Add(new Questao("5+4=?", 1, 9, 7, 9));
		perguntasSoma.Add(new Questao("3+2=?", 4, 1, 5, 5));
		perguntasSoma.Add(new Questao("1+1=?", 2, 0, 4, 2));
		perguntasSoma.Add(new Questao("7+3=?", 8, 5, 10, 10));
		perguntasSoma.Add(new Questao("1+2=?", 4, 3, 5, 3));
		perguntasSoma.Add(new Questao("5+4=?", 1, 9, 7, 9));
		perguntasSoma.Add(new Questao("3+2=?", 4, 1, 5, 5));
		perguntasSoma.Add(new Questao("1+1=?", 2, 0, 4, 2));
		perguntasSoma.Add(new Questao("7+3=?", 8, 5, 10, 10));
		perguntasSoma.Add(new Questao("1+2=?", 4, 3, 5, 3));


		//SUBTRAÇÃO 
		perguntasSubtracao = new List<Questao> ();
		perguntasSubtracao.Add(new Questao("18-5=?", 11, 13, 3, 13));
		perguntasSubtracao.Add(new Questao("22-10=?", 12, 10, 14, 12));
		perguntasSubtracao.Add(new Questao("17-6=?", 11, 5, 10, 11));
		perguntasSubtracao.Add(new Questao("2-1=?", 4, 1, 6,1));
		perguntasSubtracao.Add(new Questao("19-1=?", 15, 18, 14, 18));
		perguntasSubtracao.Add(new Questao("18-5=?", 11, 13, 3, 13));
		perguntasSubtracao.Add(new Questao("22-10=?", 12, 10, 14, 12));
		perguntasSubtracao.Add(new Questao("17-6=?", 11, 5, 10, 11));
		perguntasSubtracao.Add(new Questao("2-1=?", 4, 1, 6, 1));
		perguntasSubtracao.Add(new Questao("19-1=?", 15, 18, 14, 18));


		//MULTIPLICAÇÃO
		perguntasMultiplicacao = new List<Questao> ();
		perguntasMultiplicacao.Add(new Questao("3*3=?",1,9,7,9));
		perguntasMultiplicacao.Add(new Questao("5*1=?",4,1,5,5));
		perguntasMultiplicacao.Add(new Questao("2*2=?",2,0,4,4));
		perguntasMultiplicacao.Add(new Questao("4*2=?",8,0,4,8));
		perguntasMultiplicacao.Add(new Questao("4*1=?",4,0,4,4));

		//DIVISÃO
		perguntasDivisao = new List<Questao> ();
		perguntasDivisao.Add(new Questao("18/2=?", 9, 1, 7, 9));
		perguntasDivisao.Add(new Questao("15/3=?", 5, 1, 1, 5));
		perguntasDivisao.Add(new Questao("4/2=?", 2, 0, 4, 2));
		perguntasDivisao.Add(new Questao("5*2=?", 10, 5, 11, 10));
		perguntasDivisao.Add(new Questao("18/6=?", 3, 1, 5, 3));

		//MISTURADO
		perguntasMisturado = new List<Questao> ();
		perguntasMisturado.Add(new Questao("5+4=?", 9, 8, 7, 9));
		perguntasMisturado.Add(new Questao("10-5=?", 5, 1, 4, 5));
		perguntasMisturado.Add(new Questao("2*1=?", 2, 0, 4, 2));
		perguntasMisturado.Add(new Questao("7+3=?", 10, 5, 9, 10));
		perguntasMisturado.Add(new Questao("18/6=?", 3, 2, 5, 3));

		XmlSerializer gameSerializer = new XmlSerializer(typeof(List<Questao>));
		TextWriter writeStream = new StreamWriter(Application.dataPath + "/perguntasSoma1.xml");
		gameSerializer.Serialize(writeStream, perguntasSoma);
		writeStream.Close();




	}

	public void carregarPerguntas(){
	
		// Deserialize the current game state
		XmlSerializer gameSerializer = new XmlSerializer(typeof(List<Questao>));
		FileStream readStream = new FileStream(Application.dataPath + "/perguntasSoma1.xml", FileMode.Open);
		perguntasSoma = (List<Questao>) gameSerializer.Deserialize(readStream);
		readStream.Close();


	}
}
