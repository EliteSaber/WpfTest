using System.Linq;
using WpfTest.Interfaces;
using WpfTest.Models;

namespace WpfTest
{
    public class SaveData
    {
        private IRepository<Table> _repository;
        private Table _data;
        public bool IsUpdate { get; private set; }
        public SaveData(IRepository<Table> repository, Table data)
        {
            _repository = repository;
            _data = data;
            Save();
        }
        private void Save()
        {
            if (_repository.Items.FirstOrDefault(x => x.Equals(_data)) != null)
                return;

            var record = _repository
                .Items
                .FirstOrDefault(x => x.x1a.Equals(_data.x1a) && x.x1b.Equals(_data.x1b) && x.x1c.Equals(_data.x1c) && x.x1d.Equals(_data.x1d));
            if (record != null)
            {
                record.x2 = _data.x2;
                record.x3 = _data.x3;
                record.x4 = _data.x4;
                record.x5 = _data.x5;
                record.x6 = _data.x6;
                record.x7 = _data.x7;
                record.x8 = _data.x8;
                record.x9 = _data.x9;
                record.x10 = _data.x10;
                record.x11 = _data.x11;
                record.x12 = _data.x12;
                record.x13 = _data.x13;
                record.x14 = _data.x14;
                _repository.Update(record);
                IsUpdate = true;
            }
            else
            {
                _repository.Add(_data);
                IsUpdate = false;
            }
        }
    }
}
