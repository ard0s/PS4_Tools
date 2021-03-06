﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    public partial class GridWithDisplay : Form
    {
        List<PS4_Tools.PKG.Official.StoreItems> Items = new List<PS4_Tools.PKG.Official.StoreItems>();
        public GridWithDisplay(List<PS4_Tools.PKG.Official.StoreItems> items)
        {
            InitializeComponent();
            Items = items;
        }

        private void GridWithDisplay_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Items;
        }

        public static System.Drawing.Bitmap BytesToBitmap(byte[] ImgBytes)
        {
            System.Drawing.Bitmap result = null;
            if (ImgBytes != null)
            {
                MemoryStream stream = new MemoryStream(ImgBytes);
                result = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromStream(stream);
            }
            return result;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void downloadDLCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Download DLC*/
            var item = ((PS4_Tools.PKG.Official.StoreItems)dataGridView1.CurrentRow.DataBoundItem);
            PS4_Tools.PKG.SceneRelated.Create_DLC_FKPG(item.Store_URL, item.Store_Content_Title + ".pkg");
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
