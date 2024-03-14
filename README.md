# 03-Hangman-IEbner
Hangman is a simple game where you have to guess a word related to coding. If you use all of your six attempts, you automatically lose and need to restart. If you guess the word within those attempts you win.

**Dev Platform**: Windows 11, Unity 2022.3.9f1, Visual Studio 2019

**Leasons Learned**: Coding mit ChatGPT, Klassendiagramme Wiederholung

```mermaid
classDiagram
    MonoBehaviour <|-- GameManagement

    class GameManagement{
        + attemptsText: Text
        + wordText: Text
        + feedbackText: Text
        + inputField: InputField 

        - words: string[]
        - wordToGuess: string
        - guessedLetters: char[]
        - attempts: int 
        - wordGuessed: bool

        - Start() void
        - StartGame() void
        - UpdateUI() void
        - ProcessGuess(guess: string) void
        - GuessLetter(guessesLetter: char) void
        - CheckWinCondition() void
        + Reload() void

    }
```
