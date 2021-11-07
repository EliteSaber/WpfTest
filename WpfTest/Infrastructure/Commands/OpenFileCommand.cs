using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTest.Infrastructure.Commands.Base;
using WpfTest.Interfaces;
using WpfTest.Models;

namespace WpfTest.Infrastructure.Commands
{
    internal class OpenFileCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            IDialogService dialog = new DefaultDialogService();
            List<string> text = new List<string>();
            if (dialog.OpenFileDialog())
            {
                IFileService txt = new TxtFileService();
                text = txt.Open(dialog.FilePath);
            }
            DataFromFile data = new DataFromFile(text);
            
            foreach (Table s in data.Full)
            {
                //textBlock.Text += s + "\n";
            }
            //textBlock.Text += "End";
        }
    }
}
