public class Utilities{

    private Random rnd = new Random();    
    private int maxFloor;
    private int breakFloor;
    private bool[] floorResults;
    private bool hasFinalCheckRun = false;
    private int totalTestCount = 0;
    private int totalBrokenPhones = 0;

    public Utilities(int maxSize){
        maxFloor = maxSize - 1;
        breakFloor = rnd.Next(0, maxSize);
        CreateFloorDropResultsArray(maxSize);
    }

    public bool DoesPhoneSurviveDropFromFloor(int floor){
        totalTestCount++;
        bool validFloor = CheckMaxFloor(floor);
        if(!validFloor){
            return validFloor;
        }
        if(!floorResults[floor])
            totalBrokenPhones++;
        return floorResults[floor];
    }

    public bool IsCorrectFloor(int floor){
        if(!hasFinalCheckRun){
            Console.WriteLine($"Total of {totalTestCount} attempts run.");
            Console.WriteLine($"Total of {totalBrokenPhones} phones broken.");
            Console.WriteLine($"Final result is {DistanceFromCorrectAnswer(floor)} floors away from the correct floor");
            hasFinalCheckRun = true;
            return floor == (breakFloor - 1);
        }
        Console.WriteLine("Already ran final check. Only allowed one final check.");
        return false;
    }

    private void CreateFloorDropResultsArray(int maxFloors){
        floorResults =  new bool[maxFloors];
        for(int i = 0; i < maxFloors; i++){
            floorResults[i] = (i < breakFloor);
        }
    }

    private bool CheckMaxFloor(int floor){
        if(floor > maxFloor){
            Console.WriteLine("invalid floor");
            totalBrokenPhones++;
            return false;
        }
        return true;
    }

    private int DistanceFromCorrectAnswer(int floor){
        return Math.Abs(breakFloor - floor - 1);
    }
}