// 1. Мария - Метод создания колоды для игры (с тасовкой).
// 2. Юрий - Метод названия карт.
// 3. Семён - Метод вытягивания карт из колоды (подсчет очков, подсчет использованный карт).
void BatchCards(int[] gameCardDeck, List<int> playerCards, int[] gameScore, int numbOfPlayer, int countAddCards)
{
    int batchStop = gameScore[0] + countAddCards;
    if (gameScore[0] > gameCardDeck.Length - 1) gameScore[0] = 0;
    for (; gameScore[0] < batchStop; gameScore[0]++)
    {
        playerCards.Add(gameCardDeck[gameScore[0]]);
    }
}

void DilerLogic(int[] gameCardDeck, List<int> dilerCards, int[] gameStatus)
{
    int dilerScore = gameStatus[gameStatus.Length - 1];
    while (dilerScore <= 17)
    {
        BatchCards(gameCardDeck, dilerCards, gameStatus, gameStatus.Length, 1);
        dilerScore = CardTransferToScore(dilerCards);
        ShowCards(dilerCards);
    }
    gameStatus[gameStatus.Length - 1] = dilerScore;
}

void FillCardsList(int[] gameCardDeck, List<int>[] playersCards, int[] gameStatus)
{
    int countBatchCard = gameStatus[0];
    int countPlayers = gameStatus[1] - 1;
    for (int n = 0; n < countPlayers; n++)
    {
        bool addCards = true;
        while (addCards)
        {
            Console.WriteLine("Добавить?");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.A:
                    BatchCards(gameCardDeck, playersCards[n], gameStatus, n, 1);
                    gameStatus[n + 2] = CardTransferToScore(playersCards[n]);
                    ShowCards(playersCards[n]);
                    if (playersCards[n].ToArray().Sum() > 21) addCards = false;
                    break;
                case ConsoleKey.S: addCards = false; break;
                default: break;
            }
        }
    }
    DilerLogic(gameCardDeck, playersCards[playersCards.Length - 1], gameStatus);
}

void ShowCards(List<int> playerCards)
{
    foreach (int s in playerCards) System.Console.Write(string.Join(" ", s));
    System.Console.WriteLine();
}

int CardTransferToScore(List<int> playerCards, int scorePlayer = 0)
{
    bool aceScoreOne = false;
    // if (scorePlayer > 21 && playerCards.Exists(e => e == 1)) aceUpper = true;
    if (playerCards.Where(e => e == 1).Count() >= 2) aceScoreOne = true;
    for (int c = 0; c < playerCards.Count; c++)
    {
        switch (playerCards[c])
        {
            case 1:
                if (aceScoreOne) scorePlayer += 1;
                else scorePlayer += 11;
                break;
            case 11 | 12 | 13 | 14:
                scorePlayer += 10;
                break;
            default:
                scorePlayer += playerCards[c];
                break;
        }
    }
    return scorePlayer;
}

void GameProcess(int[] gameCardDeck, int[] gameStatus)
{
    // gameStatus будет содержать в себе:
    // [количество карт выданное игрокам;
    //  количество игроков (считая дилера)(на данный момент всегда будет "2");
    //  сумма очков первого игрока (пока единственного);
    //  сумма очков дилера]
    List<int>[] batchGame = new List<int>[gameStatus[1]];
    for (int i = 0; i < gameStatus[1]; i++) batchGame[i] = new List<int>();
    int startBatch = 2;
    // для каждого игрока
    for (int n = 0, countPlayers = gameStatus[1] - 1; n < countPlayers; n++)
    {
        //дилер выдает карты
        BatchCards(gameCardDeck, batchGame[n], gameStatus, n, startBatch);
        //вывод на экран
        ShowCards(batchGame[n]);
    }
    //Запрос на добавление карты !(Console.ReadKey(true).Key == ConsoleKey.Escape)
    FillCardsList(gameCardDeck, batchGame, gameStatus);
    System.Console.WriteLine($"Очки игрока {gameStatus[2]}, очки дилера{gameStatus[3]}");
}

int[] gameDesk = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, game = new int[] { 0, 2, 0, 0 };
GameProcess(gameDesk, game);
// 4. Ольга - Метод сравнения очков (кто победил, ничья).
// 5. Евгений - Метод цикла хода игры (сыграть ещё, или выйти).