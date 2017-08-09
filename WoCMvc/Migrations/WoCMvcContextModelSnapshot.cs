using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WoCMvc.Models;

namespace WoCMvc.Migrations
{
    [DbContext(typeof(WoCMvcContext))]
    partial class WoCMvcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WoCMvc.Models.Member", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Education");

                    b.Property<string>("Ethnicity");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<string>("ResumeID");

                    b.HasKey("ID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("WoCMvc.Models.Skill", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MemberID");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("MemberID");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("WoCMvc.Models.Skill", b =>
                {
                    b.HasOne("WoCMvc.Models.Member")
                        .WithMany("SkillSet")
                        .HasForeignKey("MemberID");
                });
        }
    }
}
