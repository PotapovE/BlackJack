// 1. Мария - Метод создания колоды для игры (с тасовкой).

/*                 Туз   Два  Три  Четыре  Пять  Шесть  Семь  Восемь  Девять   Десять   Валет   Дама   Король*/
int [] suitCards = {1,    2,   3,    4,      5,    6,     7,    8,      9,       10,     11,     12,     13};

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

void Shuffle (int [] deck)
{
for (int i = 0; i < deck.Length; i++)
{
    int temp = deck[i];
    int index = new Random().Next(0, deck.Length);
    deck [i] = deck [index];
    deck [index] = temp;
}
}

string PrintMyArray(int[] collect)
{
    string outputString = String.Empty;
    for (int pos = 0; pos < collect.Length; pos++) outputString += $"{collect[pos]} ";
    return outputString;
}

int [] FindCount (int [] array, int [] values)
{
int [] count = new int [values.Length];
for (int h = 0; h < values.Length; h++)
{
for (int i = 0; i < array.Length; i++)
{
    if (values[h] == array[i]) count[h]++;
}
}
return count;
}

string PrintCounts (int [] count, int [] values)
{
    string outputString = String.Empty;
    for (int i = 0; i < count.Length; i++)
    {
        outputString += $"{values[i]} встречается {count[i]} раз;\n";
    }
return outputString;
}

int [] deck = Deck ();
Shuffle(deck);
Console.WriteLine(PrintMyArray(deck));

int [] cardsCheck = FindCount(deck, suitCards);
Console.WriteLine(PrintCounts(cardsCheck, suitCards));

// 2. Юрий - Метод названия карт.
// 3. Семён - Метод вытягивания карт из колоды (подсчет очков, подсчет использованный карт).
// 4. Ольга - Метод сравнения очков (кто победил, ничья).
// 5. Евгений - Метод цикла хода игры (сыграть ещё, или выйти).