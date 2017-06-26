using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer
{
    public partial class Form1 : Form
    {
        TestContext db;

        public Form1()
        {
            InitializeComponent();
            db = new TestContext();
            try
            {
            if (db.Database.Exists())
                db.Database.Delete();

            //db.Database.Initialize(true);
            bool b = db.Database.Exists();
            db.Database.CreateIfNotExists();
            }
            catch (Exception err)
            {

                throw;
            }
            //db.SaveChanges();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PaintUsers();


            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.testDataSet.Users);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet.Comments". При необходимости она может быть перемещена или удалена.
            this.commentsTableAdapter.Fill(this.testDataSet.Comments);
            //this.commentsTableAdapter.Fill(this.testDataSet.Comments);
        }

        private void PaintUsers()
        {
            /* treeView1.Nodes.Clear();
            List<User> list = db.Users.Where(x => x.ParentId == null).OrderBy(x => x.Name).ToList();
            foreach (var item in list)
            {
                treeView1.Nodes.Add(new TreeNode() { Text = item.Name, Tag = item, Name="id"+item.UserId.ToString() });
            }

            list = db.Users.Where(x => x.ParentId != null).OrderBy(x => x.Name).ToList();

            foreach (var item in list)
            {
                treeView1.Nodes.Insert()
                treeView1.Nodes.Add(new TreeNode() { ,Text = item.Name, Tag = item });
            }*/
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            db.Users.Add(new User() { Name = toolStripTextBox1.Text });
            this.usersTableAdapter.Fill(this.testDataSet.Users);

            //dataGridView1.Update();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            db.Comments.Add(new Comment() { Text = toolStripTextBox2.Text, User = db.Users.Where(x => x.UserId == (int)comboBox1.SelectedValue).FirstOrDefault() });
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
        }


        private void tvClients_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void tvClients_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        private void tvClients_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = tvClients.PointToClient(new Point(e.X, e.Y));

            tvClients.SelectedNode = tvClients.GetNodeAt(targetPoint);
        }

        private void tvClients_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = tvClients.PointToClient(new Point(e.X, e.Y));

            TreeNode targetNode = tvClients.GetNodeAt(targetPoint);

            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                }

                targetNode.Expand();
            }
        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            return ContainsNode(node1, node2.Parent);
        }

        private void tvClients_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //panel1.Visible = e.Node != null;
        }
    }
}


