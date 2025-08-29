/* Lottery Sort and Search AT1 
 * Jasmine Sullivan 
 * 20147180
 * Certificate IV - C# - NMTAFE
 * 28/08/2025 - 00/00/0000 */


// Display Welcome Message and Instructions
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
Console.WriteLine("Please enter " + totalNumbers + " between " + minValue + " and " + maxValue);

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
            Console.WriteLine("Invalid number chosen. Please try again.");
    }
    while (!isValid);

    userNumbers[i] = chosenNumber;
}

// Linear search to check for no duplicates

// Store valid numbers

// Generate the random lottery numbers

// Sort the lottery numbers

// Binary search to loop through the users numbers to see if it's in the lottery numbers

// Count total matches

// Display the results 
