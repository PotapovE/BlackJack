// 1. Мария - Метод создания колоды для игры (с тасовкой).

int[] Deck()
{
    int[] result = new int[52];
    int j = 0;
    for (int i = 0; i < result.Length-1; i++)
    {
        if (i % 4 == 0) 
        {
            j++;
            result [i] = 100 + j;
        }
        result [i + 1] = result [i] + 100;
    }
    return result;
}

void Shuffle(int[] deck /*, int j*/)
{
    for (int i = 0; i < deck.Length; i++)
    {
        int temp = deck[i];
        int index = new Random().Next(0, deck.Length);
        deck[i] = deck[index];
        deck[index] = temp;
    }
    /*j--;
    if (j != 0) Shuffle(deck, j);*/
}

int [] deck = Deck ();
Shuffle(deck);


// 2. Юрий - Метод названия карт.
// 3. Семён - Метод вытягивания карт из колоды (подсчет очков, подсчет использованный карт).
// 4. Ольга - Метод сравнения очков (кто победил, ничья).
// 5. Евгений - Метод цикла хода игры (сыграть ещё, или выйти).