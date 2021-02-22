// https://www.electricmonk.nl/docs/dependency_resolving_algorithm/dependency_resolving_algorithm.html
using System;
using System.Collections.Generic;

public class PackageDependencyResolver{
    public static void Run(List<Tuple<string, string>> dependencies){
        if(dependencies == null){
            return;
        }

        var map = new Dictionary<string, List<string>>();
        foreach (var item in dependencies)
        {
            if(map.ContainsKey(item.Item1)){
                map[item.Item1].Add(item.Item2);
            }
            else{
                map.Add(item.Item1, new List<string>{item.Item2});
            }

            if(!map.ContainsKey(item.Item2)){
                map.Add(item.Item2, new List<string>());
            }
        }

        var resolved = new HashSet<string>();
        var seen = new HashSet<string>();

        foreach (var edge in map)
        {
            if(!resolved.Contains(edge.Key)){
                DFSUtil(edge.Key, map, resolved, seen);
            }
        }

        foreach (var item in resolved)
        {
            System.Console.WriteLine(item);
        }
    }

    private static void DFSUtil(string node, Dictionary<string, List<string>> map, HashSet<string> resolved, HashSet<string> seen)
    {
        if(map.ContainsKey(node)){
            seen.Add(node);

            foreach (var edge in map[node])
            {
                if(!resolved.Contains(edge)){
                    if(seen.Contains(edge)){
                        throw new Exception($"Package Circular dependency. {node} -> {edge}");
                    }
                    DFSUtil(edge, map, resolved, seen);
                }
            }

            resolved.Add(node);
        }
    }
}