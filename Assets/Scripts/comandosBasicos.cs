using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class comandosBasicos : MonoBehaviour {
    private Animator controleTela;
	public Image bt1;
	public Image bt2;
	public Image bt3;
	public Animator anim;
    
    public void carregaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }

    public void resetJogo()
    {
        PlayerPrefs.DeleteAll();
    }

	public void telaParabens(){
		anim.SetBool ("mudar", true);
	}

    public void abrirSite()
    {
        Application.OpenURL("https://ludus.programatche.net/");
    }

	public void atualizarBtnNivel()
	{
		int nivel = PlayerPrefs.GetInt ("nivel");
		switch (nivel) {
		case 1:
			bt1.sprite = Resources.Load<Sprite> ("Botoes/dif_91")as Sprite;
			bt2.sprite = Resources.Load<Sprite> ("Botoes/dif_95")as Sprite;
			bt3.sprite = Resources.Load<Sprite> ("Botoes/dif_97")as Sprite;
			break;
		case 2:
			bt1.sprite = Resources.Load<Sprite> ("Botoes/dif_93")as Sprite;
			bt2.sprite = Resources.Load<Sprite> ("Botoes/dif_89")as Sprite;
			bt3.sprite = Resources.Load<Sprite> ("Botoes/dif_97")as Sprite;
			break;
		case 3:
			bt1.sprite = Resources.Load<Sprite> ("Botoes/dif_93")as Sprite;
			bt2.sprite = Resources.Load<Sprite> ("Botoes/dif_95")as Sprite;
			bt3.sprite = Resources.Load<Sprite> ("Botoes/dif_87")as Sprite;
			break;
		default:
			bt1.sprite = Resources.Load<Sprite> ("Botoes/dif_91")as Sprite;
			bt2.sprite = Resources.Load<Sprite> ("Botoes/dif_95")as Sprite;
			bt3.sprite = Resources.Load<Sprite> ("Botoes/dif_97")as Sprite;
			break;
		}
	}

	public void trocarNivel(int nivel)
	{
		PlayerPrefs.SetInt ("nivel", nivel);
		atualizarBtnNivel ();

	}
    public void Animation()
    {
        controleTela = GetComponent<Animator>();
        float time;
        
            time = 5;
        

        
            if (time < 0)
            {
            controleTela.SetBool("Normal", time == 0);
        }
            else
            {
                time -= Time.deltaTime;
            }

    }

    public void encerrarAtividade()
    {
        Application.Quit();
    }

    public void abrirArquivo()
    {
        Application.OpenURL("C:/Users/Junior/Documents/GitHub/-ludus/Assets/Resources/Outros/Manual_do_Usuario.pdf");
    }

}
