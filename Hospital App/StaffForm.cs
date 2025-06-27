using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hospital_App.ServiceNameSpace;

namespace Hospital_App
{
    public partial class StaffForm : Form
    {
        private Service service;

        public StaffForm(Service service)
        {
            this.service = service;

            InitializeComponent();
        }
    }
}
