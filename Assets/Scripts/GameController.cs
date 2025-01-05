using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private InputField input;
    private int guessChances = 7;

    private int num;
    private int countGuess;

    [SerializeField]
    private Text message;
    [SerializeField]
    private GameObject PlayAgainButton;

    private void Awake()
    {
        input = GameObject.Find("Input").GetComponent<InputField>();
        num = Random.Range(1, 101);
        message.text = "Unlock The Device by Guessing the Number\nBetween 1 and 100";
    }

    public void OnNumberButtonClick(int number)
    {
        input.text += number.ToString();
    }

    public void SubmitGuess()
    {
        if (int.TryParse(input.text, out int guess))
        {
            countGuess++;
            guessChances--;
            CompareGuesses(guess);
            input.text = "";
        }
        else
        {
            message.text = "Please enter a valid number!";
        }
    }

    private void CompareGuesses(int guess)
    {
        if (guess == num)
        {
            message.text = "YOU WON!\nIN " +countGuess+" TRIES\n\nThe Password was: " + num +"\n\nWant to play again?";
            PlayAgainButton.SetActive(true);
        }
        else if (guessChances > 0)
        {
            if (guess < num)
            {
                message.text = $"Your guess is too low!\nChances left: {guessChances}";
            }
            else
            {
                message.text = $"Your guess is too high!\nChances left: {guessChances}";
            }
        }
        else
        {
            message.text = $"GAME OVER! You've used all your chances.\nThe Password was {num}.\n\nWant to play again?";
            PlayAgainButton.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        num = Random.Range(1, 101);
        message.text = "Unlock The Device by Guessing the Password\nBetween 1 and 100";
        countGuess = 0;
        guessChances = 7;
        PlayAgainButton.SetActive(false);
    }

    public void ClearInput()
    {
        input.text = "";
    }
}
