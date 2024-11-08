using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private InputField input;

    private int num;
    private int countGuess;

    [SerializeField]
    private Text message;
    [SerializeField]
    private GameObject button;
    private void Awake()
    {
        input = GameObject.Find("Input").GetComponent<InputField>();
        num = Random.Range(1, 101);
        message.text = "Guess The Number\nBetween 1 and 100";
    }

    public void getInput(string guess)
    {
        countGuess++;
        compareGuesses(int.Parse(guess));
        input.text = "";
    }

    void compareGuesses(int guess)
    {
        if (guess == num)
        {
            message.text = "Your Guess Is Corret\nThe number was " + guess + "\nAnd It Took You " + countGuess + " Guess\nWanna Play Again?";
            button.SetActive(true);
        }
        else if (guess < num)
        {
            message.text = "Your Guess Is Less Than The Number Your Are Trying To Guess";
        }
        else if (guess > num)
        {
            message.text = "Your Guess Is Greater Than The Number Your Are Trying To Guess";
        }
    }

    public void playAgain()
    {
        input = GameObject.Find("Input").GetComponent<InputField>();
        num = Random.Range(1, 101);
        message.text = "Guess The Number\nBetween 1 and 100";
        countGuess = 0;
        button.SetActive(false);
    }
}