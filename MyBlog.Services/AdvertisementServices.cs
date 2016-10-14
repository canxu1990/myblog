using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Model.Entity;
using MyBlog.IRepository;

namespace MyBlog.Services
{
    public partial class AdvertisementServices:BaseServices<Advertisement>,IServices.IAdvertisementServices
    {
        IAdvertisementRepository iad;
        public AdvertisementServices(IAdvertisementRepository iad)
        {
            this.iad = iad;
            this.baseDal = iad;
        }
    }
}
