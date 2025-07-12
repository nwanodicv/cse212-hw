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

        // Plan:
        // 1. Yor have to Create a new Array 'Result' of size 'Length'.
        // 2. Then Loop from i = 0 to lenght - 1:
        //    a. Each Element at index i is the starting number multiplied by (i + 1).
        //       - For example index 0 -> number * 1 and index 1 -> number * 2 etc.
        // 3. Assign the computed value into result [i].
        // 4. After the Loop, return the 'result' array.

        var result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = i + 1;
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

        // Plan:
        // 1. Get the number of items to rotate from the end: that is the 'amount'. After.
        // 2. Then Use GetRange to capture the last 'amount' elements as the 'tail'.
        // 3. Move that tail from the original list using RemoveRange. And then
        // 4. Insert the tail at the beginning using InsertRange.
        //
        // Example for data = {1,2,3,4,5,6,7,8,9}, amount = 3:
        // - tail = {7,8,9}
        // - data after removing tail: {1,2,3,4,5,6}
        // - after inserting tail at position 0: {7,8,9,1,2,3,4,5,6}

        // Extract tail
        var tail = data.GetRange(data.Count - amount, amount);

        // Move or remove tail from the original list
        data.RemoveRange(data.Count - amount, amount);

        // Add tail to the beginning
        data.InsertRange(0, tail);
    }
}
