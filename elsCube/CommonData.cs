
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elsCube
{
    public enum CubeType
    {
        Cube,
        Line,
        Corner,
        Triangle,
        ReverseCorner,
        ZType,
        ReverseZType
    }

    public enum Direction
    {
        Down,
        Left,
        Right
    }

    public enum SpinType
    {
        Spin0,
        Spin90,
        Spin180,
        Spin270
    }

    public class Node
    {
        public Node(int x, int y, bool occupy, Color backColor)
        {
            _x = x;
            _y = y;
            _bOccupy = occupy;
            _backColor = backColor;
        }
        private int _x;
        private int _y;
        private bool _bOccupy = false;
        private bool _bStop = false;
        private Color _backColor;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public bool BOccupy { get => _bOccupy; set => _bOccupy = value; }
        public bool BStop { get => _bStop; set => _bStop = value; }
        public Color BackColor { get => _backColor; set => _backColor = value; }

        public override bool Equals(object node)
        {
            return ((Node)node).X == this.X && ((Node)node).Y == this.Y;
        }

        public override int GetHashCode()
        {
            return int.Parse(X.ToString() + Y.ToString());
        }

        public static bool operator ==(Node left, Node right)
        {
            return Equals(left, right);
        }

        //重写!=操作符
        public static bool operator !=(Node left, Node right)
        {
            return !Equals(left, right);
        }
    }
}
