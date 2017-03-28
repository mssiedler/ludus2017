
using System;
using System.Collections.Generic;
using System.Linq;

public class QuestaoAleatoria
{
	
	private delegate Questao geraQuestao(string op);
	public static String aleatoriaOp()
	{
		
		Random n1 = new Random();
		String retorno;
		int i = n1.Next (1, 4);
		switch (i) {
		case 1:
			retorno = "+";
			break;
		case 2:
			retorno = "-";
			break;
		case 3:
			retorno = "*";
			break;
		case 4:
			retorno = "/";
			break;

		default:
			retorno = "+";
			break;
		}


		return retorno;
	}

	public static Questao aleatoria(string op, int nivel)
	{
		geraQuestao gera;
		switch (nivel) {
		case 1:
			gera = new geraQuestao (nivel1);
			break;
		case 2:
			gera = new geraQuestao (nivel2);
			break;
		case 3:
			gera = new geraQuestao (nivel3);
			break;
		
		default:
			gera = new geraQuestao (nivel1);
			break;
		}

		

		return gera (op);

		
	}

	private static Questao nivel1(string op)
	{
		return carregaNofim(op,1,10);

	}
	private static Questao nivel2(string op)
	{
		return carregaNoMeio(op,1,10);

	}


	private static Questao nivel3(string op)
	{
		return carregaNofim(op,5,25);

	}

	private static Questao nivel4(string op)
	{
		return carregaNoMeio(op,5,25);

	}

	private static Questao carregaNoMeio(string op, int valorinicial, int valormaximo)
	{
		Random n1 = new Random();
		 valormaximo = 10;

		int a = n1.Next(valorinicial+1,valormaximo);
		int b = n1.Next(valorinicial,valormaximo);

		if (op.Equals ("%")) {
			op = QuestaoAleatoria.aleatoriaOp ();
		}

		int certa=0;
		switch (op)
		{
		case "+":
			certa = a + b;
			break;
		case "-":
			b =  n1.Next(1,a-1);
			certa = a - b;
			break;
		case "*":
			a = n1.Next (valorinicial+1, valormaximo/2);
			b = n1.Next (valorinicial, valormaximo/2);
			certa = a * b;
			op = "x";
			break;
		case "/":
			a = n1.Next (valorinicial+1, valormaximo/2);
			b = n1.Next (valorinicial, a - 1);
			op = "÷";
			while (a % b != 0) {
				a = n1.Next (valorinicial+1, valormaximo/2 );
				b = n1.Next (valorinicial, a - 1);
			}
			certa = a / b;
			break; 
		default:
			certa = a + b;
			break;

		}
		String enunciado;

		if (n1.Next (1, 2) == 1) {
			enunciado = a.ToString () + op+ "?="+certa.ToString();
			certa = b;
		} else {
			enunciado = "?"+ op+ b.ToString()+"="+certa.ToString();
			certa = a;
		}
		int errada1 = certa;
		int errada2 = certa;
		while (errada1 == certa || errada1<0)
			errada1 = n1.Next(certa - 3, certa + 4);
		while (errada2 == certa || errada2<0 || errada2==errada1)
			errada2 = n1.Next(certa - 3, certa + 4);
		
		 
		List<int> lista = new List<int>();
		lista.Add(certa);
		lista.Add(errada1);
		lista.Add(errada2);
		var query = from i in lista let r = n1.Next() orderby r select i;
		lista = query.ToList();


		Questao q = new Questao(enunciado, lista[0], lista[1], lista[2], certa);
		return q;
	}



	public static Questao carregaNofim(String op,int valorinicial, int valormaximo){
		Random n1 = new Random();


		int a = n1.Next(valorinicial+1,valormaximo);
		int b = n1.Next(valorinicial,valormaximo);

		if (op.Equals ("%")) {
			op = QuestaoAleatoria.aleatoriaOp ();
		}

		int certa=0;
		switch (op)
		{
		case "+":
			certa = a + b;
			break;
		case "-":
			b =  n1.Next(1,a-1);
			certa = a - b;
			break;
		case "*":
			a = n1.Next (valorinicial+1, valormaximo/2);
			b = n1.Next (valorinicial, valormaximo/2);
			certa = a * b;
			op = "x";
			break;
		case "/":
			a = n1.Next (valorinicial+1, valormaximo/2);
			b = n1.Next (valorinicial, a - 1);
			op = "÷";
			while (a % b != 0) {
				a = n1.Next (valorinicial+1, valormaximo/2);
				b = n1.Next (valorinicial, a - 1);
			}
			certa = a / b;
			break; 
		default:
			certa = a + b;
			break;

		}

		int errada1 = certa;
		int errada2 = certa;
		while (errada1 == certa || errada1<0)
			errada1 = n1.Next(certa - 6, certa + 8);
		while (errada2 == certa || errada2<0|| errada2==errada1)
			errada2 = n1.Next(certa - 6, certa + 8);

		String enunciado = a.ToString() + op + b.ToString() + "=?";
		List<int> lista = new List<int>();
		lista.Add(certa);
		lista.Add(errada1);
		lista.Add(errada2);
		var query = from i in lista let r = n1.Next() orderby r select i;
		lista = query.ToList();


		Questao q = new Questao(enunciado, lista[0], lista[1], lista[2], certa);
		return q;

	}

}
