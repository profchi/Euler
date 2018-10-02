using System;
using System.Collections.Generic;
					
public class Program	
{
	// converts an integer to base 5
	static string convertToBase5(int n){
		string answer= "";
		if (n == 0)
			return "0";
		while(n != 0){
			answer = (n%5) + answer;
			n = n/5;
		}
		
	
		return answer;
	}
	
	//transforms the converted string into a 6 value array where each index corresponds to a side on the cube
	// the 1st side takes values from 0 - 4
	// the 2nd side takes values from 1 - 5
	// the 3rd side takes values from 2 - 6
	// the 4th side takes values from 3 - 7
	// the 5th side takes values from 4 - 8
	// the 6th side takes values from 5 - 9
	static int [] arrangeInArray(string s){
		while(s.Length != 6){
			s = "0" + s;
		}
		int [] myArray = new int[6];
		for (int i = 0; i < s.Length; ++i){
			myArray[i]	= (int)s[i] - 48;
			myArray[i] += i;
		}
		return myArray;
	}
	
	//Checks if the array are in a sequential order
	static bool checkIfSequential(int [] myArray){
		int minValue = myArray [0];
		for(int i = 1; i < myArray.Length; ++ i){
				if(myArray[i] <= minValue)
					return false;
				minValue = myArray[i];
		}
		return true;
	}
	
	
	//Gets the array of cube index and checks if they can form all perfect squares
	static bool Cubes(int [] x , int [] y){
		HashSet <int> firstCube = new HashSet <int>(x);
		HashSet <int> secondCube = new HashSet <int>(y);
		if(!((firstCube.Contains(0) && secondCube.Contains(1)) || (firstCube.Contains(1) && secondCube.Contains(0))))
			return false;
		else if(!((firstCube.Contains(0) && secondCube.Contains(4)) || (firstCube.Contains(4) && secondCube.Contains(0))))
			return false;
		else if(!((firstCube.Contains(0) && (secondCube.Contains(6) || secondCube.Contains(9))) || ((firstCube.Contains(6) || firstCube.Contains(9)) && secondCube.Contains(0))))
			return false;
		else if(!((firstCube.Contains(1) && (secondCube.Contains(6) || secondCube.Contains(9))) || ((firstCube.Contains(6) || firstCube.Contains(9)) && secondCube.Contains(1))))
			return false;
		else if(!((firstCube.Contains(2) && secondCube.Contains(5)) || (firstCube.Contains(5) && secondCube.Contains(2))))
			return false;
		else if(!((firstCube.Contains(3) && (secondCube.Contains(6) || secondCube.Contains(9))) || ((firstCube.Contains(6) || firstCube.Contains(9)) && secondCube.Contains(3))))
			return false;
		else if(!((firstCube.Contains(4) && (secondCube.Contains(6) || secondCube.Contains(9))) || ((firstCube.Contains(6) || firstCube.Contains(9)) && secondCube.Contains(4))))
			return false;
		else if(!(((firstCube.Contains(6) || firstCube.Contains(9)) && secondCube.Contains(4)) || (firstCube.Contains(4) && (secondCube.Contains(6) || secondCube.Contains(9)))))
			return false;
		else if(!((firstCube.Contains(8) && secondCube.Contains(1)) || (firstCube.Contains(1) && secondCube.Contains(8))))
			return false;
		else if (firstCube == secondCube)
			return false;
		else 
			return true;
		
	}
	public static void Main()
	{
		
		int count = 0;
		int [] firstcube;
		int [] secondcube;
		int starttime = Environment.TickCount;
		for (int i = 0; i < 12625; ++i){						//iterate through all possible cube arrangements
			firstcube = arrangeInArray(convertToBase5(i));		
			if (!checkIfSequential(firstcube)) 					// Skip if not sequential
				continue;
			for(int j = 0; j < 15625; ++j){						// iterate through all possible arrangements in the second cube
				secondcube = arrangeInArray(convertToBase5(j));
				if (!checkIfSequential(secondcube))				//Skip if not sequential
					continue;
				else if (Cubes(firstcube, secondcube)) 			
					count++;									//Increment if it can form all perfect squares
			}
		}
		Console.WriteLine(count / 2);							//Compensates for the cases of swapping both cubes
	}
	
}
