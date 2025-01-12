using System;
using System.Collections.Generic;
using System.Linq;

class NodeG
{
    public string Data;

    public NodeG(string data)
    {
        Data = data;
    }
}

class Edge
{
    public NodeG Node1;
    public NodeG Node2;
    public int Weight;

    public Edge(NodeG node1, NodeG node2, int weight)
    {
        Node1 = node1;
        Node2 = node2;
        Weight = weight;
    }
}

class Graph
{
    public List<NodeG> Nodes = new List<NodeG>();
    public List<Edge> Edges = new List<Edge>();

    public NodeG AddNode(string data)
    {
        var newNode = new NodeG(data);
        Nodes.Add(newNode);
        return newNode;
    }

    public void AddEdge(NodeG node1, NodeG node2, int weight)
    {
        Edges.Add(new Edge(node1, node2, weight));
    }

    public string Dijkstra(NodeG startNode, NodeG targetNode)
    {
        var distances = new Dictionary<NodeG, int>();
        var unvisitedNodes = new List<NodeG>(Nodes);

        foreach (var node in Nodes)
        {
            distances[node] = int.MaxValue;
        }
        distances[startNode] = 0;

        while (unvisitedNodes.Count > 0)
        {
            var currentNode = unvisitedNodes.OrderBy(node => distances[node]).First();

            if (currentNode == targetNode)
            {
                return $"Najkrótsza odległość wynosi: {distances[currentNode]}";
            }

            unvisitedNodes.Remove(currentNode);

            foreach (var edge in Edges.Where(edge => edge.Node1 == currentNode || edge.Node2 == currentNode))
            {
                NodeG neighbor;
                if (edge.Node1 == currentNode)
                {
                    neighbor = edge.Node2;
                }
                else
                {
                    neighbor = edge.Node1;
                }
                if (!unvisitedNodes.Contains(neighbor)) continue;

                var newDist = distances[currentNode] + edge.Weight;
                if (newDist < distances[neighbor])
                {
                    distances[neighbor] = newDist;
                }
            }
        }

        return "Wierzchołek docelowy jest nieosiągalny";
    }
}

class Program
{
    static void Main(string[] args)
    {
        var graph = new Graph();

        var A = graph.AddNode("A");
        var B = graph.AddNode("B");
        var C = graph.AddNode("C");
        var D = graph.AddNode("D");
        var E = graph.AddNode("E");

        graph.AddEdge(A, B, 4);
        graph.AddEdge(A, C, 2);
        graph.AddEdge(B, C, 5);
        graph.AddEdge(B, D, 10);
        graph.AddEdge(C, E, 3);
        graph.AddEdge(E, D, 4);

        Console.WriteLine(graph.Dijkstra(A, D));
    }
}
