using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elsCube
{
    public class CommonHelper
    {
        static public List<Node> CompareToFindNodeList(List<Node> list1, List<Node> list2)
        {
            return list1.Where(x => !list2.Contains(x)).ToList();
        }

        static public List<Node> DeepCloneNodeList(List<Node> list1)
        {
            List<Node> nodes = new List<Node>();
            foreach (var node in list1)
            {
                Node n = node.DeepClone();
                nodes.Add(n);
            }
            return nodes;
        }

        static public List<Node> ResetNodeAttr(List<Node> nodes)
        {
            foreach (var node in nodes)
            {
                node.BOccupy = false;
            }
            return nodes;
        }
    }
}
