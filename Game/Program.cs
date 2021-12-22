// 1. Мария - Метод создания колоды для игры (с тасовкой).
// 2. Юрий - Метод названия карт.
// 3. Семён - Метод вытягивания карт из колоды (подсчет очков, подсчет использованный карт).
// Раздача карт
void BatchCards(int[] gameCardDeck, List<int> playerCards, int[] gameScore, int numbOfPlayer, int countAddCards)
{
    int batchStop = gameScore[0] + countAddCards;
    if (gameScore[0] > gameCardDeck.Length - 1) gameScore[0] = 0;
    for (; gameScore[0] < batchStop; gameScore[0]++)
    {
        playerCards.Add(gameCardDeck[gameScore[0]]);
    }
}
// Алгоритм набора карт для прикупа дилера
void DilerLogic(int[] gameCardDeck, List<int> dilerCards, int[] gameStatus)
{
    int dilerScore = gameStatus[gameStatus.Length - 1];
    while (CardTransferToScore(dilerCards) < 17)
    {
        BatchCards(gameCardDeck, dilerCards, gameStatus, gameStatus.Length, 1);
        dilerScore = CardTransferToScore(dilerCards);
        ShowCards(dilerCards, 0);
    }
    gameStatus[gameStatus.Length - 1] = dilerScore;
}
// Добавление карт игроку и дилеру
// TO DO если у игрока перебор, дилер не буурт
void FillCardsList(int[] gameCardDeck, List<int>[] playersCards, int[] gameStatus)
{
    int countBatchCard = gameStatus[0];
    int countPlayers = gameStatus[1] - 1;
    for (int n = 0; n < countPlayers; n++)
    {
        Console.WriteLine($"Играет {n+1} игрок");
        ShowCards(playersCards[n], 0);
        bool addCards = true;
        while (addCards)
        {
            Console.WriteLine("Добавить карту?");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.A:
                    BatchCards(gameCardDeck, playersCards[n], gameStatus, n, 1);
                    gameStatus[n + 2] = CardTransferToScore(playersCards[n]);
                    ShowCards(playersCards[n], 0);
                    if (gameStatus[n + 2] > 21) addCards = false;
                    break;
                case ConsoleKey.S: 
                    gameStatus[n + 2] = CardTransferToScore(playersCards[n]);
                    addCards = false;
                    break;
                default: 
                    Console.WriteLine("Для добавления карты нажмите A, для остановки - S");
                break;
            }
        }
    }
    DilerLogic(gameCardDeck, playersCards[playersCards.Length - 1], gameStatus);
}
// Подсчет очков
int CardTransferToScore(List<int> playerCards, int scorePlayer = 0, int countAce = 0, int tempCard = 0)
{
    for (int c = 0; c < playerCards.Count; c++)
    {
        tempCard = playerCards[c] % 100;
        if (tempCard == 1) countAce++;
        else if (tempCard >= 10) scorePlayer += 10;
        else scorePlayer += playerCards[c];
    }
    // Если есть тузы в прикупе и сума очков вместе с ними больше 21 => они превращаются в 1
    // Иначе => в 11
    scorePlayer += countAce > 0 && scorePlayer + 11*countAce <= 21 ? 11*countAce : countAce;
    return scorePlayer;
}

// Main Process
void GameProcess(int[] gameCardDeck, int[] gameStatus)
{
    // gameStatus будет содержать в себе:
    // [количество карт выданное игрокам;
    //  количество игроков (считая дилера)(на данный момент всегда будет "2");
    //  сумма очков первого игрока (пока единственного);
    //  сумма очков дилера]
    // Создавать можно n игроков, дилер будет всегда последний в этой 
    List<int>[] batchGame = new List<int>[gameStatus[1]];
    for (int i = 0; i < gameStatus[1]; i++) batchGame[i] = new List<int>();
    int startBatch = 2;
    // Для каждого юнита за игральным столом выдаются карты
    for (int n = 0; n < gameStatus[1]; n++)
    {
        BatchCards(gameCardDeck, batchGame[n], gameStatus, n, startBatch);
    }
    // Вывод карт дилера
    ShowCards(batchGame[gameStatus[1]-1], 1);
    //Запрос на добавление карты игроку и дилеру
    FillCardsList(gameCardDeck, batchGame, gameStatus);
    System.Console.WriteLine($"Очки игрока {gameStatus[2]}, очки дилера {gameStatus[3]}, выдано карт {gameStatus[0]}");
}
// Шаблон метода для Юрия, какие данные будут входящими
void ShowCards(List<int> playerCards, int countShowCards)
{
    if (countShowCards == 0) countShowCards = playerCards.Count;
    for (int i = 0; i < countShowCards; i++) Console.Write(playerCards[i]);
    System.Console.WriteLine();
}
int[] gameDesk = new int[] { 12, 11, 1, 1, 1, 6, 7, 8, 9 }, game = new int[] { 0, 2, 0, 0 };
GameProcess(gameDesk, game);
// 4. Ольга - Метод сравнения очков (кто победил, ничья).
// 5. Евгений - Метод цикла хода игры (сыграть ещё, или выйти).