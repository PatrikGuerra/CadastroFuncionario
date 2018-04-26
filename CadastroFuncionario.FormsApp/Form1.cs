using CadastroFuncionario.Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroFuncionario.FormsApp
{
    public partial class Form1 : Form
    {
        IFuncionarioApplicationService applicationService;

        public Form1(IFuncionarioApplicationService applicationService)
        {
            this.applicationService = applicationService;
            InitializeComponent();

            var a = applicationService.Get();
        }
    }
}
