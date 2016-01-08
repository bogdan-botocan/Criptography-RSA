using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptography_RSA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnGenerateKeysPair_Click(object sender, EventArgs e)
        {
            Controller.GenerateKeyPair(2, 3);
            this.tbxPublicKey.Text = Controller.N.ToString();
            this.tbxPrivateKey.Text = Controller.Q.ToString();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            this.tbxCipherText.Text = Controller.Encrypt(this.tbxPlainText.Text);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            this.tbxPlainText = this.tbxPlainText;
        }
    }
}
