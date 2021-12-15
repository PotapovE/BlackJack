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
void GameProcess(int[] gameCardDeck, int[] gameStatus)
{
    // gameStatus будет содержать в себе:
    // [количество игроков (на данный момент всегда будет "1");
    //  количество карт выданное игрокам;
    //  сумма очков дилера;
    //  сумма очков первого игрока (пока единственного)]
    int countPlayers = gameStatus[0] + 1;
    List<int>[] batchGame = new List<int>[countPlayers];
    //дилер выдает карты
    for (int n = 0; n < countPlayers - 1; n++) BatchCards(gameCardDeck, batchGame[n], gameStatus[1],2);
    //вывод на экран
    ShowCards(batchGame);
    //Запрос на добавление карты !(Console.ReadKey(true).Key == ConsoleKey.Escape)
    for (int n = 0; n < countPlayers - 1; n++)
    {
        bool addCards = true;
        while (addCards)
        {
            Console.WriteLine("Добавить?");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.A:
                    BatchCards(gameCardDeck, batchGame[n], gameStatus[1],1);
                    ShowCards(batchGame);
                    // если новая карта больше 22, то возвращаем addCards = false;
                    break;
                case ConsoleKey.S: addCards = false; break;
                default: break;
            }
        }
    }
    // DilerLogic();
}
// 4. Ольга - Метод сравнения очков (кто победил, ничья).
// 5. Евгений - Метод цикла хода игры (сыграть ещё, или выйти).