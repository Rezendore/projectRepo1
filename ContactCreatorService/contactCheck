using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using FileHelpers;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ContactCreatorService
{
    public partial class CreateContact : ServiceBase
    {
        public CreateContact()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            var engine = new FileHelperEngine<Contact>();

            var result = engine.ReadFile("contacts-processed.csv");

            engine.WriteFile("contacts.csv", result);
        }

        protected override void OnStop()
        {
        }
    }
}
