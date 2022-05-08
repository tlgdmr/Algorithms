using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;


class Player
{
    public class Node
    {
        private readonly IList<Node> graph;

        public Node(IList<Node> graph, int index)
        {
            this.graph = graph;
            Index = index;
        }

        public int Index { get; }
        public bool IsGateway { get; set; }

        private ICollection<int> links = new LinkedList<int>();

        public void AddLink(int link) => links.Add(link);
        public void RemoveLink(int link) => links.Remove(link);

        public IEnumerable<Node> Neighbours => links.Select(i => graph[i]);
    }

    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways

        List<Node> graph = new List<Node>();
        graph.AddRange(Enumerable.Range(0, N)
            .Select(i => new Node(graph, i)));

        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int n1 = int.Parse(inputs[0]);
            int n2 = int.Parse(inputs[1]);

            graph[n1].AddLink(n2);
            graph[n2].AddLink(n1);
        }

        for (int i = 0; i < E; i++)
        {
            int gi = int.Parse(Console.ReadLine());
            graph[gi].IsGateway = true;
        }

        while (true)
        {
            int agentNode = int.Parse(Console.ReadLine());

            int n1, n2;

            Node gateway = graph[agentNode].Neighbours.FirstOrDefault(n => n.IsGateway);
            if (gateway != null)
            {
                n1 = agentNode;
                n2 = gateway.Index;
            }
            else
            {
                (n1, n2) = graph.Where(n => n.IsGateway)
                            .SelectMany(g => g.Neighbours.Select(n => (g.Index, n.Index)))
                            .First();
            }

            graph[n1].RemoveLink(n2);
            graph[n2].RemoveLink(n1);

            Console.WriteLine($"{n1} {n2}");
        }
    }
}