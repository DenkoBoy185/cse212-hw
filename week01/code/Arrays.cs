public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan for MultiplesOf:
        // Step 1: Create a new double array with a size equal to 'length', since we need
        //         exactly 'length' multiples in the result.
        // Step 2: Loop from index 0 up to (but not including) 'length'. For each index i,
        //         calculate the multiple by multiplying 'number' by (i + 1). For example,
        //         when i=0 the first multiple is number * 1, when i=1 it is number * 2, etc.
        // Step 3: Store each calculated multiple into the array at position i.
        // Step 4: After the loop finishes, return the completed array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan for RotateListRight:
        // Step 1: Calculate the split index. To rotate right by 'amount', the last 'amount'
        //         elements move to the front. The split index where the tail begins is
        //         (data.Count - amount). For example, with 9 elements and amount=3,
        //         splitIndex = 9 - 3 = 6, so elements at index 6,7,8 form the tail.
        // Step 2: Use GetRange(splitIndex, amount) to extract the tail — the elements that
        //         will move to the front of the list.
        // Step 3: Use GetRange(0, splitIndex) to extract the head — the elements that will
        //         remain at the back after the rotation.
        // Step 4: Clear the original data list so we can rebuild it in the new order.
        // Step 5: Add the tail first (using AddRange), then add the head (using AddRange).
        //         This produces the correctly rotated list in-place.

        int splitIndex = data.Count - amount;

        List<int> tail = data.GetRange(splitIndex, amount);
        List<int> head = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
