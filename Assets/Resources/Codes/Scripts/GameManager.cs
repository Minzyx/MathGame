using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float delay;
    public TextMeshProUGUI text;
    public TMP_InputField input;
    public string difficulty;
    public int phasesNumber;

    public GameObject summary;
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI difficultyText;

    public RandomNumbers rn;

    
    public AudioSource somNumero;
    public AudioSource somErro;
    public AudioSource somCerto;
    public AudioSource somSummary;
   
    

    private int result;
    private bool isRunning = false;
    private int points = 0;
    private int currentPhase = 0;

    private void Start()
    {
        Debug.Log("Game Started");
        PhaseManager();
    }

    private void PhaseManager()
    {
        input.text = "";
        result = 0;
        currentPhase++;
        if (currentPhase <= phasesNumber)
        {
            rn.GenerateNums(rn.min, rn.max);
            RunNumbers(delay);
        }
        else
        {
            text.text = "Fim de Jogo!";
            text.fontSize = 80;
            input.gameObject.SetActive(false);
            Invoke("ShowSummary", 3f);
        }
    }

    private async Task RunNumbers(float delay)
    {
        isRunning = true;
        text.fontSize = 150;
        CloseInputInteraction();

        foreach (var number in rn.GetNumbers())
        {
            Debug.Log(number);
            text.text = number.ToString();
            text.enabled = true;

            if (somNumero != null)
                somNumero.Play();

            await Task.Delay((int)(delay * 1000));
            text.enabled = false;
            await Task.Delay(50);
            result += number;
        }

        text.text = "Responda...";
        OpenInputInteraction();
        text.enabled = true;
        isRunning = false;
    }

    public void CheckResult()
    {
        

        if (result == 0)
        if (isRunning) return;
        if (string.IsNullOrEmpty(input.text)) return;

        if (input.text == result.ToString())
        {
            text.text = "Correto!";
            CloseInputInteraction();
            if(somCerto != null)
                somCerto.Play();
            points += 10;
            Invoke("PhaseManager", 3f);
        }
        else
        {
            text.fontSize = 90;
            text.text = "Errado!\nResposta correta: " + result;
            if (somErro != null)
                somErro.Play();
            CloseInputInteraction();
            Invoke("PhaseManager", 3f);
        }
    }

    private void CloseInputInteraction()
    {
        input.interactable = false;
    }

    private void OpenInputInteraction()
    {
        input.interactable = true;
    }

    private void ShowSummary()
    {

        text.enabled = false;
        summary.SetActive(true);
        if (somSummary != null)
            somSummary.Play();
        pointsText.text = "Pontos: " + points;
        difficultyText.text = "Dificuldade: " + difficulty;
    }

    public void GoToMainMenu()
    {
       

        SceneManager.LoadScene("MainMenu");
    }

    
}
