using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public Text attemptsText;
    public Text wordText;
    public Text feedbackText;
    public InputField inputField;

    private string[] words = { "code", "script", "refactoring", "class", "develop", "type", "method", "update", "trigger", "statement" };
    private string wordToGuess;
    private char[,] guessedLetters;
    private int attempts = 6;
    private bool wordGuessed = false;

    void Start()
    {
        StartGame();
        inputField.onEndEdit.AddListener(ProcessGuess);
    }

    void StartGame()
    {
        int randomIndex = UnityEngine.Random.Range(0, words.Length);
        wordToGuess = words[randomIndex];
        guessedLetters = new char[wordToGuess.Length, 2];

        for (int i = 0; i < wordToGuess.Length; i++)
        {
            guessedLetters[i, 0] = wordToGuess[i];
            guessedLetters[i, 1] = '_';
        }

        attempts = 6;
        wordGuessed = false;

        UpdateUI();
    }

    void UpdateUI()
    {
        attemptsText.text = "Attempts left: " + attempts;
        wordText.text = "Word: ";
        for (int i = 0; i < guessedLetters.GetLength(0); i++)
        {
            wordText.text += guessedLetters[i, 1] + " ";
        }
    }

    void ProcessGuess(string guess)
    {
        if (guess.Length > 0)
        {
            char guessedLetter = Char.ToLower(guess[0]);
            GuessLetter(guessedLetter);
            inputField.text = ""; 
            inputField.ActivateInputField();
        }
    }

    void GuessLetter(char guessedLetter)
    {
        if (!wordGuessed && attempts > 0)
        {
            bool letterFound = false;
            for (int i = 0; i < guessedLetters.GetLength(0); i++)
            {
                if (guessedLetters[i, 0] == guessedLetter)
                {
                    guessedLetters[i, 1] = guessedLetters[i, 0];
                    letterFound = true;
                }
            }

            if (!letterFound)
            {
                attempts--;
                feedbackText.text = "Incorrect guess!";
            }


            CheckWinCondition();
            UpdateUI();
        }
    }

    void CheckWinCondition()
    {
        wordGuessed = true;
        for (int i = 0; i < guessedLetters.GetLength(0); i++)
        {
            if (guessedLetters[i, 1] == '_')
            {
                wordGuessed = false;
                break;
            }
        }

        if (wordGuessed)
        {
            feedbackText.text = "Congratulations! You guessed the word: " + wordToGuess;
        }
        else if (attempts == 0)
        {
            feedbackText.text = "Sorry, you ran out of attempts. The word was: " + wordToGuess;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
