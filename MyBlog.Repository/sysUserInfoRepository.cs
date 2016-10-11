using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.IRepository;
using MyBlog.Model.Entity;

namespace MyBlog.Repository
{
    public partial class sysUserInfoRepository:BaseRepository<sysUserInfo>,IsysUserInfoRepository
    {

    }
}
