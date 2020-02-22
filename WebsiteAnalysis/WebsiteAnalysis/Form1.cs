using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net.Http;

namespace WebsiteAnalysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Main Start button Click Behavior
        {
            //System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);//Temp example code
            //System.Drawing.Graphics formGraphics;////////////////////////////////////
            //formGraphics = this.CreateGraphics();
            //formGraphics.FillEllipse(myBrush, new Rectangle(0, 0, 200, 300));
            //myBrush.Dispose();
            //formGraphics.Dispose();
            // Populates a TreeView control with example nodes. 
            treeView1.Visible = true;
            treeView1.BringToFront();
            treeView1.CreateGraphics();
                treeView1.BeginUpdate();
                treeView1.Nodes.Add("Parent");
                treeView1.Nodes[0].Nodes.Add("Child 1");
                treeView1.Nodes[0].Nodes.Add("Child 2");
                treeView1.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
                treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
                treeView1.EndUpdate();
            treeView1.ExpandAll();
            treeView1.Show();
            URLNode test = new URLNode("http://wsu.edu");
            test.AddParsedAsync();

        }
        public void setText(string textbox)
        {
            this.textBox1.Text = textbox;
        }
    }

    public class URLNode : TreeNode// class to store data of website links
    {
        public string URL;//this url MUST INCLUDE HTTP//:

        public URLNode(string initializedURL)//create tree with URL declared
        {
            URL = initializedURL;
        }

        public async void AddParsedAsync()//get data from website about links
        {
            HttpClient parsingHttp = new HttpClient();
            parsingHttp.BaseAddress = new Uri(this.URL);
            string domainURL = this.domainFinder();
            string currentPage = await parsingHttp.GetStringAsync(URL);
            ((Form1)Form1.ActiveForm).setText(currentPage);
            //////////////////
            ///
            //LOOP THROUGH ALL LINKS
            //HtmlAgilityPack
        }

        private string domainFinder()
        {
            StringBuilder domainURL = new StringBuilder();
            int i = 0;
            for (int colons = 0, slashs = 0; i < this.URL.Length; i++)
            {
                if (this.URL.ElementAt(i) == '/')
                {
                    slashs++;
                }
                else if (this.URL.ElementAt(i) == ':')
                {
                    colons++;
                }
                if (slashs == 3)
                {
                    break;
                }
            }
            domainURL.Append(this.URL, 0, i);
            return domainURL.ToString();
        }

        public URLTree URLTree { get { return (URLTree)this.TreeView; } }

    }

    public class URLTree : TreeView
    {

        URLTree(string rootURL)
        {
            this.TopNode = new URLNode(rootURL);//////////////////////////
        }

        public URLNode TopURLNode { get { return (URLNode)this.TopNode; } }

        private void FillMyTreeView()
        {
            ((URLNode)this.TopNode).AddParsedAsync();
            //Filled With Example Code

            //// Add customers to the ArrayList of Customer objects.
            //this.Nodes.Add(URLNode);
            //for (int x = 0; x < 1000; x++)
            //{
            //    tempURLNode.Add(new Customer("Customer" + x.ToString()));
            //}

            //// Add orders to each Customer object in the ArrayList.
            //foreach (Customer customer1 in tempURLNode)
            //{
            //    for (int y = 0; y < 15; y++)
            //    {
            //        customer1.CustomerOrders.Add(new Order("Order" + y.ToString()));
            //    }
            //}

            //// Display a wait cursor while the TreeNodes are being created.
            //Cursor.Current = new Cursor("MyWait.cur");

            //// Suppress repainting the TreeView until all the objects have been created.
            //treeView1.BeginUpdate();

            //// Clear the TreeView each time the method is called.
            //treeView1.Nodes.Clear();

            //// Add a root TreeNode for each Customer object in the ArrayList.
            //foreach (Customer customer2 in tempURLNode)
            //{
            //    treeView1.Nodes.Add(new TreeNode(customer2.CustomerName));

            //    // Add a child treenode for each Order object in the current Customer object.
            //    foreach (Order order1 in customer2.CustomerOrders)
            //    {
            //        treeView1.Nodes[tempURLNode.IndexOf(customer2)].Nodes.Add(
            //          new TreeNode(customer2.CustomerName + "." + order1.OrderID));
            //    }
            //}

            //// Reset the cursor to the default for all controls.
            //Cursor.Current = Cursors.Default;

            //// Begin repainting the TreeView.
            //treeView1.EndUpdate();
        }
    }

    // Create a new ArrayList to hold the Customer objects.
    //private ArrayList tempURLNode = new ArrayList(); 




}
