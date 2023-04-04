//onemliiiiiiiiiiiiiiiiiiiiiiiii
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace makaledeneme1.Code
{
    public class FilesHelper
    {
        private readonly IWebHostEnvironment webHost;

        ////projenin dosyalarina erismek icin webHost kullaniliyor
        public FilesHelper(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
        }


        //Upload Files
        public string UploadFile(IFormFile file,string folder)
        {
            if (file != null)
            {
                //combine => دمج
                //webHost.ConteentRootPath => wwwroot demektir
                var fileDir = Path.Combine(webHost.ContentRootPath, folder);//yol bulmak
                var fileName = Guid.NewGuid()+"-"+ file.FileName;//guid tekersiz rename yapabilmek icin
                var filePath = Path.Combine(fileDir, fileName);

                //file olusturmak icin hem de yazma ve okuma yapabilir
                //icinde filenin acack yolu ve fileMode.create eger file olusturmak isterse ve open eger acmak isterse
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    return fileName;
                }

                   
                
            }
            else
            {
                return String.Empty;
            }
          
        }

    }
}
