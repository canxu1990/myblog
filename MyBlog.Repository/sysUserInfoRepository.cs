using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.IRepository;

namespace MyBlog.Repository
{
    public partial class sysUserInfoRepository:BaseRepository<sysUserInfo>,IsysUserInfoRepository
    {

    }
}
