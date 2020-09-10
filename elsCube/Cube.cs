using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elsCube
{
    public class Cube
    {
        public Cube(CubeType cubeType, Color color, SpinType spin = SpinType.Spin0)
        {
            _cubeType = cubeType;
            _backColor = color;
            _spin = spin;
            Init();
        }
        private CubeType _cubeType;
        private List<Node> _nodes;
        private Color _backColor;
        private SpinType _spin;


        public CubeType CubeType { get => _cubeType; set => _cubeType = value; }
        public List<Node> Nodes { get => _nodes; set => _nodes = value; }
        public Color BackColor { get => _backColor; set => _backColor = value; }
        public SpinType Spin { get => _spin; set => _spin = value; }

        public void Down()
        {
            foreach(var nodes in _nodes)
            {
                ++nodes.Y;
            }
        }

        public void Left()
        {
            foreach (var nodes in _nodes)
            {
                --nodes.X;
            }
        }

        public void Right()
        {
            foreach (var nodes in _nodes)
            {
                ++nodes.X;
            }
        }

        /// <summary>
        /// 寻找方块旋转需要的位置
        /// </summary>
        /// <returns></returns>
        public List<Node> FindAvaildSpinRect()
        {
            List<Node> nodes = new List<Node>();
            switch (this.CubeType)
            {
                case CubeType.Line:
                    nodes = FindLineCubeAvaildSpinRect();
                    break;
                case CubeType.Corner:
                    nodes = FindCornerCubeAvaildSpinRect();
                    break;
                case CubeType.Triangle:
                    nodes = FindTriangleCubeAvaildSpinRect();
                    break;
                case CubeType.ReverseCorner:
                    nodes = FindReverseCornerCubeAvaildSpinRect();
                    break;
                case CubeType.ZType:
                    nodes = FindZTypeCubeAvaildSpinRect();
                    break;
                case CubeType.ReverseZType:
                    nodes = FindReverseZTypeCubeAvaildSpinRect();
                    break;
            }
            return nodes;
        }

        public List<Node> FindLineCubeAvaildSpinRect()
        {
            List<Node> nodes = new List<Node>();
            switch (this.Spin)
            {
                case SpinType.Spin0:
                    nodes.Add(this.Nodes[0]);
                    nodes.Add(new Node(this.Nodes[1].X + 1, this.Nodes[1].Y + 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[2].X + 2, this.Nodes[2].Y + 2, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X + 3, this.Nodes[3].Y + 3, true, this.BackColor));
                    break;
                case SpinType.Spin90:
                    nodes.Add(this.Nodes[0]);
                    nodes.Add(new Node(this.Nodes[1].X - 1, this.Nodes[1].Y - 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[2].X - 2, this.Nodes[2].Y - 2, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X - 3, this.Nodes[3].Y - 3, true, this.BackColor));
                    break;
                case SpinType.Spin180:
                    nodes.Add(this.Nodes[0]);
                    nodes.Add(new Node(this.Nodes[1].X - 1, this.Nodes[1].Y + 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[2].X - 2, this.Nodes[2].Y + 2, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X - 3, this.Nodes[3].Y + 3, true, this.BackColor));
                    break;
                case SpinType.Spin270:
                    nodes.Add(this.Nodes[0]);
                    nodes.Add(new Node(this.Nodes[1].X + 1, this.Nodes[1].Y - 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[2].X + 2, this.Nodes[2].Y - 2, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X + 3, this.Nodes[3].Y - 3, true, this.BackColor));
                    break;
            }
            return nodes;
        }

        public List<Node> FindCornerCubeAvaildSpinRect()
        {
            List<Node> nodes = new List<Node>();
            switch (this.Spin)
            {
                case SpinType.Spin0:
                    nodes.Add(this.Nodes[0]);
                    nodes.Add(new Node(this.Nodes[1].X + 1, this.Nodes[1].Y + 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[2].X + 2, this.Nodes[2].Y + 2, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X - 1, this.Nodes[3].Y + 1, true, this.BackColor));
                    break;
                case SpinType.Spin90:
                    nodes.Add(this.Nodes[0]);
                    nodes.Add(new Node(this.Nodes[1].X - 1, this.Nodes[1].Y + 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[2].X - 2, this.Nodes[2].Y + 2, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X - 1, this.Nodes[3].Y - 1, true, this.BackColor));
                    break;
                case SpinType.Spin180:
                    nodes.Add(this.Nodes[0]);
                    nodes.Add(new Node(this.Nodes[1].X - 1, this.Nodes[1].Y - 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[2].X - 2, this.Nodes[2].Y - 2, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X + 1, this.Nodes[3].Y - 1, true, this.BackColor));
                    break;
                case SpinType.Spin270:
                    nodes.Add(this.Nodes[0]);
                    nodes.Add(new Node(this.Nodes[1].X + 1, this.Nodes[1].Y - 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[2].X + 2, this.Nodes[2].Y - 2, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X + 1, this.Nodes[3].Y + 1, true, this.BackColor));

                    break;
            }
            return nodes;
        }

        public List<Node> FindTriangleCubeAvaildSpinRect()
        {
            List<Node> nodes = new List<Node>();
            switch (this.Spin)
            {
                case SpinType.Spin0:
                    nodes.Add(new Node(this.Nodes[0].X + 1, this.Nodes[0].Y - 1, true, this.BackColor));
                    nodes.Add(this.Nodes[1]);
                    nodes.Add(new Node(this.Nodes[2].X - 1, this.Nodes[2].Y + 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X + 1, this.Nodes[3].Y + 1, true, this.BackColor));
                    break;
                case SpinType.Spin90:
                    nodes.Add(new Node(this.Nodes[0].X + 1, this.Nodes[0].Y + 1, true, this.BackColor));
                    nodes.Add(this.Nodes[1]);
                    nodes.Add(new Node(this.Nodes[2].X - 1, this.Nodes[2].Y - 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X - 1, this.Nodes[3].Y + 1, true, this.BackColor));

                    break;
                case SpinType.Spin180:
                    nodes.Add(new Node(this.Nodes[0].X - 1, this.Nodes[0].Y + 1, true, this.BackColor));
                    nodes.Add(this.Nodes[1]);
                    nodes.Add(new Node(this.Nodes[2].X + 1, this.Nodes[2].Y - 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X - 1, this.Nodes[3].Y - 1, true, this.BackColor));

                    break;
                case SpinType.Spin270:
                    nodes.Add(new Node(this.Nodes[0].X - 1, this.Nodes[0].Y - 1, true, this.BackColor));
                    nodes.Add(this.Nodes[1]);
                    nodes.Add(new Node(this.Nodes[2].X + 1, this.Nodes[2].Y + 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X + 1, this.Nodes[3].Y - 1, true, this.BackColor));
                    break;
            }
            return nodes;
        }

        public List<Node> FindReverseCornerCubeAvaildSpinRect()
        {
            List<Node> nodes = new List<Node>();
            switch (this.Spin)
            {
                case SpinType.Spin0:
                    nodes.Add(this.Nodes[0]);
                    nodes.Add(new Node(this.Nodes[1].X + 1, this.Nodes[1].Y + 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[2].X + 2, this.Nodes[2].Y + 2, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X + 1, this.Nodes[3].Y - 1, true, this.BackColor));
                    break;
                case SpinType.Spin90:
                    nodes.Add(this.Nodes[0]);
                    nodes.Add(new Node(this.Nodes[1].X - 1, this.Nodes[1].Y + 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[2].X - 2, this.Nodes[2].Y + 2, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X + 1, this.Nodes[3].Y + 1, true, this.BackColor));
                    break;
                case SpinType.Spin180:
                    nodes.Add(this.Nodes[0]);
                    nodes.Add(new Node(this.Nodes[1].X - 1, this.Nodes[1].Y - 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[2].X - 2, this.Nodes[2].Y - 2, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X - 1, this.Nodes[3].Y + 1, true, this.BackColor));
                    break;
                case SpinType.Spin270:
                    nodes.Add(this.Nodes[0]);
                    nodes.Add(new Node(this.Nodes[1].X + 1, this.Nodes[1].Y - 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[2].X + 2, this.Nodes[2].Y - 2, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X - 1, this.Nodes[3].Y - 1, true, this.BackColor));
                    break;
            }
            return nodes;
        }

        public List<Node> FindZTypeCubeAvaildSpinRect()
        {
            List<Node> nodes = new List<Node>();
            switch (this.Spin)
            {
                case SpinType.Spin0:
                    nodes.Add(new Node(this.Nodes[0].X + 1, this.Nodes[0].Y - 1, true, this.BackColor));
                    nodes.Add(this.Nodes[1]);
                    nodes.Add(new Node(this.Nodes[2].X + 1, this.Nodes[2].Y + 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X, this.Nodes[3].Y + 2, true, this.BackColor));
                    break;
                case SpinType.Spin90:
                    nodes.Add(new Node(this.Nodes[0].X + 1, this.Nodes[0].Y + 1, true, this.BackColor));
                    nodes.Add(this.Nodes[1]);
                    nodes.Add(new Node(this.Nodes[2].X - 1, this.Nodes[2].Y + 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X - 2, this.Nodes[3].Y, true, this.BackColor));
                    break;
                case SpinType.Spin180:
                    nodes.Add(new Node(this.Nodes[0].X - 1, this.Nodes[0].Y + 1, true, this.BackColor));
                    nodes.Add(this.Nodes[1]);
                    nodes.Add(new Node(this.Nodes[2].X - 1, this.Nodes[2].Y - 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X, this.Nodes[3].Y - 2, true, this.BackColor));
                    break;
                case SpinType.Spin270:
                    nodes.Add(new Node(this.Nodes[0].X - 1, this.Nodes[0].Y - 1, true, this.BackColor));
                    nodes.Add(this.Nodes[1]);
                    nodes.Add(new Node(this.Nodes[2].X + 1, this.Nodes[2].Y + 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X + 2, this.Nodes[3].Y, true, this.BackColor));
                    break;
            }
            return nodes;
        }

        public List<Node> FindReverseZTypeCubeAvaildSpinRect()
        {
            List<Node> nodes = new List<Node>();
            switch (this.Spin)
            {
                case SpinType.Spin0:
                    nodes.Add(new Node(this.Nodes[0].X + 1, this.Nodes[0].Y - 1, true, this.BackColor));
                    nodes.Add(this.Nodes[1]);
                    nodes.Add(new Node(this.Nodes[2].X - 1, this.Nodes[2].Y - 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X - 2, this.Nodes[3].Y, true, this.BackColor));
                    break;
                case SpinType.Spin90:
                    nodes.Add(new Node(this.Nodes[0].X + 1, this.Nodes[0].Y + 1, true, this.BackColor));
                    nodes.Add(this.Nodes[1]);
                    nodes.Add(new Node(this.Nodes[2].X + 1, this.Nodes[2].Y - 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X, this.Nodes[3].Y - 2, true, this.BackColor));
                    break;
                case SpinType.Spin180:
                    nodes.Add(new Node(this.Nodes[0].X - 1, this.Nodes[0].Y + 1, true, this.BackColor));
                    nodes.Add(this.Nodes[1]);
                    nodes.Add(new Node(this.Nodes[2].X + 1, this.Nodes[2].Y + 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X + 2, this.Nodes[3].Y, true, this.BackColor));
                    break;
                case SpinType.Spin270:
                    nodes.Add(new Node(this.Nodes[0].X - 1, this.Nodes[0].Y - 1, true, this.BackColor));
                    nodes.Add(this.Nodes[1]);
                    nodes.Add(new Node(this.Nodes[2].X - 1, this.Nodes[2].Y + 1, true, this.BackColor));
                    nodes.Add(new Node(this.Nodes[3].X, this.Nodes[3].Y + 2, true, this.BackColor));
                    break;
            }
            return nodes;
        }

        /// <summary>
        /// 获取方块移动方向接触的点
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public List<Node> GetCubeMoveNodeList(Direction direction)
        {
            List<Node> nodes = new List<Node>();
            switch (direction)
            {
                case Direction.Down:
                    nodes = GetDownCheckNodes();
                    break;
                case Direction.Left:
                    nodes = GetLeftCheckNodes();
                    break;
                case Direction.Right:
                    nodes = GetRightCheckNodes();
                    break;
            }
            return nodes;
        }

        private List<Node> GetDownCheckNodes()
        {
            List<Node> nodes = new List<Node>();
            switch (this.CubeType)
            {
                case CubeType.Cube:
                    nodes.Add(this.Nodes[0]);
                    nodes.Add(this.Nodes[2]);
                    break;
                case CubeType.Line:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[0]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[0]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                    }
                    break;
                case CubeType.Corner:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[3]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[3]);
                            nodes.Add(this.Nodes[2]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            break;
                    }
                    break;
                case CubeType.Triangle:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[3]);
                            break;
                    }
                    break;
                case CubeType.ReverseCorner:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                    }
                    break;
                case CubeType.ZType:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            break;
                    }
                    break;
                case CubeType.ReverseZType:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            break;
                    }
                    break;
            }
            return nodes;
        }

        private List<Node> GetLeftCheckNodes()
        {
            List<Node> nodes = new List<Node>();
            switch (this.CubeType)
            {
                case CubeType.Cube:
                    nodes.Add(this.Nodes[0]);
                    nodes.Add(this.Nodes[1]);
                    break;
                case CubeType.Line:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[0]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[3]);
                            break;
                    }
                    break;
                case CubeType.Corner:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                    }
                    break;
                case CubeType.Triangle:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                    }
                    break;
                case CubeType.ReverseCorner:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                    }
                    break;
                case CubeType.ZType:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                    }
                    break;
                case CubeType.ReverseZType:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[3]);
                            break;
                    }
                    break;
            }
            return nodes;
        }

        private List<Node> GetRightCheckNodes()
        {
            List<Node> nodes = new List<Node>();
            switch (this.CubeType)
            {
                case CubeType.Cube:
                    nodes.Add(this.Nodes[2]);
                    nodes.Add(this.Nodes[3]);
                    break;
                case CubeType.Line:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[0]);
                            break;
                    }

                    break;
                case CubeType.Corner:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[3]);
                            break;
                    }
                    break;
                case CubeType.Triangle:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            break;
                    }
                    break;
                case CubeType.ReverseCorner:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[3]);
                            break;
                    }
                    break;
                case CubeType.ZType:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[3]);
                            break;
                    }
                    break;
                case CubeType.ReverseZType:
                    switch (this.Spin)
                    {
                        case SpinType.Spin0:
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin90:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[1]);
                            nodes.Add(this.Nodes[3]);
                            break;
                        case SpinType.Spin180:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            break;
                        case SpinType.Spin270:
                            nodes.Add(this.Nodes[0]);
                            nodes.Add(this.Nodes[2]);
                            nodes.Add(this.Nodes[3]);
                            break;
                    }
                    break;
            }
            return nodes;
        }
        private void Init()
        {
            switch (_cubeType)
            {
                case CubeType.Cube:
                    _nodes = new List<Node>() { new Node(7, 0, true, _backColor), new Node(7, -1, true, _backColor), new Node(8, 0, true, _backColor), new Node(8, -1, true, _backColor) };
                    break;
                case CubeType.Line:
                    _nodes = new List<Node>() { new Node(7, 0, true, _backColor), new Node(7, -1, true, _backColor), new Node(7, -2, true, _backColor), new Node(7, -3, true, _backColor) };
                    break;
                case CubeType.Corner:
                    _nodes = new List<Node>() { new Node(7, 0, true, _backColor), new Node(7, -1, true, _backColor), new Node(7, -2, true, _backColor), new Node(8, 0, true, _backColor) };
                    break;
                case CubeType.Triangle:
                    _nodes = new List<Node>() { new Node(6, 0, true, _backColor), new Node(7, 0, true, _backColor), new Node(8, 0, true, _backColor), new Node(7, -1, true, _backColor) };
                    break;
                case CubeType.ReverseCorner:
                    _nodes = new List<Node>() { new Node(8, 0, true, _backColor), new Node(8, -1, true, _backColor), new Node(8, -2, true, _backColor), new Node(7, 0, true, _backColor) };
                    break;
                case CubeType.ZType:
                    _nodes = new List<Node>() { new Node(6, 0, true, _backColor), new Node(7, 0, true, _backColor), new Node(7, -1, true, _backColor), new Node(8, -1, true, _backColor) };
                    break;
                case CubeType.ReverseZType:
                    _nodes = new List<Node>() { new Node(6, -1, true, _backColor), new Node(7, -1, true, _backColor), new Node(7, 0, true, _backColor), new Node(8, 0, true, _backColor) };
                    break;
            }
        }
    }
}
