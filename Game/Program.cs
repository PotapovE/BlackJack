// 1. Мария - Метод создания колоды для игры (с тасовкой).

int [] Deck ()
{
    int [] result = new int [52];
    int j = 0;
    for (int i = 0; i < result.Length; i++)
    {
            if (i % 4 == 0) j++;
            result [i] = j;
    }
return result;
}

void Shuffle(int[] deck, int j)
{
    for (int i = 0; i < deck.Length; i++)
    {
        int temp = deck[i];
        int index = new Random().Next(0, deck.Length);
        deck[i] = deck[index];
        deck[index] = temp;
    }
    j--;
    if (j != 0) Shuffle(deck, j);
}

int [] deck = Deck ();
Shuffle(deck, 10);


// 2. Юрий - Метод названия карт.
// 3. Семён - Метод вытягивания карт из колоды (подсчет очков, подсчет использованный карт).
// 4. Ольга - Метод сравнения очков (кто победил, ничья).

// Метод подсчета очков 
// Из википедии - При окончательном подсчёте очков в конце раунда карты остальных игроков для вас 
// значения не имеют, игра ведётся только против дилера, то есть сравниваются карты только игрока и дилера, 
// карты и ставки параллельных игроков не учитываются.

// Использовала метод int, который возвращает значения, на случай дальнейшей доработки игры со ставками

// Dealer
// Player

int CalculateWinner(int dealerPoints, int playerPoints)
{
    if (playerPoints > 21) { Console.WriteLine("Увы, Вы проиграли"); return 0; } // перебор, снимается ставка
    else if (dealerPoints == playerPoints) { Console.WriteLine("У вас ничья!"); return 1; }
    else if (playerPoints == 21) { Console.WriteLine("BlackJack! Вы выиграли!"); return 3; } // выплачивается выигрыш 3 к 2
    else if ((dealerPoints > 21) && (dealerPoints != 21) || (playerPoints > dealerPoints))
    { Console.WriteLine("Поздравляем, Вы выиграли!"); return 2; }
    else Console.WriteLine("Увы, Вы проиграли!"); return 0;
}

CalculateWinner(19, 18);

// 5. Евгений - Метод цикла хода игры (сыграть ещё, или выйти).