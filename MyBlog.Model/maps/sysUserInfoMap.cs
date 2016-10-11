﻿using MyBlog.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class sysUserInfoMap: EntityTypeConfiguration<sysUserInfo>
    {
        public sysUserInfoMap()
        {
            this.HasKey(u => u.uID);
            this.Property(u => u.uLoginName).HasMaxLength(60);
            this.Property(u => u.uLoginPWD).HasMaxLength(60);
            this.Property(u => u.uRealName).HasMaxLength(60);
        }
    }
}
