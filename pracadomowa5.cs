using System;
using System.Collections.Generic;
using System.Xml.Linq;

class NodeG
{
    public string Data;
    public List<NodeG> Neighbors;

    public NodeG(string data)
    {
        Data = data;
        Neighbors = new List<NodeG>();
    }

    public void AddNeighbor(NodeG neighbor)
    {
        if (!Neighbors.Contains(neighbor))
        {
            Neighbors.Add(neighbor);
        }
    }

    public void RemoveNeighbor(NodeG neighbor)
    {
        Neighbors.Remove(neighbor);
    }
    
}

class Graph
{
    public List<NodeG> Nodes;

    public Graph()
    {
        Nodes = new List<NodeG>();
    }
    public NodeG AddNode(string data)
    {
        NodeG newNode = new NodeG(data);
        Nodes.Add(newNode);
        return newNode;
    }

    public void AddEdge(NodeG node1, NodeG node2)
    {
        node1.AddNeighbor(node2);
        node2.AddNeighbor(node1);
    }

    public void DisplayGraph()
    {
        foreach (var node in Nodes)
        {
            Console.Write(node.Data + " -> ");
            foreach (var neighbor in node.Neighbors)
            {
                Console.Write(neighbor.Data + " ");
            }
            Console.WriteLine();
        }
    }

    public void RemoveNode(NodeG node)
    {
        foreach (var currentNode in Nodes)
        {
            currentNode.RemoveNeighbor(node);
        }
        Nodes.Remove(node);
    }


}

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();

        NodeG nodeA = graph.AddNode("A");
        NodeG nodeB = graph.AddNode("B");
        NodeG nodeC = graph.AddNode("C");
        NodeG nodeD = graph.AddNode("D");

        graph.AddEdge(nodeA, nodeB);
        graph.AddEdge(nodeA, nodeC);
        graph.AddEdge(nodeB, nodeC);
        graph.AddEdge(nodeC, nodeD);

        graph.DisplayGraph();
        Console.WriteLine("\n");

        graph.RemoveNode(nodeA);

        graph.DisplayGraph();
    }
}
