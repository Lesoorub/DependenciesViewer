using Microsoft.Msagl.Core.ProjectionSolver;
using Microsoft.Msagl.Drawing;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DependenciesViewer
{
    public class CSSolve
    {
        public string name;
        public string path;

        List<Namespace> namespaces = new List<Namespace>();

        public CSSolve(string name, string path)
        {
            this.name = name;
            this.path = path;
        }

        public Graph GenerateGraph()
        {
            return GraphCombiner.GenerateGraph(new CSSolve[] { this });
        }

        public IEnumerable<Namespace> ParseNamespaces()
        {
            var solveFi = new FileInfo(path);

            foreach (var file in solveFi.Directory.GetFiles("*.cs", SearchOption.AllDirectories))
                ParseFile(file);

            return namespaces;
        }

        void ParseFile(FileInfo file)
        {
            var lines = File.ReadAllLines(file.FullName);
            var lastNamespace = Namespace.global;
            foreach (var line in lines)
            {
                
                var trimmed = line.TrimStart().Replace("partial", "");

                if (trimmed.StartsWith("namespace"))
                {
                    lastNamespace = AddNamespace(trimmed.Replace("namespace", "").Trim('{', ' '));
                    continue;
                }

                if (trimmed.StartsWith("public class") ||
                    trimmed.StartsWith("private class") ||
                    trimmed.StartsWith("internal class") ||
                    trimmed.StartsWith("class"))
                {
                    var protection = Class.Protection.@private;
                    if (trimmed.StartsWith("public"))
                        protection = Class.Protection.@public;
                    if (trimmed.StartsWith("internal"))
                        protection = Class.Protection.@internal;

                    var splitted = trimmed.Replace(":", " : ").Split(' ').ToList();
                    var classIndex = splitted.FindIndex(x => x.Equals("class"));
                    var deviderIndex = splitted.FindIndex(x => x.Equals(":"));
                    var whereIndex = splitted.FindIndex(x => x.Equals("where"));
                    if (deviderIndex == -1)
                        lastNamespace.AddClass(splitted[classIndex + 1], new string[0], protection);
                    else
                    {
                        lastNamespace.AddClass(
                            splitted[classIndex + 1], 
                            splitted
                            .Skip(deviderIndex + 1).Take(whereIndex - deviderIndex)
                            .Select(x => x.TrimEnd(' ', ','))
                            .Where(x => !string.IsNullOrWhiteSpace(x.Trim()))
                            .ToArray(),
                            protection);
                    }
                }
            }
        }
        Namespace AddNamespace(string name)
        {
            if (namespaces.Any(x => x.name.Equals(name)))
                return namespaces.First(x => x.name.Equals(name));
            Namespace result;
            namespaces.Add(result = new Namespace(name));
            return result;
        }

        public class Namespace
        {
            public string name;
            public static Namespace global = new Namespace("global");
            public List<Class> Classes = new List<Class>();

            public Namespace(string name)
            {
                this.name = name;
            }
            public void AddClass(string name, string[] extends, Class.Protection protection)
            {
                Classes.Add(new Class(name, this, extends, protection));
            }

            public override string ToString()
            {
                return $"{{ name={name}, classes=[\n {string.Join(",\n ", Classes.Select(x => x.ToString()))}\n] }}";
            }
        }

        public class Class
        {
            public string name;
            public Namespace Namespace;
            public Protection protection;
            public string[] extends;
            public enum Protection
            {
                @private = 0,
                @public,
                @internal
            }

            public Class(string name, Namespace @namespace, string[] extends, Protection protection = Protection.@private)
            {
                this.name = name;
                this.Namespace = @namespace;
                this.protection = protection;
                this.extends = extends;
            }

            public override string ToString()
            {
                return $"{{ {protection} {name}{(extends.Length > 0 ? (" : " + string.Join(", ", extends)) : "")} }}";
            }
        }
    }
}
