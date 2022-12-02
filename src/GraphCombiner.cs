using System.Collections.Generic;
using Microsoft.Msagl.Drawing;
using static DependenciesViewer.CSSolve;

namespace DependenciesViewer
{
    public static class GraphCombiner
    {
        public static bool AddLineToNamespace = false;
        public static string LineToNamespaceText = "namespace";
        public static Graph GenerateGraph(IEnumerable<CSSolve> Solves)
        {
            var graph = new Graph()
            {
                Directed = true
            };

            List<Namespace> namespaces = new List<Namespace>();
            List<string> nodes = new List<string>();
            List<(string from, string to)> edges = new List<(string from, string to)>();

            void AddNode(string name)
            {
                graph.AddNode(name);
                nodes.Add(name);
            }
            void AddEdge(string begin, string end)
            {
                if (!nodes.Contains(begin))
                    AddNode(begin);
                if (!nodes.Contains(end))
                    AddNode(end);
                if (!edges.Contains((begin, end)))
                {
                    graph.AddEdge(begin, end);
                    edges.Add((begin, end));
                }
            }
            void AddEdgeWithLabel(string begin, string text, string end)
            {
                if (!nodes.Contains(begin))
                    AddNode(begin);
                if (!nodes.Contains(end))
                    AddNode(end);
                if (!edges.Contains((begin, end)))
                {
                    graph.AddEdge(begin, text, end);
                    edges.Add((begin, end));
                }
            }

            foreach (var solve in Solves)
                namespaces.AddRange(solve.ParseNamespaces());

            foreach (var @namespace in namespaces)
            {
                foreach (var @class in @namespace.Classes)
                    AddNode(@class.name);
                if (AddLineToNamespace)
                    AddNode(@namespace.name);

                foreach (var @class in @namespace.Classes)
                {
                    foreach (var extend in @class.extends)
                        AddEdge(@class.name, extend);
                    if (AddLineToNamespace)
                        AddEdgeWithLabel(@class.name, LineToNamespaceText, @namespace.name);
                }
            }

            return graph;
        }
    }
}
