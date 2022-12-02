using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Msagl.Core.ProjectionSolver;
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
                lock (nodes)
                {
                    if (!nodes.Contains(begin))
                        AddNode(begin);
                    if (!nodes.Contains(end))
                        AddNode(end);
                }
                lock (edges)
                {
                    if (!edges.Contains((begin, end)))
                    {
                        graph.AddEdge(begin, end);
                        edges.Add((begin, end));
                    }
                }
            }
            void AddEdgeWithLabel(string begin, string text, string end)
            {
                lock (nodes)
                {
                    if (!nodes.Contains(begin))
                        AddNode(begin);
                    if (!nodes.Contains(end))
                        AddNode(end);
                }
                lock (edges)
                {
                    if (!edges.Contains((begin, end)))
                    {
                        graph.AddEdge(begin, text, end);
                        edges.Add((begin, end));
                    }
                }
            }

            Parallel.ForEach(Solves, (solve) =>
            {
                namespaces.AddRange(solve.ParseNamespaces());
            });

            Parallel.ForEach(namespaces, (@namespace) =>
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
            });

            return graph;
        }
    }
}
