using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2017.Extensions;

namespace AdventOfCode2017.Days
{
    // ReSharper disable once UnusedMember.Global
    class Day06 : Day
	{
		public Day06() : base(6) {}

		private void Reallocate(List<int> banks)
		{
			int max = banks.Max();
			int index = banks.IndexOf(max);

			banks[index] = 0;
			while (max > 0)
			{
				index = (index + 1) % banks.Count;
				banks[index]++;
				max--;
			}
		}
		
	    protected override object GetSolutionPart1()
	    {
            /*
             * --- Day 6: Memory Reallocation ---

				A debugger program here is having an issue: it is trying to repair a memory reallocation routine, but it keeps getting stuck in an infinite loop.
				
				In this area, there are sixteen memory banks; each memory bank can hold any number of blocks. The goal of the reallocation routine is to balance the blocks
				between the memory banks.
				
				The reallocation routine operates in cycles. In each cycle, it finds the memory bank with the most blocks (ties won by the lowest-numbered memory bank) and
				redistributes those blocks among the banks. To do this, it removes all of the blocks from the selected bank, then moves to the next (by index) memory bank and
				inserts one of the blocks. It continues doing this until it runs out of blocks; if it reaches the last memory bank, it wraps around to the first one.
				
				The debugger would like to know how many redistributions can be done before a blocks-in-banks configuration is produced that has been seen before.
				
				For example, imagine a scenario with only four memory banks:
				
					The banks start with 0, 2, 7, and 0 blocks. The third bank has the most blocks, so it is chosen for redistribution.
					Starting with the next bank (the fourth bank) and then continuing to the first bank, the second bank, and so on, the 7 blocks are spread out over the memory
					banks. The fourth, first, and second banks get two blocks each, and the third bank gets one back. The final result looks like this: 2 4 1 2.
					Next, the second bank is chosen because it contains the most blocks (four). Because there are four memory banks, each gets one block. The result is: 3 1 2 3.
					Now, there is a tie between the first and fourth memory banks, both of which have three blocks. The first bank wins the tie, and its three blocks are
					distributed evenly over the other three banks, leaving it with none: 0 2 3 4.
					The fourth bank is chosen, and its four blocks are distributed such that each of the four banks receives one: 1 3 4 1.
					The third bank is chosen, and the same thing happens: 2 4 1 2.
				
				At this point, we've reached a state we've seen before: 2 4 1 2 was already seen. The infinite loop is detected after the fifth block redistribution cycle,
				and so the answer in this example is 5.
				
				Given the initial block counts in your puzzle input, how many redistribution cycles must be completed before a configuration is produced that has been seen before?

             */
            #region Testrun

		    var testInputs = new List<int>()
		                     {
			                     0,
			                     2,
			                     7,
			                     0
		                     };
		    HashSet<string> testStates = new HashSet<string>();
		    int count = 0;
		    string stringState = string.Join("", testInputs);
		    while (!testStates.Contains(stringState))
		    {
			    testStates.Add(stringState);
			    Reallocate(testInputs);
			    stringState = string.Join("", testInputs);
			    count++;
		    }
		    
		    int expected = 5;
		    if (count != expected)
		    {
			    throw new Exception($"Expected: {expected}, Actual: {count}");
		    }
		    #endregion

		    List<int> banks = Input.Split('\t').Select(s => s.ToInt()).ToList();
		    count = 0;
		    
		    HashSet<string> states = new HashSet<string>();
		    stringState = string.Join("", banks);
		    while (!states.Contains(stringState))
		    {
			    states.Add(stringState);
			    Reallocate(banks);
			    stringState = string.Join("", banks);
			    count++;
		    }
		    
		    return count;
	    }

	    protected override object GetSolutionPart2()
	    {
            /*
             * --- Part Two ---

				Now, the jumps are even stranger: after each jump, if the offset was three or more, instead decrease it by 1. Otherwise, increase it by 1 as before.

				Using this rule with the above example, the process now takes 10 steps, and the offset values after finding the exit are left as 2 3 2 3 -1.

				How many steps does it now take to reach the exit?


             */
		    return base.GetSolutionPart2();
	    }
	}
}
