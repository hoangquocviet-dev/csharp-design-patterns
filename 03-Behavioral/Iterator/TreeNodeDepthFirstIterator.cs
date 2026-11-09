using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Iterator;

public class TreeNode<T> {
    public T Value { get; set; }
    public TreeNode<T>? Left { get; set; }
    public TreeNode<T>? Right { get; set; }
    public TreeNode(T val) => Value = val;
}

public static class TreeExtensions {
    public static IEnumerable<T> DepthFirstTraversal<T>(TreeNode<T>? root) {
        if (root == null) yield break;
        yield return root.Value;
        foreach (var l in DepthFirstTraversal(root.Left)) yield return l;
        foreach (var r in DepthFirstTraversal(root.Right)) yield return r;
    }
}
