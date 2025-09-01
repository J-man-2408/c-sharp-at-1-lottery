/* Lottery Sort and Search AT1 
 * Jasmine Sullivan 
 * 20147180
 * Certificate IV - C# - NMTAFE
 * 28/08/2025 - 01/09/2025 */


// Display Welcome Message and Instructions
Console.WriteLine("Welcome to JASMINE'S INCREDIBLE LOTTERY!");
Console.WriteLine("You could win BIG if your chosen numbers match those selected by JASMINE'S INCREDIBLE LOTTERY MACHINE!\n");

// Customise Variables
int totalNumbers = 6;
int minValue = 1;
int maxValue = 49;

// Arrays to store
int[] userNumbers = new int[totalNumbers];
int[] lotteryNumbers = new int[totalNumbers];

// Prompt user
Console.WriteLine("Please enter " + totalNumbers + " numbers between " + minValue + " and " + maxValue);

// Loop and validate if its a number and in range
for (int i = 0; i < totalNumbers; i++)
{
    int chosenNumber;
    string userInput;
    bool isValid;

    do
    {
        Console.WriteLine("Enter number " + (i + 1) + ": ");
        userInput = Console.ReadLine();
        isValid = int.TryParse(userInput, out chosenNumber) && chosenNumber >= minValue && chosenNumber <= maxValue;
        if (!isValid)
            Console.WriteLine("Invalid number chosen. Please select a number between " + minValue + " and " + maxValue + ": ");
        // Linear search to check for no duplicates
        if (isValid && LinearSearch(userNumbers, chosenNumber) != -1)
        {
            isValid = false;
            Console.WriteLine("You already chose that number. Please enter a different number.");
        }

    }
    while (!isValid);
// Store valid numbers
    userNumbers[i] = chosenNumber;
}

// Generate the random lottery numbers
Random rnd = new Random();

for (int i = 0; i < totalNumbers; i++)
{
    int number;
    bool isUnique;
    do
    {
        number = rnd.Next(minValue, maxValue + 1);
        isUnique = LinearSearch(lotteryNumbers, number) == -1;
    }
    while (isUnique == false);
    lotteryNumbers[i] = number;
}

// Sort the lottery and users numbers numbers
Array.Sort(lotteryNumbers);
Array.Sort(userNumbers);

// Binary search to find how many matches were made
int matches = 0;

foreach (int number in userNumbers)
{
    if (BinarySearch(lotteryNumbers, number))
        matches++;
}

// Display the results depending on the matches made
Console.WriteLine("\nYour lottery numbers were:");
for (int i = 0; i < totalNumbers; i++)
{
    Console.WriteLine(lotteryNumbers[i]);
}

Console.WriteLine("Your chosen numbers were:");
for (int i = 0; i < totalNumbers; i++)
{
    Console.WriteLine(userNumbers[i] + " ");
}
Console.WriteLine("You matched " + matches + " number(s)!");

switch (matches)
{
    case 0:
        Console.WriteLine("Better luck next time!");
        break;
    case 1:
    case 2:
        Console.WriteLine("Not bad! Try again!");
        break;
    case 3:
    case 4:
        Console.WriteLine("So close! You matched a few! Keep trying!");
    break;
    case 5:
        Console.WriteLine("OMG! You were just one away from JASMINE'S INCREDIBLE JACKPOT!");
            break;
    case 6:
        Console.WriteLine("YOU'VE JUST WON JASMINE'S INCREDIBLE LOTTERY!!!");
        Console.WriteLine("*Terms & Conditions apply: By 'win,' we mean eternal bragging rights. No actual money will be deposited. Please don’t quit your day job.*");
        break;
}

// Linear Search: Returns the index of valueToFind if found; otherwise -1
int LinearSearch(int[] arrayToSearch, int valueToFind)
{
    for (int i = 0; i < arrayToSearch.Length; i++)
    {
        if (arrayToSearch[i] == valueToFind)
        {
            return i;
        }
    }
    return -1;
}

// Binary Search: Returns true if valueToFind is found in the sorted array; otherwise false
bool BinarySearch(int[] arrayToSearch, int valueToFind)
{
    int left = 0;
    int right = arrayToSearch.Length - 1;

    while (left <= right)
    {
        int mid = (left + right) / 2;
        if (arrayToSearch[mid] == valueToFind)
            return true;
        else if (arrayToSearch[mid] < valueToFind)
            left = mid + 1;
        else
            right = mid - 1;
    }

    return false;
}