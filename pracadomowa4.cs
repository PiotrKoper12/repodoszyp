using System;
using System.Collections.Generic;
using System.Linq;

public class HuffmanNode
{
    public char Symbol;
    public int Frequency;
    public HuffmanNode Left;
    public HuffmanNode Right;

    public bool IsLeaf()
    {
        return Right == null && Left == null;
    }
}

public class HuffmanTree
{
    public HuffmanNode Root;
    private Dictionary<char, string> Codes = new Dictionary<char, string>();

    public void Build(string input)
    {
        var frequencyTable = input.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        
        var priorityQueue = new PriorityQueue<HuffmanNode, int>();

        foreach (var x in frequencyTable)
        {
            priorityQueue.Enqueue(new HuffmanNode { Symbol = x.Key, Frequency = x.Value }, x.Value);
        }


        while (priorityQueue.Count > 1)
        {
            var left = priorityQueue.Dequeue();
            var right = priorityQueue.Dequeue();


            var parent = new HuffmanNode
            {
                Symbol = '\0',
                Frequency = left.Frequency + right.Frequency,
                Left = left,
                Right = right
            };

            priorityQueue.Enqueue(parent, parent.Frequency);
        }

        Root = priorityQueue.Dequeue();

        GenerateCodes(Root, "");
    }

    private void GenerateCodes(HuffmanNode node, string code)
    {
        if (node == null)
            return;

        if (node.IsLeaf())
        {
            Codes[node.Symbol] = code;
        }

        GenerateCodes(node.Left, code + "0");
        GenerateCodes(node.Right, code + "1");
    }


    public string Encode(string input)
    {
        var encoded = string.Join("", input.Select(c => Codes[c]));
        return encoded;
    }


    public string Decode(string encodedInput)
    {
        var current = Root;
        var decoded = "";

        foreach (var bit in encodedInput)
        {
            if (bit == '0')
            {
                current = current.Left;
            }
            else
            {
                current = current.Right;
            }

            if (current.IsLeaf())
            {
                decoded += current.Symbol;
                current = Root;
            }
        }

        return decoded;
    }

    public void PrintCodes()
    {
        foreach (var x in Codes)
        {
            Console.WriteLine($"{x.Key}: {x.Value}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {

        string input = "aaabbcdddd";

        var huffmanTree = new HuffmanTree();
        huffmanTree.Build(input);

        Console.WriteLine("Kody Huffmana:");
        huffmanTree.PrintCodes();

        string encoded = huffmanTree.Encode(input);
        Console.WriteLine($"\nSkompresowany tekst: {encoded}");

        string decoded = huffmanTree.Decode(encoded);
        Console.WriteLine($"\nOdkodowany tekst: {decoded}");
    }
}