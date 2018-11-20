using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using TournamentWebApp.DataAccess;

namespace TournamentWebApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20151021161139_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta8-15964")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TournamentWebApp.Models.Pairing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("P1Id");

                    b.Property<int>("P1Score");

                    b.Property<int>("P2Id");

                    b.Property<int>("P2Score");

                    b.Property<int?>("Player1Id");

                    b.Property<int?>("Player2Id");

                    b.Property<int?>("RoundRoundId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TournamentWebApp.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Name");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TournamentWebApp.Models.Round", b =>
                {
                    b.Property<int>("RoundId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RoundNumber");

                    b.Property<int>("Tournament");

                    b.Property<int?>("TournamentId");

                    b.HasKey("RoundId");
                });

            modelBuilder.Entity("TournamentWebApp.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("TournamentWebApp.Models.Pairing", b =>
                {
                    b.HasOne("TournamentWebApp.Models.Player")
                        .WithMany()
                        .ForeignKey("Player1Id");

                    b.HasOne("TournamentWebApp.Models.Player")
                        .WithMany()
                        .ForeignKey("Player2Id");

                    b.HasOne("TournamentWebApp.Models.Round")
                        .WithMany()
                        .ForeignKey("RoundRoundId");
                });

            modelBuilder.Entity("TournamentWebApp.Models.Round", b =>
                {
                    b.HasOne("TournamentWebApp.Models.Tournament")
                        .WithMany()
                        .ForeignKey("TournamentId");
                });
        }
    }
}
