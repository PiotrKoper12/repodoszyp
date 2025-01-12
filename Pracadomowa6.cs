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
}

class DrzewoRozp
{
    public static List<Edge> Generete(Graph graph)
    {
        List<Edge> result = new List<Edge>();
        Dictionary<NodeG, NodeG> parent = new Dictionary<NodeG, NodeG>();

        NodeG Find(NodeG node)
        {
            if (parent[node] != node)
                parent[node] = Find(parent[node]);
            return parent[node];
        }

        void Union(NodeG node1, NodeG node2)
        {
            NodeG root1 = Find(node1);
            NodeG root2 = Find(node2);
            if (root1 != root2)
                parent[root1] = root2;
        }

        foreach (var node in graph.Nodes)
        {
            parent[node] = node;
        }

        var sortedEdges = graph.Edges.OrderBy(edge => edge.Weight).ToList();


        foreach (var edge in sortedEdges)
        {
            NodeG root1 = Find(edge.Node1);
            NodeG root2 = Find(edge.Node2);

            if (root1 != root2)
            {
                result.Add(edge);
                Union(root1, root2);
            }
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();

        var nodeA = graph.AddNode("A");
        var nodeB = graph.AddNode("B");
        var nodeC = graph.AddNode("C");
        var nodeD = graph.AddNode("D");

        graph.AddEdge(nodeA, nodeB, 4);
        graph.AddEdge(nodeA, nodeC, 3);
        graph.AddEdge(nodeB, nodeC, 2);
        graph.AddEdge(nodeC, nodeD, 5);
        graph.AddEdge(nodeB, nodeD, 6);

        List<Edge> xx = DrzewoRozp.Generete(graph);

        Console.WriteLine("Minimalne Drzewo Rozpinające:");
        foreach (var edge in xx)
        {
            Console.WriteLine($"{edge.Node1.Data} {edge.Weight}-> {edge.Node2.Data}");
        }
    }
}
