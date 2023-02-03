using System;

// You are handling some product testing for a smartphone manufacturer..
// You are asked to find the maximum floor from which you can drop the device and have it survive the fall

public class Solution
{
    static void Main(string[] args)
    {
        int buildingFloors = 1000;
        bool didSurvive;
        var utilities = new Utilities(buildingFloors);

        /**********************************************************************************************************/
        /****Find the highest floor in a building from which you can drop a phone and it survives the fall*********/
        int maxSurvivalFloor = 1;

        didSurvive = utilities.DoesPhoneSurviveDropFromFloor(maxSurvivalFloor);

        for (int i = 0; i < buildingFloors; i++)
        {
            if (didSurvive == true)
            {
                maxSurvivalFloor++;
                didSurvive = utilities.DoesPhoneSurviveDropFromFloor(maxSurvivalFloor);
            }
        }
        maxSurvivalFloor--;
        
        Console.WriteLine($"This phone broke at floor {maxSurvivalFloor + 1} of {buildingFloors}."); 
        
        /**********************************************************************************************************/
        //IsCorrectFloor() can only be called once
        Console.WriteLine($"{utilities.IsCorrectFloor(maxSurvivalFloor)}");
        
        Console.WriteLine("Would you like to have another drop test? \nType Yes [Y] or No [N]");

        //String variable 'response' that gets user input to rerun the drop test
        string response = Console.ReadLine();

        if (response.ToUpper() == "Y")
            Main(null);
    }
}