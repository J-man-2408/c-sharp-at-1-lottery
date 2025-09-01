/* Lottery Sort and Search AT1 
 * Jasmine Sullivan 
 * 20147180
 * Certificate IV - C# - NMTAFE
 * 28/08/2025 - 00/00/0000 */


// Display Welcome Message and Instructions
using System.Globalization;

Console.WriteLine("Welcome to JASMINE'S INCREDIBLE LOTTERY!");
Console.WriteLine("You could win BIG if your chosen numbers match those selected by JASMINE'S INCREDIBLE LOTTERY MACHINE!\n");

// Cutomise Variables
int totalNumbers = 6;
int minValue = 1;
int maxValue = 49;

//Arrays to store
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
        if (isValid == false)
            Console.WriteLine("Invalid number chosen. Please select a number between " + minValue + " and " + maxValue + ": ");
        // Linear search to check for no duplicates
        if (isValid && LinearSearch(userNumbers, chosenNumber) != -1)
        {
            isValid = false;
            Console.WriteLine("You already chose that number. Please enter a differnt number.");
        }

    }
    while (!isValid);
// Store valid numbers
    userNumbers[i] = chosenNumber;
}

// Generate the random lottery numbers
Random rnd = new Random();
int randomNumbers = rnd.Next(minValue, maxValue);

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

    // Testing the lottery adn user numbers sorting
    // TAKE OUT BEFORE SUBMITTING!
    Console.WriteLine("Your lottery numbers are:");
    for (int i = 0; i < totalNumbers; i++)
    {
      Console.WriteLine(lotteryNumbers[i] + " ");
    }

Console.WriteLine("Your chosen numbers are:");
for (int i = 0; i < totalNumbers; i++)
{
    Console.WriteLine(userNumbers[i] + " ");
}
// Binary search to loop through the users numbers to see if it's in the lottery numbers
int matches = 0;

foreach (int number in userNumbers)
{
    if (BinarySearch(lotteryNumbers, number))
        matches++;
}

    // How many matches print out
    // TAKE OUT BEFORE SUBMITTING! 
    Console.WriteLine("Matches equal: ");
    for (int i = 0; i < matches; i++)
    {
        Console.WriteLine(matches);
    }

// Count total matches

// Display the results 

// Linear Search 
int LinearSearch(int[] arrayToSearch, int valueToFind)
{
    for (int i = 0; i < arrayToSearch.Length; i++)
    {
        if (arrayToSearch[i] == valueToFind)
        {
            return 1;
        }
    }
    return -1;
}

// Binary Search 
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


// Bubble Sort
