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
using System.Net;
using System.Runtime.ExceptionServices;

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
            string testingURL = "http://" + domainTextBox.Text;

            HtmlAgilityPack.HtmlDocument temp = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb temp1 = new HtmlWeb();
            try
            {
                temp = temp1.Load(testingURL);
            }
            catch
            {
                string message = "You did not enter a valid name. Cancel this operation?";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    
                }
                return;
            }

            treeView1.UseWaitCursor = true;
            treeView1.Show();

            treeView1.BeginUpdate();
            treeView1.setURLTreeRoot(testingURL);
            treeView1.FillMyTree();
            treeView1.EndUpdate();
            treeView1.UseWaitCursor = false;
            treeView1.ExpandAll();
            treeView1.Show();


        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Determine by checking the Text property.  
            MessageBox.Show(e.Node.Text);
        }

        private void searchSubDomainsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void spaceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public class URLNode : TreeNode// class to store data of website links
    {
        public string URL;//this url MUST INCLUDE HTTP//:
        
        public URLNode(string initializedURL)//create tree with URL declared
        {
            URL = initializedURL;
            this.Name = URL;
            this.Text = URL;
            this.Tag = URL;
        }

        public void AddParsedAsync()//get data from website about links
        {
            HtmlAgilityPack.HtmlDocument temp = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb temp1 = new HtmlWeb();
            try
            {
                temp = temp1.Load(this.URL);
            }
            catch
            {
                return;
            }
            //System.Windows.Forms.HtmlDocument temp1 = new System.Windows.Forms.HtmlDocument();

            string currentPage = "";

            currentPage = temp.Text;
            if (currentPage == null)
            {
                return;
            }



            //test.AddParsedAsync();
            List<string> allLinksOnPage = this.parseForNewHyperLinks(currentPage.ToLower());
            foreach(string link in allLinksOnPage)
            {
                if (!((URLTree)this.TreeView).URLExistsInTree(link))//if the link dowsn't already exists in tree
                {
                    //this.TreeView.Visible = true;
                    //this.TreeView.BringToFront();
                    //this.TreeView.CreateGraphics();
                    this.TreeView.BeginUpdate();
                    URLNode tempNode = new URLNode(link);
                    this.Nodes.Add(tempNode);
                    Console.WriteLine("inserting [" + tempNode.URL + "]");
                    this.TreeView.EndUpdate();
                    this.TreeView.Show();

                }

            }
            currentPage = "";//prevent multiple pages being held in memory
            foreach (URLNode node in this.Nodes)
            {
                node.AddParsedAsync();
            }
            //Form1.setText(currentPage);
            //////////////////
            ///
            //LOOP THROUGH ALL LINKS
            //HtmlAgilityPack
        }

        public string domainFinder()
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

        private List<string> parseForNewHyperLinks(string htmlRaw)
        {
            if (htmlRaw == null || htmlRaw == "")
            {
                return new List<string>();
            }
            List<string> processingSplitter = new List<string>();
            List<string> validSplitter = new List<string>();
            string[] delim = { };////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Make Dynamic to search for subdomains
            if (((URLTree)this.TreeView).domainURL.ToLower().StartsWith("https"))
            {
                delim = new string[] { ((URLTree)this.TreeView).domainURL.ToLower(), ((URLTree)this.TreeView).domainURL.ToLower().Remove(4,1) };//make dynamic
            }
            else
            {
                delim = new string[] { ((URLTree)this.TreeView).domainURL.ToLower(), ((URLTree)this.TreeView).domainURL.ToLower().Insert(4, "s") };//make dynamic
            }
            processingSplitter = htmlRaw.Split(delim, StringSplitOptions.RemoveEmptyEntries).ToList();
            processingSplitter.RemoveAt(0);//remove all found before the first delim
            foreach (string line in processingSplitter)
            {
                string[] endDelims = { "\"", "\'", "&", " ", "=", "?"};/////////////////////////////////////////////////////////////////////////////////////Make Dynamic
                string temp = line.Split(endDelims, StringSplitOptions.RemoveEmptyEntries)[0];//temp is everything included in the link
                if (!temp.Contains(".") && !temp.Contains("json"))//if there is not a file extension at the end of the file or format tag
                {
                    validSplitter.Add(((URLTree)this.TreeView).domainURL + temp);//add the domain back to the front
                }
            }

            for (int i = 0; i < validSplitter.Count; i++)
            {
                while (validSplitter[i].ElementAt(validSplitter[i].Length - 1) == '\\' || validSplitter[i].ElementAt(validSplitter[i].Length - 1) == '/')// remove all terminationg slashes
                {
                    validSplitter[i] = validSplitter[i].Remove(validSplitter[i].Length - 1);
                }
                if (((URLTree)this.TreeView).URLExistsInTree(validSplitter[i]))//do not return already accepted links
                {
                    validSplitter.Remove(validSplitter[i]);
                    i--;
                }
            }

            //foreach (string line in validSplitter)
            //{
            //    while (line.ToCharArray().ElementAt(line.Length - 1).ToString() == "\\" || line.ToCharArray().ElementAt(line.Length - 1).ToString() == "/")// remove all terminationg slashes
            //    {
            //        line.Remove(line.Length - 2);
            //    }
            //}
            //foreach (string line in validSplitter)
            //{
            //    if (((URLTree)this.TreeView).URLExistsInTree(line))//if the link already exists in tree
            //    {
            //        validSplitter.Remove(line);
            //    }
            return validSplitter;
        }

        public bool URLExistsInTreeHelper(string queryURL)
        {
            bool exists = false;
            if (this.URL == queryURL)
            {
                return true;
            }
            foreach(TreeNode node in this.Nodes)
            {
                if(((URLNode)node).URLExistsInTreeHelper(queryURL) == true)
                {
                    exists = true;
                }
            }
            return exists;
        }

    }

    public class URLTree : TreeView
    {
        public string domainURL;//only initialized if constructed with overload

        public void setURLTreeRoot(string rootURL)
        {
            if (this.Nodes.Count == 0)
            {
                this.Nodes.Add((new URLNode(rootURL)));
            }
            else
            {
                this.Nodes.RemoveAt(0);
                                this.Nodes.Add((new URLNode(rootURL)));
            }
            this.TopNode = Nodes[0];
            this.domainURL = ((URLNode)this.TopNode).domainFinder();
        }

        public bool URLExistsInTree(string queryURL)
        {
            return ((URLNode)this.TopNode).URLExistsInTreeHelper(queryURL);
        }

        public void FillMyTree()
        {
            ((URLNode)TopNode).AddParsedAsync();
            //Filled With Example Code

        }
    }




}
