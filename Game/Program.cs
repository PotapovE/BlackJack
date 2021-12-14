// 1. Мария - Метод создания колоды для игры (с тасовкой).
// 2. Юрий - Метод названия карт.
// 3. Семён - Метод вытягивания карт из колоды (подсчет очков, подсчет использованный карт).
void BatchCards(int[] gameCardDeck, int[,] playersCards)
{
    for (int n = 0, i = 0; n < playersCards.GetLength(0); n++)
    {
        for (int m = 0; m < playersCards.GetLength(1); m++, i++)
        {
            playersCards[n,m] = gameCardDeck[i];
        }
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
    int[,] batchGame = new int[countPlayers, 10];
    //дилер выдает карты
    BatchCards(gameCardDeck, batchGame);
    // for (int i = 0; i < gameStatus[0]; i++) ShowCards()
    //вывод на экран
    //Проверка совпадений по правилам
    //предложение игроку выполнить действие
}
// 4. Ольга - Метод сравнения очков (кто победил, ничья).
// 5. Евгений - Метод цикла хода игры (сыграть ещё, или выйти).