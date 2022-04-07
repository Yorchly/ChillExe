using ChillExe.DAO;
using ChillExe.Logger;
using ChillExe.Models;
using ChillExe.Services;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChillExe
{
    public partial class Main : Form
    {
        public Main(ICustomLogger logger, IAppService xmlService)
        {
            InitializeComponent();
        }
    }
}
