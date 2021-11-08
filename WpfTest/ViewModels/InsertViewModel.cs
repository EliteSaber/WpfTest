using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTest.Interfaces;
using WpfTest.Models;
using WpfTest.ViewModels.Base;

namespace WpfTest.ViewModels
{
    class InsertViewModel : ViewModel
    {
        private IRepository<Table> _repository;
        public InsertViewModel(IRepository<Table> repository)
        {
            _repository = repository;
        }
    }
}
