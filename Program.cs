// Пользователь с клавиатуры вводит некоторый текст.
// Приложение должно изменять регистр первой буквы
// каждого предложения на букву в верхнем регистре.
// Например, если пользователь ввёл: «today is a good
// day for walking.i will try to walk near the sea».
// Результат работы приложения: «Today is a good day
// for walking.I will try to walk near the sea».

using static System.Console;
WriteLine("Введите строку для редактирования: ");
string? stringLine;
int lineLength;

// Проверка на наличие только определённых символов в строке.
// Например, если строка в строке тольлко символы точек, то возвращает "true".
bool isFullOfSign(string line, int lineLength, char sign)
{
	bool fullOfSign = true;
	for (int i = 0; i < lineLength; i++)
    {
		if (line[i] != sign)
			fullOfSign = false;
    }
	return fullOfSign;
}

bool lineIsOk = true;
// Цикл, пока строка не будет заполнена словами.
do
{
	stringLine = ReadLine();
	lineLength = stringLine.Length;
	if (lineLength == 0 || isFullOfSign(stringLine, lineLength, '.') || isFullOfSign(stringLine, lineLength, '!') || isFullOfSign(stringLine, lineLength, '?'))
		lineIsOk = false;
	if (!lineIsOk)
		WriteLine("В строке нет слов! Повторите ввод.");
} while (!lineIsOk);

// Копирование строки для её редактирования.
char[] charLine = stringLine.ToCharArray();
bool raiseNextSign = true;

// Перебор символов для определения - нужно ли ставить после него заглавную букву
// и их изменение.
for (int i = 0; i < lineLength; i++)
{
	// Если символ равен ".", "!" или "?", то следующий символ,
	// равный букве, будет сделан заглавным. 
	if (charLine[i] == '.' || charLine[i] == '!' || charLine[i] == '?')
		raiseNextSign = true;
	// Если символ не равен ".", " ", "!" или "?",
	// то символ будет сделан заглавным.
	if (raiseNextSign && charLine[i] != '.' && charLine[i] != '!' && charLine[i] != '?' && charLine[i] != ' ')
	{
		charLine[i] = char.ToUpper(charLine[i]);
		raiseNextSign = false;
	}
}

// Копирование изменённой строки в оригинальную строку
// и её печать.
stringLine = new string(charLine);
WriteLine("Редактированная строка:");
WriteLine(stringLine);