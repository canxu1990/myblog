using MyBlog.IRepository;
using MyBlog.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository
{
    public partial class AdvertisementRepository:BaseRepository<Advertisement>, IAdvertisementRepository
    {
    }
}
