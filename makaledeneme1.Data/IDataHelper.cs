using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makaledeneme1.Data
{
    public interface IDataHelper<Table>
    {
        //read
        List<Table> getAllData();
        List<Table> getDataByUser(string UserId);
        List<Table> search(string searchItem);
        Table Find(int Id);



        //write

        int Add(Table table);
        int Edit(int Id, Table table);
        int delete(int Id);

    }
}
