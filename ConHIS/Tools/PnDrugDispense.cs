using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConHIS.Tools
{
    public partial class PnDrugDispense : UserControl
    {
        public PnDrugDispense()
        {
            InitializeComponent();
        }

        public string lSeqNo
        {
            get { return lbSeqNo.Text; }
            set { lbSeqNo.Text = value; }
        }

        public string lDrugName
        {
            get { return lbDrugName.Text; }
            set { lbDrugName.Text = value; }
        }

        public string lInstructionDesc
        {
            get { return lbInstructionDesc.Text; }
            set { lbInstructionDesc.Text = value; }
        }

        public string lDrugLabel
        {
            get { return tbDrugLabel.Text; }
            set { tbDrugLabel.Text = value; }
        }

        public string lPriority
        {
            get { return lbPriority.Text; }
            set { lbPriority.Text = value; }
        }

        public Color PriorityColor
        {
            get { return lbPriority.ForeColor; }
            set { lbPriority.ForeColor = value; }
        }

        public Image lDrugImage
        {
            get { return pbDrug.Image; }
            set { pbDrug.Image = value; }
        }
    }
}
