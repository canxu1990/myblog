using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.IServices;
using MyBlog.IRepository;
using MyBlog.Model.Entity;

namespace MyBlog.Services
{
    public partial class sysUserInfoServices:BaseServices<sysUserInfo>,IsysUserInfoServices
    {
        IsysUserInfoRepository dal;
        public sysUserInfoServices(IsysUserInfoRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
    }
}
