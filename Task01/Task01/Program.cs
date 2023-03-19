PowerCollections.Stack<int> test = new();
test.Push(1);
test.Push(2);
test.Push(55);
Console.WriteLine(test.Pop());
Console.WriteLine(test.Capacity);