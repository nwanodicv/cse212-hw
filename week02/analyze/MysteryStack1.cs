public static class MysteryStack1 {
    public static string Run(string text) {
        var stack = new Stack<char>();  // create a stack of characters
        foreach (var letter in text)
            stack.Push(letter); // push each letter onto the stack

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();  // pop each letter (last in, first out) and append to result

        return result; // return the reversed string
    }
}