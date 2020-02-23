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
                string message = "You did not enter a valid url. (do not include http://)";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.OK)
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

        private void treeView1_AfterSelect(object sender, MouseEventArgs e)//clickable links
        {
            foreach (TreeNode node in this.treeView1.Nodes)
            {
                if (containsHelper(node, e.Location) != null)
                {
                    HtmlWeb tempWeb = new HtmlWeb();
                    HtmlAgilityPack.HtmlDocument tempDoc = new HtmlAgilityPack.HtmlDocument();
                    try
                    {
                        tempDoc = tempWeb.Load(((URLNode)node).URL);
                    }
                    catch
                    {
                        return;
                    }
                    System.Diagnostics.Process.Start(((URLNode)containsHelper(node, e.Location)).URL);
                    break;
                }
            }
        }

        TreeNode containsHelper(TreeNode node, Point click)
        {
            TreeNode temp = null;
            if (node.Bounds.Contains(click))
            {
                return node;
            }
            else
            {
                foreach (TreeNode singleNode in node.Nodes)
                {
                    if (containsHelper(singleNode, click) != null)
                    {
                        return containsHelper(singleNode, click);
                    }
                }
            }
            return temp;
        }

        private void shortestPathButton_Click(object sender, EventArgs e)//update subdomain check
        {
            string sourceURL = "http://" + domainTextBox.Text, destinationURL = "http://" + destinationTextBox.Text;
            HtmlAgilityPack.HtmlDocument temp = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb temp1 = new HtmlWeb();
            try
            {
                temp = temp1.Load(destinationURL);
            }
            catch
            {
                string message = "You did not enter a valid destination url. (do not include http://)";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.OK)
                {

                }
                return;
            }
            try
            {
                temp = temp1.Load(sourceURL);
            }
            catch
            {
                string message = "You did not enter a valid source url. (do not include http://)";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.OK)
                {

                }
                return;
            }
            if (this.treeView1.searchSubDomains && !domainTextBox.Text.Contains(destinationTextBox.Text) && !domainTextBox.Text.Contains(destinationTextBox.Text))
            {

                string message = "Your Inputs are not in the same domain.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.OK)
                {

                }
                return;

            }
            if (!this.treeView1.searchSubDomains && domainTextBox.Text.Split(new string[] { "/" }, StringSplitOptions.None)[0] != destinationTextBox.Text.Split(new string[] { "/" }, StringSplitOptions.None)[0])

            {

                string message = "Your Inputs are not in the same subdomain. (try enabling multiple subdomains)";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.OK)
                {

                }
                return;

            }

            treeView1.UseWaitCursor = true;
            treeView1.Show();

            treeView1.BeginUpdate();
            treeView1.setURLTreeRoot(sourceURL);
            treeView1.FillMyTree();
            removeNonContainingPathHelper(destinationURL, (URLNode)(this.treeView1.TopNode));
            if (treeView1.Nodes.Count == 0 || treeView1.Nodes[0].Nodes.Count == 0)
            {
                treeView1.Nodes.Add("No Valid Path");
            }
            treeView1.EndUpdate();
            treeView1.UseWaitCursor = false;
            treeView1.ExpandAll();
            treeView1.Show();
        }

        bool removeNonContainingPath(string nodeURL, URLNode node)
        {
            List<bool> markForDelete = new List<bool>();
            bool parentDelete = true;
            if (node.URL == nodeURL)
            {
                return false;
            }
            else
            {
                foreach (TreeNode singleNode in node.Nodes)
                {
                    if (removeNonContainingPath(nodeURL, (URLNode)singleNode) == false)
                    {
                        parentDelete = false;
                        markForDelete.Add( false);
                    }
                    else
                    {
                        markForDelete.Add(true);
                    }
                }
            }
            for (int i = markForDelete.Count - 1; i > -1; i--)
            {
                if (markForDelete.ElementAt(i))
                {
                    node.Nodes.RemoveAt(i);
                    ((URLTree)treeView1).currentNodes--;
                }
            }
            return parentDelete;
        }

        void removeNonContainingPathHelper(string nodeURL, URLNode node)
        {
            List<bool> markForDelete = new List<bool>();
            foreach (TreeNode singleNode in node.Nodes)
            {
                if (removeNonContainingPath(nodeURL, (URLNode)singleNode))
                {
                    markForDelete.Add(true);
                }
                else
                {
                    markForDelete.Add(false);
                }
            }
            for(int i = markForDelete.Count - 1; i > -1; i--)
            {
                if (markForDelete.ElementAt(i))
                {
                    node.Nodes.RemoveAt(i);
                    ((URLTree)treeView1).currentNodes--;
                }
            }
        }
        
        private void searchSubDomainsToolStripMenuItem_Click(object sender, EventArgs e)//update subdomain check
        {
            this.treeView1.searchSubDomains = this.searchSubDomainsToolStripMenuItem.Checked;
        }

        private void ampToolStripMenuItem_Click(object sender, EventArgs e)//update deliminate on ampersand
        {
            this.treeView1.ampersandDeliminated = this.ampersandToolStripMenuItem.Checked;
        }

        private void linearText_Leave(object sender, EventArgs e)//update linear nodes until highlight
        {
            int temp = 0;
            if (int.TryParse(this.clicksLinearText.ToString(), out temp) || this.clicksLinearText.Text == "")
            {
                treeView1.highlightLinearCount = temp;
            }
            else
            {
                string message = "You did not enter a valid int.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.OK)
                {

                }
                return;
            }

        }

        private void clicksFromRootText_Leave(object sender, EventArgs e)//update linear nodes until highlight
        {
            int temp = 0;
            if (int.TryParse(this.clicksLinearText.ToString(), out temp))
            {
                treeView1.highlightFromRootCount = temp;
            }
            else
            {
                string message = "You did not enter a valid int.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.OK)
                {

                }
                return;
            }

        }

        private void setMaxNodesText_Leave(object sender, EventArgs e)//update linear nodes until highlight
        {
            int temp = 0;
            if (int.TryParse(this.clicksLinearText.ToString(), out temp))
            {
                treeView1.maxNodes = temp;
            }
            else
            {
                string message = "You did not enter a valid int.";
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.OK)
                {

                }
                return;
            }

        }

        private void equalsToolStripMenuItem_Click(object sender, EventArgs e)//update Eauqls
        {
            this.treeView1.equalsDeliminated = this.equalsToolStripMenuItem.Checked;
        }

        private void questionMarkToolStripMenuItem_Click(object sender, EventArgs e)//update Question
        {
            this.treeView1.questionDeliminated = this.questionMarkStripMenuItem.Checked;
        }

        private void afterLinearForToolStripMenuItem_Click(object sender, EventArgs e)//update if linear items are highlighted
        {
            this.treeView1.highlightLinear = this.afterLinearForToolStripMenuItem.Checked;
        }

        private void afterXClicksFromRootToolStripMenuItem_Click(object sender, EventArgs e)//update if linear items are highlighted
        {
            this.treeView1.highlightFromRoot = this.afterXClicksFromRootToolStripMenuItem.Checked;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)//domain txt change
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
                    if (((URLTree)this.TreeView).currentNodes < ((URLTree)this.TreeView).maxNodes)
                    {
                        this.TreeView.BeginUpdate();
                        //URLNode tempNode = new URLNode(link);
                        this.Nodes.Add(new URLNode(link));

                        bool highlightfromroot = ((URLTree)this.TreeView).highlightFromRoot;
                        try
                        {
                            URLNode tempNode = this;
                            for (int i = 0; i < ((URLTree)this.TreeView).highlightFromRootCount; i++)
                            {
                                if (tempNode == null)
                                {
                                    highlightfromroot = false;
                                    break;
                                }
                                tempNode = (URLNode)tempNode.Parent;
                            }
                        }
                        catch
                        {
                            highlightfromroot = false;
                        }

                        if (highlightfromroot)
                        {
                            this.Nodes[this.Nodes.Count - 1].BackColor = Color.DarkRed;
                        }

                        bool highlight = ((URLTree)this.TreeView).highlightLinear;
                        try
                        {
                            URLNode tempNode = this;
                            for (int i = 0; i < ((URLTree)this.TreeView).highlightLinearCount; i++)
                            {
                                if (tempNode == null || tempNode.Nodes.Count != 1)
                                {
                                    highlight = false;
                                    break;
                                }
                                tempNode = (URLNode)tempNode.Parent;
                            }
                        }
                        catch
                        {
                            highlight = false;
                        }

                        if (highlight)
                        {
                            this.Nodes[this.Nodes.Count - 1].BackColor = Color.Crimson;
                        }

                        Console.WriteLine("inserting [" + ((URLNode)this.LastNode).URL + "]");
                        this.TreeView.EndUpdate();
                        this.TreeView.Show();
                        ((URLTree)this.TreeView).currentNodes++;
                    }
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
            string[] delim = { "hhtp://", "https://"};////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////Make Dynamic to search for subdomains
            //if (((URLTree)this.TreeView).domainURL.ToLower().StartsWith("https"))
            //{
            //    delim = new string[] { ((URLTree)this.TreeView).domainURL.ToLower(), ((URLTree)this.TreeView).domainURL.ToLower().Remove(4,1) };//make dynamic
            //}
            //else
            //{
            //    delim = new string[] { ((URLTree)this.TreeView).domainURL.ToLower(), ((URLTree)this.TreeView).domainURL.ToLower().Insert(4, "s") };//make dynamic
            //}
            processingSplitter = htmlRaw.Split(delim, StringSplitOptions.RemoveEmptyEntries).ToList();
            processingSplitter.RemoveAt(0);//remove all found before the first delim

            List<string> endDelims = new List<string>();
            endDelims.Add("\"");
            endDelims.Add("\'");
            endDelims.Add(" ");
            if (((URLTree)(this.TreeView)).ampersandDeliminated)
            {
                endDelims.Add("&");
            }
            if (((URLTree)(this.TreeView)).equalsDeliminated)
            {
                endDelims.Add("=");
            }
            if (((URLTree)(this.TreeView)).questionDeliminated)
            {
                endDelims.Add("?");
            }


            bool rootisSub = false;
            string mainDomain = ((URLTree)this.TreeView).domainURL.ToLower().Split(new String[] { "http://" }, StringSplitOptions.RemoveEmptyEntries).Last();

            if ((((URLTree)this.TreeView).domainURL.ToLower().Split('.').Count()) >= 3 && ((URLTree)(this.TreeView)).searchSubDomains)
            {
                rootisSub = true;
                mainDomain = (((URLTree)this.TreeView).domainURL.ToLower().Split('.'))[((URLTree)this.TreeView).domainURL.ToLower().Split('.').Count() - 2] + "." + (((URLTree)this.TreeView).domainURL.ToLower().Split('.'))[((URLTree)this.TreeView).domainURL.ToLower().Split('.').Count() - 1];
            }

            foreach (string line in processingSplitter)
            {
                string temp = line.Split(endDelims.ToArray(), StringSplitOptions.RemoveEmptyEntries)[0];//temp is everything included in the link until delim
                temp = temp.TrimEnd(new char[] { '/', '\\' });//trim end
                if (((((URLTree)(this.TreeView)).searchSubDomains == false && temp.StartsWith(mainDomain)) || ((URLTree)(this.TreeView)).searchSubDomains == true && temp.Contains(mainDomain)) && !temp.Split(new string[] { mainDomain }, StringSplitOptions.None).Last().Contains(".") && !temp.Contains("json"))
                {
                    validSplitter.Add("http://" + temp);//add format back to the front
                }
            }


            //foreach (string line in processingSplitter)
            //{
            //    string temp = line.Split(endDelims.ToArray(), StringSplitOptions.RemoveEmptyEntries)[0];//temp is everything included in the link until delim
            //    bool rootisSub = false;
            //    string mainDomain = ((URLTree)this.TreeView).domainURL.ToLower();

            //    if (((URLTree)(this.TreeView)).searchSubDomains)
            //    {
            //        if ((((URLTree)this.TreeView).domainURL.ToLower().Split('.').Count()) >= 3){
            //            rootisSub = true;
            //            mainDomain = (((URLTree)this.TreeView).domainURL.ToLower().Split('.'))[((URLTree)this.TreeView).domainURL.ToLower().Split('.').Count() - 2] +"."+ (((URLTree)this.TreeView).domainURL.ToLower().Split('.'))[((URLTree)this.TreeView).domainURL.ToLower().Split('.').Count()-1];
            //        }
            //        if ((temp.Split(new string[] { "http://", "https://" }, StringSplitOptions.RemoveEmptyEntries)[0].Contains(delim[0]) || temp.Split(new string[] { "http://", "https://" }, StringSplitOptions.RemoveEmptyEntries)[0].Contains(delim[1])))
            //        {

            //        }
            //    }

            //    if (!temp.Contains(".") && !temp.Contains("json"))//if there is not a file extension at the end of the file or format tag
            //    {
            //        validSplitter.Add(((URLTree)this.TreeView).domainURL + temp);//add the domain back to the front
            //    }
            //}

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
        public bool ampersandDeliminated = true, equalsDeliminated = true, questionDeliminated = true, highlightLinear = false, highlightFromRoot = false, searchSubDomains = false;
        public int highlightLinearCount = 3, highlightFromRootCount = 5, maxNodes = 1000, currentNodes = 0;
        public void setURLTreeRoot(string rootURL)
        {
            while (this.Nodes.Count != 0)
            {
                this.Nodes.RemoveAt(this.Nodes.Count - 1);
                ((URLTree)this).currentNodes--;
            }
            URLNode temp = new URLNode(rootURL);
            this.Nodes.Add(temp);
            this.TopNode = (URLNode)(Nodes[0]);
            this.domainURL = ((URLNode)(this.TopNode)).domainFinder();
        }

        public bool URLExistsInTree(string queryURL)//return if the URL is found in the tree
        {
            return ((URLNode)this.TopNode).URLExistsInTreeHelper(queryURL);
        }

        public void FillMyTree()
        {
            ((URLNode)TopNode).AddParsedAsync();//recursively add nodes
        }
    }
}
