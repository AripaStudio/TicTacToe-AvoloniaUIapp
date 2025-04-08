using Avalonia.Controls;
using System;
using Avalonia.Interactivity;


namespace TicTacToeAP.Views;

public partial class MainView : UserControl
{
    char[,] board = new char[3, 3];
    char currentPlayer = 'X';
    bool gameOver = false;
    public MainView()
    {
        InitializeComponent();
    }

    public int row;
    public int col;
    
    private void ButtonClick_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is string tag)
        {
            var coordinates = tag.Split(',');
             row = int.Parse(coordinates[0]);
             col = int.Parse(coordinates[1]);
            if (!gameOver && board[row , col] == '\0')
            {
                board[row , col] = currentPlayer;

                button.Content = currentPlayer.ToString();

                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';

                if (CheckWin())
                {
                    gameOver = true;
                    Lbl_WinName.Content = currentPlayer + " Win";
                    ResetGame();
                }
                else if (IsBoardFull())
                {
                    gameOver = true;
                    ResetGame();
                }
            }
        }
    }

    public bool CheckWin()
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
            {
                return true;
            }
        }
        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
            {
                return true;
            }
        }
        // Check diagonals
        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
        {
            return true;
        }
        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
        {
            return true;
        }
        return false;
    }

    public bool IsBoardFull()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == '\0')
                {
                    return false;
                }
            }
        }
        return true;
    }

    void ResetGame()
    {
        // 1. پاک کردن برد
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = '\0';
            }
        }

        // 2. بازگرداندن بازیکن فعلی
        currentPlayer = 'X';

        // 3. ریست کردن وضعیت بازی
        gameOver = false;

        // 4. پاک کردن محتوای دکمه‌ها
        Button0_0.Content = string.Empty;
        Button0_1.Content = string.Empty;
        Button0_2.Content = string.Empty;
        Button1_0.Content = string.Empty;
        Button1_1.Content = string.Empty;
        Button1_2.Content = string.Empty;
        Button2_0.Content = string.Empty;
        Button2_1.Content = string.Empty;
        Button2_2.Content = string.Empty;


       
    }

    private void Btn_ResetGame_OnClick(object? sender, RoutedEventArgs e)
    {
     ResetGame();   
    }
}
