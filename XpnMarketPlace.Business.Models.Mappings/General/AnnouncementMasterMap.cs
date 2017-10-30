using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpnMarketPlace.Business.Models;

namespace XpnMarketPlace.Business.Models.Mappings
{
    public class AnnouncementMasterMap : EntityTypeConfiguration<AnnouncementMaster>
    {
        public AnnouncementMasterMap()
        {
            this.HasKey(x => x.Id);

            this.Property(x => x.Id)
                .IsRequired();

            this.Property(x => x.Header)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired();

            this.Property(x => x.IsActive)
                .IsRequired()
                .HasMaxLength(1);

            this.Property(x => x.CreatedOn)
                .IsRequired();

            this.Property(x => x.CreatedBy)
                .IsRequired();

            this.Property(x => x.ModifiedBy)
                .HasMaxLength(30);

            this.ToTable("APP_GEN_Announcements");
            this.Property(x => x.Id).HasColumnName("APPANCMNT_AnnouncementID");
            this.Property(x => x.Header).HasColumnName("APPANCMNT_Header");
            this.Property(x => x.Description).HasColumnName("APPANCMNT_Description");
            this.Property(x => x.IsActive).HasColumnName("APPANCMNT_FlagActive");
            this.Property(x => x.CreatedOn).HasColumnName("APPANCMNT_CreatedDate");
            this.Property(x => x.CreatedBy).HasColumnName("APPANCMNT_CreatedBy");
            this.Property(x => x.ModifiedOn).HasColumnName("APPANCMNT_ModifiedDate");
            this.Property(x => x.ModifiedBy).HasColumnName("APPANCMNT_ModifiedBy");
        }
    }
}
