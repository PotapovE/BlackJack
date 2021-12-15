// 1. Мария - Метод создания колоды для игры (с тасовкой).
// 2. Юрий - Метод названия карт.
// 3. Семён - Метод вытягивания карт из колоды (подсчет очков, подсчет использованный карт).
void BatchCards(int[] gameCardDeck, List<int> playerCards, int countBatchCard, int countAddCards)
{
    int batchStop = countBatchCard + countAddCards;
    if (countBatchCard > gameCardDeck.Length - 1) countBatchCard = 0;
    for (; countBatchCard < batchStop; countBatchCard++)
    {
        playerCards.Add(gameCardDeck[countBatchCard]);
    }
}
void DilerLogic(int[] gameCardDeck, List<int> dilerCards, int countBatchCard)
{
    while (dilerCards.ToArray().Sum() <= 17)
    {
        BatchCards(gameCardDeck, dilerCards, countBatchCard, 1);
        ShowCards(dilerCards);
    }
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
                    BatchCards(gameCardDeck, playersCards[n], gameStatus[1], 1);
                    ShowCards(playersCards[n]);
                    if (playersCards[n].ToArray().Sum() > 21) addCards = false;
                    break;
                case ConsoleKey.S: addCards = false; break;
                default: break;
            }
        }
    }
    DilerLogic(gameCardDeck, playersCards[playersCards.Length-1], gameStatus[1]);
}
void ShowCards(List<int> playerCards)
{
    foreach (int s in playerCards) System.Console.Write(string.Join(" ", s));
}
void GameProcess(int[] gameCardDeck, int[] gameStatus)
{
    // gameStatus будет содержать в себе:
    // [количество карт выданное игрокам;
    //  количество игроков (считая дилера)(на данный момент всегда будет "2");
    //  сумма очков первого игрока (пока единственного);
    //  сумма очков дилера]
    List<int>[] batchGame = new List<int>[gameStatus[1]];
    // для каждого игрока
    for (int n = 0, countPlayers = gameStatus[1] - 1; n < countPlayers; n++) 
    {
        //дилер выдает карты
        BatchCards(gameCardDeck, batchGame[n], gameStatus[1], 2);
        //вывод на экран
        ShowCards(batchGame[n]);
    }
    //Запрос на добавление карты !(Console.ReadKey(true).Key == ConsoleKey.Escape)
    FillCardsList(gameCardDeck, batchGame, gameStatus);
    //Запись всех очков в массив статуса игры
    
}
// 4. Ольга - Метод сравнения очков (кто победил, ничья).
// 5. Евгений - Метод цикла хода игры (сыграть ещё, или выйти).