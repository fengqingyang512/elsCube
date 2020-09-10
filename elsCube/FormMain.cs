using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace elsCube
{
    public partial class Form_Main : Form
    {
        //private Dictionary<Node, Button> _map = new Dictionary<Node, Button>();
        //private Dictionary<Node, Button> _showMap = new Dictionary<Node, Button>();
        private List<List<Node>> _mapNodes = new List<List<Node>>();
        private List<List<Node>> _showPanelNodes = new List<List<Node>>();
        Graphics panel_show_graphics;
        Graphics panel_map_graphics;
        Brush _borderBrush;
        Brush noCubeBrush = new SolidBrush(Color.Black);
        Pen _borderPen;
        Dictionary<Color, Brush> _cubeBrushDic = new Dictionary<Color, Brush>() { { Color.Red, new SolidBrush(Color.Red) }, { Color.Yellow, new SolidBrush(Color.Yellow) },
                                                                                { Color.DarkOrange, new SolidBrush(Color.DarkOrange) }, { Color.Blue, new SolidBrush(Color.Blue) },
                                                                                { Color.White, new SolidBrush(Color.White) }, { Color.Lime, new SolidBrush(Color.Lime) },
                                                                                { Color.Pink, new SolidBrush(Color.Pink) }, { Color.Black, new SolidBrush(Color.Black) } };
        private List<List<Node>> _historyCubeNodeList = new List<List<Node>>();

        private List<CubeType> _cubeTypes = new List<CubeType>() { CubeType.Cube, CubeType.Line, CubeType.Corner, CubeType.Triangle, CubeType.ReverseCorner, CubeType.ZType, CubeType.ReverseZType };
        private List<Color> _colors = new List<Color>() { Color.Red, Color.Yellow, Color.DarkOrange, Color.Blue, Color.White, Color.Pink, Color.Lime };
        private bool _bClose = false;
        private bool _bAccelerate = false;
        private Cube _curCube = null;
        private object _locker = new object();
        private bool _bPause = false;
        private Cube _nextCube = null;
        private int _score = 0;
        private static int MapHeight = 23;
        private static int MapWidth = 14;
        private static int ShowPanleHeight = 4;
        private static int ShowPanleWidth = 4;

        #region Delegate
        private delegate void ClearShowPanleCacheDel();
        private delegate void ShowNewCubeDel(List<Node> nodes, Color color);
        private delegate void RefreshMapShowDel();
        private delegate void ShowMessageDel(string msg);
        private delegate void RefreshScoreDel();
        private delegate void MoveDel();
        #endregion

        public Form_Main()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            _borderBrush = new SolidBrush(Color.Black);
            _borderPen = new Pen(_borderBrush);
            panel_show_graphics =  panel_show.CreateGraphics();
            panel_map_graphics = panel_game.CreateGraphics();
            InitMap();
        }

        private void InitMap()
        {
            panel_show_graphics.Clear(Color.Black);
            panel_map_graphics.Clear(Color.Black);
            for (int y = 0; y < MapHeight; y++)
            {
                List<Node> list = new List<Node>();
                for (int x = 0; x < MapWidth; x++)
                {
                    Node node = new Node(x, y, false, Color.Black);
                    list.Add(node);
                }
                _mapNodes.Add(list);
            }
            for (int k = 0; k < ShowPanleHeight; k++)
            {
                List<Node> list = new List<Node>();
                for (int l = 0; l < ShowPanleWidth; l++)
                {
                    Node node = new Node(l, k, false, Color.Black);
                    list.Add(node);
                }
                _showPanelNodes.Add(list);
            }
        }

        private Cube CreateCube()
        {
            Random random = new Random((int)DateTime.Now.Ticks);

            int randomIndex = random.Next(7);
            return new Cube(_cubeTypes[randomIndex], _colors[randomIndex]);
        }

        private void ShowNewCube(Cube cube)
        {
            ClearShowPanleCache();
            switch (cube.CubeType)
            {
                case CubeType.Cube:
                    ShowNewCube(new List<Node>() { new Node(1, 1, false, cube.BackColor), new Node(1, 2, false, cube.BackColor), new Node(2, 1, false, cube.BackColor), new Node(2, 2, false, cube.BackColor) }, cube.BackColor);
                    break;
                case CubeType.Line:
                    ShowNewCube(new List<Node>() { new Node(1, 0, false, cube.BackColor), new Node(1, 1, false, cube.BackColor), new Node(1, 2, false, cube.BackColor), new Node(1, 3, false, cube.BackColor) }, cube.BackColor);
                    break;
                case CubeType.Corner:
                    ShowNewCube(new List<Node>() { new Node(1, 3, false, cube.BackColor), new Node(2, 3, false, cube.BackColor), new Node(1, 2, false, cube.BackColor), new Node(1, 1, false, cube.BackColor) }, cube.BackColor);
                    break;
                case CubeType.Triangle:
                    ShowNewCube(new List<Node>() { new Node(1, 3, false, cube.BackColor), new Node(2, 3, false, cube.BackColor), new Node(3, 3, false, cube.BackColor), new Node(2, 2, false, cube.BackColor) }, cube.BackColor);
                    break;
                case CubeType.ReverseCorner:
                    ShowNewCube(new List<Node>() { new Node(1, 3, false, cube.BackColor), new Node(2, 3, false, cube.BackColor), new Node(2, 2, false, cube.BackColor), new Node(2, 1, false, cube.BackColor) }, cube.BackColor);
                    break;
                case CubeType.ZType:
                    ShowNewCube(new List<Node>() { new Node(1, 2, false, cube.BackColor), new Node(2, 2, false, cube.BackColor), new Node(2, 1, false, cube.BackColor), new Node(3, 1, false, cube.BackColor) }, cube.BackColor);
                    break;
                case CubeType.ReverseZType:
                    ShowNewCube(new List<Node>() { new Node(1, 1, false, cube.BackColor), new Node(2, 1, false, cube.BackColor), new Node(2, 2, false, cube.BackColor), new Node(3, 2, false, cube.BackColor) }, cube.BackColor);
                    break;
            }
        }

        private void ClearShowPanleCache()
        {
            if (!this.InvokeRequired)
            {
                //panel_show.BackColor = Color.Black;
                panel_show_graphics.Clear(Color.Black);
            }
            else
            {
                ClearShowPanleCacheDel clearShowPanleCacheDel = new ClearShowPanleCacheDel(ClearShowPanleCache);
                this.Invoke(clearShowPanleCacheDel);
            }
        }

        private void ShowNewCube(List<Node> nodes, Color color)
        {
            if (!this.InvokeRequired)
            {
                Brush cubeBrush = new SolidBrush(color);
                Brush borderBrush = new SolidBrush(Color.Black);
                Pen borderPen = new Pen(borderBrush);
                foreach (var node in nodes)
                {
                    panel_show_graphics.FillRectangle(cubeBrush, new Rectangle(new Point(node.X * 30, node.Y * 30), new Size(30, 30)));
                    panel_show_graphics.DrawRectangle(borderPen, new Rectangle(new Point(node.X * 30, node.Y * 30), new Size(30, 30)));
                }
                cubeBrush.Dispose();
                borderBrush.Dispose();
                borderPen.Dispose();
            }
            else
            {
                ShowNewCubeDel showNewCubeDel = new ShowNewCubeDel(ShowNewCube);
                this.Invoke(showNewCubeDel, new object[] { nodes, color });
            }
        }

        private bool CheckCubeCanMove(Cube cube, Direction direction)
        {
            bool res = true;
            List<Node> nodes = new List<Node>();
            switch (direction)
            {
                case Direction.Down:
                    nodes = cube.GetCubeMoveNodeList(Direction.Down);
                    foreach (var node in nodes)
                    {
                        Node newNode = GetNodeInMap(node.X, node.Y + 1);
                        if (newNode == null)
                        {
                            res = false;
                        }
                        else if (newNode.BOccupy == true)
                        {
                            res = false;
                        }

                    }
                    break;
                case Direction.Left:
                    nodes = cube.GetCubeMoveNodeList(Direction.Left);
                    foreach (var node in nodes)
                    {
                        Node newNode = GetNodeInMap(node.X - 1, node.Y);
                        if (newNode == null)
                        {
                            res = false;
                        }
                        else if (newNode.BOccupy == true)
                        {
                            res = false;
                        }
                    }
                    break;
                case Direction.Right:
                    nodes = cube.GetCubeMoveNodeList(Direction.Right);
                    foreach (var node in nodes)
                    {
                        Node newNode = GetNodeInMap(node.X + 1, node.Y);
                        if (newNode == null)
                        {
                            res = false;
                        }
                        else if (newNode.BOccupy == true)
                        {
                            res = false;
                        }
                    }
                    break;
            }

            return res;
        }

        private void Spin()
        {
            if (_bPause)
            {
                return;
            }
            List<Node> availdNodeList = _curCube.FindAvaildSpinRect();
            foreach (var node in availdNodeList)
            {
                if (GetNodeInMap(node.X, node.Y) == null)
                {
                    return;
                }
            }
            switch (_curCube.Spin)
            {
                case SpinType.Spin0:
                    _curCube.Spin = SpinType.Spin90;
                    break;
                case SpinType.Spin90:
                    _curCube.Spin = SpinType.Spin180;
                    break;
                case SpinType.Spin180:
                    _curCube.Spin = SpinType.Spin270;
                    break;
                case SpinType.Spin270:
                    _curCube.Spin = SpinType.Spin0;
                    break;
            }
            List<Node> diffNodes = CommonHelper.CompareToFindNodeList(_curCube.Nodes, availdNodeList);
            _historyCubeNodeList.Add(diffNodes);
            _curCube.Nodes = availdNodeList;
            CommonHelper.ResetNodeAttr(diffNodes);
            RefreshCubeInMapOccupy(_curCube.Nodes, diffNodes, _curCube.BackColor);
            RefreshMapShow();

        }

        private Node GetNodeInMap(int x, int y)
        {
            if (x < 0 || x > _mapNodes[0].Count - 1)
            {
                return null;
            }
            if (y < 0)
            {
                return new Node(x, y, false, Color.Black);
            }
            else if (y > _mapNodes.Count - 1)
            {
                return null;
            }
            return _mapNodes[y][x];
        }

        private void SetMapNodeStop(List<Node> nodes)
        {
            foreach (var node in nodes)
            {
                Node n = GetNodeInMap(node.X, node.Y);               
                n.BStop = true;
            }
        }

        private void RefreshCubeInMapOccupy(List<Node> nodes, List<Node> diffNodes, Color color)
        {
            ClearCache(diffNodes);
            foreach (var node in nodes)
            {
                Node n = GetNodeInMap(node.X, node.Y);
                if (n != null)
                {
                    n.BOccupy = true;
                    n.BackColor = color;
                }
            }
        }

        private void ClearCache(List<Node> diffNodes)
        {
            foreach(var node in diffNodes)
            {
                Node n = GetNodeInMap(node.X, node.Y);
                if (n != null)
                {
                    n.BOccupy = false;
                    n.BackColor = Color.Black;
                }
            }
        }

        private List<Node> GetAllOccpuyNode()
        {
            List<Node> nodes = new List<Node>();
            foreach (var list in _mapNodes)
            {
                foreach (var node in list)
                {
                    if (node.BOccupy)
                    {
                        nodes.Add(node);
                    }
                }
            }
         
            return nodes;
        }

        private List<Node> GetAllNoOccpuyNode()
        {
            List<Node> nodes = new List<Node>();
            foreach (var list in _historyCubeNodeList)
            {
                foreach (var node in list)
                {
                    if (!node.BOccupy)
                    {
                        nodes.Add(node);
                    }
                }
            }
            _historyCubeNodeList.Clear();
            return nodes;
        }

        private void RefreshMapShow()
        {
            if (!this.InvokeRequired)
            {
                List<Node> nodes = GetAllOccpuyNode();
                List<Node> noNodes = GetAllNoOccpuyNode();

                foreach (var node in nodes)
                {
                    panel_map_graphics.FillRectangle(_cubeBrushDic[node.BackColor], new Rectangle(new Point(node.X * 30, node.Y * 30), new Size(30, 30)));
                    panel_map_graphics.DrawRectangle(_borderPen, new Rectangle(new Point(node.X * 30, node.Y * 30), new Size(30, 30)));
                }
                foreach (var node in noNodes)
                {
                    panel_map_graphics.FillRectangle(noCubeBrush, new Rectangle(new Point(node.X * 30, node.Y * 30), new Size(30, 30)));
                }
                
            }
            else
            {
                RefreshMapShowDel refreshMapShowDel = new RefreshMapShowDel(RefreshMapShow);
                Invoke(refreshMapShowDel);
            }
        }

        private void ShowMessage(string msg)
        {
            if (!this.InvokeRequired)
            {
                MessageBox.Show(msg);
            }
            else
            {
                ShowMessageDel showMessageDel = new ShowMessageDel(ShowMessage);
                Invoke(showMessageDel, msg);
            }
        }

        private void CubeRun()
        {
            lock (_locker)
            {
                if (CheckCubeCanMove(_curCube, Direction.Down))
                {
                    List<Node> tempNodes = CommonHelper.DeepCloneNodeList(_curCube.Nodes);
                    _curCube.Down();
                    List<Node> diffNodes = CommonHelper.CompareToFindNodeList(tempNodes, _curCube.Nodes);
                    _historyCubeNodeList.Add(CommonHelper.ResetNodeAttr(diffNodes));
                    RefreshCubeInMapOccupy(_curCube.Nodes, diffNodes, _curCube.BackColor);
                    RefreshMapShow();
                }
                else
                {
                    _bAccelerate = false;
                    SetMapNodeStop(_curCube.Nodes);

                    CheckGameResult();

                    if (CheckGameIsOver())
                    {
                        ShowMessage("游戏结束，最终得分：" + _score.ToString());
                        Environment.Exit(0);
                    }
                    _curCube = _nextCube;
                    _nextCube = CreateCube();
                    ShowNewCube(_nextCube);
                }
            }
        }

        private bool CheckGameIsOver()
        {
            foreach (var v in _curCube.Nodes)
            {
                if (GetNodeInMap(v.X, v.Y).BackColor == Color.Black)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckGameResult()
        {
            bool complete = false;
            for (int i = _mapNodes.Count - 1; i >= 0; i--)
            {
                bool bComplete = true;
                foreach (var node in _mapNodes[i])
                {
                    if (!node.BStop)
                    {
                        bComplete = false;
                    }
                }
                if (bComplete)
                {
                    List<Node> nodes = new List<Node>();
                    for (int j = i - 1; j >= 0; j--)
                    {
                        for (int k = 0; k < _mapNodes[j].Count; k++)
                        {
                            if (_mapNodes[j][k].BStop)
                            {
                                _mapNodes[j][k].BStop = false;
                                _mapNodes[j][k].BOccupy = false;
                                _mapNodes[j + 1][k].BStop = true;
                                _mapNodes[j + 1][k].BOccupy = true;
                                _mapNodes[j + 1][k].BackColor = _mapNodes[j][k].BackColor;
                                nodes.Add(_mapNodes[j][k]);
                                
                            }
                            else
                            {
                                _mapNodes[j + 1][k].BStop = false;
                                _mapNodes[j + 1][k].BOccupy = false;
                                nodes.Add(_mapNodes[j + 1][k]);
                            }
                        }
                        _historyCubeNodeList.Add(nodes);
                    }
                    complete = true;
                }
            }
            if (complete)
            {
                _score += 10;
                RefreshScore();
                RefreshMapShow();
                CheckGameResult();
            }
            return complete;
        }

        private void RefreshScore()
        {
            if (!this.InvokeRequired)
            {
                label_score.Text = _score.ToString();
            }
            else
            {
                RefreshScoreDel refreshScoreDel = new RefreshScoreDel(RefreshScore);
                Invoke(refreshScoreDel);

            }
        }

        private void RefreshCubeLocation()
        {

        }

        private void ThreadPro(object obj)
        {
            int count = 0;

            while (!_bClose)
            {
                while (_bPause)
                {
                    Thread.Sleep(10);
                }
                int interval;
                if (_bAccelerate)
                {
                    interval = 5;
                }
                else
                {
                    interval = 20 + 50 - _score / 100;
                }
                if (count++ > interval)
                {
                    count = 0;
                    CubeRun();
                }
                Thread.Sleep(20);
            }
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bClose = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Down:
                    Down();
                    break;
                case Keys.Left:
                    Left();
                    break;
                case Keys.Right:
                    Right();
                    break;
                case Keys.Up:
                    Up();
                    break;
                case Keys.Space:
                    Spin();
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Left()
        {
            if (_bPause)
            {
                return;
            }
            if (!this.InvokeRequired)
            {
                button_left.Visible = false;
                Thread.Sleep(20);
                button_left.Visible = true;
                if (CheckCubeCanMove(_curCube, Direction.Left))
                {
                    List<Node> tempNodes = CommonHelper.DeepCloneNodeList(_curCube.Nodes);
                    _curCube?.Left();
                    List<Node> diffNodes = CommonHelper.CompareToFindNodeList(tempNodes, _curCube.Nodes);
                    _historyCubeNodeList.Add(CommonHelper.ResetNodeAttr(diffNodes));
                    RefreshCubeInMapOccupy(_curCube.Nodes, diffNodes, _curCube.BackColor);
                    RefreshMapShow();
                }

            }
            else
            {
                MoveDel leftDel = new MoveDel(Left);
                this.Invoke(leftDel);
            }

        }

        private void Right()
        {
            if (_bPause)
            {
                return;
            }

            if (!this.InvokeRequired)
            {
                button_right.Visible = false;
                Thread.Sleep(20);
                button_right.Visible = true;
                if (CheckCubeCanMove(_curCube, Direction.Right))
                {
                    List<Node> tempNodes = CommonHelper.DeepCloneNodeList(_curCube.Nodes);
                    _curCube?.Right();
                    List<Node> diffNodes = CommonHelper.CompareToFindNodeList(tempNodes, _curCube.Nodes);
                    _historyCubeNodeList.Add(CommonHelper.ResetNodeAttr(diffNodes));
                    RefreshCubeInMapOccupy(_curCube.Nodes, diffNodes, _curCube.BackColor);
                    RefreshMapShow();
                }
            }
            else
            {
                MoveDel RightDel = new MoveDel(Right);
                this.Invoke(RightDel);
            }

        }

        private void Down()
        {
            if (_bPause)
            {
                return;
            }
            if (!this.InvokeRequired)
            {
                button_down.Visible = false;
                Thread.Sleep(20);
                button_down.Visible = true;
                _bAccelerate = true;
            }
            else
            {
                MoveDel DownDel = new MoveDel(Down);
                this.Invoke(DownDel);
            }
        }

        private void Up()
        {
            if (!this.InvokeRequired)
            {
                button_up.Visible = false;
                Thread.Sleep(20);
                button_up.Visible = true;
                _bPause = !_bPause;
                if (_bPause)
                {
                    label_showPause.Text = "继续";
                }
                else
                {
                    label_showPause.Text = "暂停";
                }
            }
            else
            {
                MoveDel UpDel = new MoveDel(Up);
                this.Invoke(UpDel);
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        private void ToolStripMenuItem_start_Click(object sender, EventArgs e)
        {
            _curCube = CreateCube();
            _nextCube = CreateCube();
            ShowNewCube(_nextCube);

            ThreadPool.QueueUserWorkItem(ThreadPro);
        }
    }
}
