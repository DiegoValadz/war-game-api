﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarGame;

#nullable disable

namespace WarGame.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221226035809_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WarGame.Entities.Card", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("shortName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("suit")
                        .HasColumnType("int");

                    b.Property<int>("value")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Card");

                    b.HasData(
                        new
                        {
                            id = "7621da79-2c58-47c5-8acc-c4101e07b378",
                            name = "2 of Clubs",
                            shortName = "2C",
                            suit = 0,
                            value = 2
                        },
                        new
                        {
                            id = "d8e4ec63-6f18-4c96-a8eb-549ec7df6b45",
                            name = "2 of Diamonds",
                            shortName = "2D",
                            suit = 1,
                            value = 2
                        },
                        new
                        {
                            id = "7ec50039-b8ef-49fd-8f29-2b260da62b02",
                            name = "2 of Spades",
                            shortName = "2S",
                            suit = 2,
                            value = 2
                        },
                        new
                        {
                            id = "427a1dd8-7ca1-40cd-bb6d-651566e4c2eb",
                            name = "2 of Hearts",
                            shortName = "2H",
                            suit = 3,
                            value = 2
                        },
                        new
                        {
                            id = "4ac777a3-3eba-4776-86b1-a17389338c98",
                            name = "3 of Clubs",
                            shortName = "3C",
                            suit = 0,
                            value = 3
                        },
                        new
                        {
                            id = "7cbdc913-e452-4b52-a1a2-e0127da6461f",
                            name = "3 of Diamonds",
                            shortName = "3D",
                            suit = 1,
                            value = 3
                        },
                        new
                        {
                            id = "b0499e23-970d-4668-8a2b-0752ea907637",
                            name = "3 of Spades",
                            shortName = "3S",
                            suit = 2,
                            value = 3
                        },
                        new
                        {
                            id = "7f08b82c-9ae4-488c-9df2-b58a2a69c03a",
                            name = "3 of Hearts",
                            shortName = "3H",
                            suit = 3,
                            value = 3
                        },
                        new
                        {
                            id = "3ee85136-ec78-4721-8b6e-86087fcd2b1a",
                            name = "4 of Clubs",
                            shortName = "4C",
                            suit = 0,
                            value = 4
                        },
                        new
                        {
                            id = "13e0fe1d-38df-4bbb-b469-3afdc8f13021",
                            name = "4 of Diamonds",
                            shortName = "4D",
                            suit = 1,
                            value = 4
                        },
                        new
                        {
                            id = "e223c5ad-9ecd-4de8-852e-ce7febc12f90",
                            name = "4 of Spades",
                            shortName = "4S",
                            suit = 2,
                            value = 4
                        },
                        new
                        {
                            id = "6d082c7a-f7b2-4192-b9a2-bf1565e4b4e4",
                            name = "4 of Hearts",
                            shortName = "4H",
                            suit = 3,
                            value = 4
                        },
                        new
                        {
                            id = "b4af125e-6f82-4339-9ab7-f7f692588d7f",
                            name = "5 of Clubs",
                            shortName = "5C",
                            suit = 0,
                            value = 5
                        },
                        new
                        {
                            id = "6d4114bb-b247-4053-8a56-1120974fd0ff",
                            name = "5 of Diamonds",
                            shortName = "5D",
                            suit = 1,
                            value = 5
                        },
                        new
                        {
                            id = "e104a0da-c10e-442f-a578-28a0b2d91987",
                            name = "5 of Spades",
                            shortName = "5S",
                            suit = 2,
                            value = 5
                        },
                        new
                        {
                            id = "675ddade-378a-484a-be37-2e328290eadf",
                            name = "5 of Hearts",
                            shortName = "5H",
                            suit = 3,
                            value = 5
                        },
                        new
                        {
                            id = "f20968c0-61ae-482f-8931-a94d75b21ced",
                            name = "6 of Clubs",
                            shortName = "6C",
                            suit = 0,
                            value = 6
                        },
                        new
                        {
                            id = "00669b2a-7f27-4d2c-ad10-098db6cf3505",
                            name = "6 of Diamonds",
                            shortName = "6D",
                            suit = 1,
                            value = 6
                        },
                        new
                        {
                            id = "07ad7ccb-8d02-4752-afde-3936c9e94493",
                            name = "6 of Spades",
                            shortName = "6S",
                            suit = 2,
                            value = 6
                        },
                        new
                        {
                            id = "461cec90-05b9-4f6f-832c-b2ab826904bd",
                            name = "6 of Hearts",
                            shortName = "6H",
                            suit = 3,
                            value = 6
                        },
                        new
                        {
                            id = "25264fc8-830b-4572-a62b-42b5a85dce9a",
                            name = "7 of Clubs",
                            shortName = "7C",
                            suit = 0,
                            value = 7
                        },
                        new
                        {
                            id = "d9b9a50e-2f1b-44c3-9ef5-addc490e1baa",
                            name = "7 of Diamonds",
                            shortName = "7D",
                            suit = 1,
                            value = 7
                        },
                        new
                        {
                            id = "5d6a15d1-37ab-44ba-b8f3-8ad0c1e05bc6",
                            name = "7 of Spades",
                            shortName = "7S",
                            suit = 2,
                            value = 7
                        },
                        new
                        {
                            id = "4432a694-45c6-4838-9607-7d5ba6dc2806",
                            name = "7 of Hearts",
                            shortName = "7H",
                            suit = 3,
                            value = 7
                        },
                        new
                        {
                            id = "97cb781b-605a-4edb-96be-6357dca9b562",
                            name = "8 of Clubs",
                            shortName = "8C",
                            suit = 0,
                            value = 8
                        },
                        new
                        {
                            id = "71c31c60-0db6-49a4-ac0a-34024b8bf2d2",
                            name = "8 of Diamonds",
                            shortName = "8D",
                            suit = 1,
                            value = 8
                        },
                        new
                        {
                            id = "eec1aff8-81ad-4761-b502-72183a9aa62f",
                            name = "8 of Spades",
                            shortName = "8S",
                            suit = 2,
                            value = 8
                        },
                        new
                        {
                            id = "b9827dc9-25ae-4e66-ad78-a12b14fad0da",
                            name = "8 of Hearts",
                            shortName = "8H",
                            suit = 3,
                            value = 8
                        },
                        new
                        {
                            id = "54e7311b-80c6-49e9-b0ff-9f54c55cfc1d",
                            name = "9 of Clubs",
                            shortName = "9C",
                            suit = 0,
                            value = 9
                        },
                        new
                        {
                            id = "595f564e-7b2e-493e-9995-16ba2fe832cf",
                            name = "9 of Diamonds",
                            shortName = "9D",
                            suit = 1,
                            value = 9
                        },
                        new
                        {
                            id = "3367e925-b248-4f20-b4b8-37ad057da92c",
                            name = "9 of Spades",
                            shortName = "9S",
                            suit = 2,
                            value = 9
                        },
                        new
                        {
                            id = "861e49e7-2167-4b46-9459-93d5aad208ec",
                            name = "9 of Hearts",
                            shortName = "9H",
                            suit = 3,
                            value = 9
                        },
                        new
                        {
                            id = "41f1d6ef-42ad-4bb2-a2db-8365eb4917fc",
                            name = "10 of Clubs",
                            shortName = "10C",
                            suit = 0,
                            value = 10
                        },
                        new
                        {
                            id = "24e0f083-1232-4b38-b306-86cc1b6d5e37",
                            name = "10 of Diamonds",
                            shortName = "10D",
                            suit = 1,
                            value = 10
                        },
                        new
                        {
                            id = "b5c7aa9f-016b-4ed6-b1e2-740099cc8b3d",
                            name = "10 of Spades",
                            shortName = "10S",
                            suit = 2,
                            value = 10
                        },
                        new
                        {
                            id = "dd52509b-3308-43f2-b407-853a54f3d9b0",
                            name = "10 of Hearts",
                            shortName = "10H",
                            suit = 3,
                            value = 10
                        },
                        new
                        {
                            id = "b39daf24-0afa-4bcd-9327-16393912f3f0",
                            name = "Jack of Clubs",
                            shortName = "JC",
                            suit = 0,
                            value = 11
                        },
                        new
                        {
                            id = "9acdeb61-1812-4537-b564-0a4dc9bc30fd",
                            name = "Jack of Diamonds",
                            shortName = "JD",
                            suit = 1,
                            value = 11
                        },
                        new
                        {
                            id = "eac5ad91-6f7f-409a-87de-caf73502c53d",
                            name = "Jack of Spades",
                            shortName = "JS",
                            suit = 2,
                            value = 11
                        },
                        new
                        {
                            id = "876812c8-cc10-4a9d-a50b-05389616134f",
                            name = "Jack of Hearts",
                            shortName = "JH",
                            suit = 3,
                            value = 11
                        },
                        new
                        {
                            id = "ea6d9751-bf57-4f38-969a-976358d3405e",
                            name = "Queen of Clubs",
                            shortName = "QC",
                            suit = 0,
                            value = 12
                        },
                        new
                        {
                            id = "d625df12-0151-4c36-b1c7-1483e023edf1",
                            name = "Queen of Diamonds",
                            shortName = "QD",
                            suit = 1,
                            value = 12
                        },
                        new
                        {
                            id = "5e2107ac-5bde-4d48-9dc7-2fa48f41be94",
                            name = "Queen of Spades",
                            shortName = "QS",
                            suit = 2,
                            value = 12
                        },
                        new
                        {
                            id = "163b9eea-4cc7-4bd2-81d9-d64da0292b73",
                            name = "Queen of Hearts",
                            shortName = "QH",
                            suit = 3,
                            value = 12
                        },
                        new
                        {
                            id = "196c748a-ce97-4d8a-a8d1-f24539611687",
                            name = "King of Clubs",
                            shortName = "KC",
                            suit = 0,
                            value = 13
                        },
                        new
                        {
                            id = "984b361a-7bf1-4731-b17e-44cf1672b862",
                            name = "King of Diamonds",
                            shortName = "KD",
                            suit = 1,
                            value = 13
                        },
                        new
                        {
                            id = "d65dd6ab-dd41-4a85-b4b6-58b3dfbd6afa",
                            name = "King of Spades",
                            shortName = "KS",
                            suit = 2,
                            value = 13
                        },
                        new
                        {
                            id = "f59dec2b-dd89-41e2-a748-e3bd35a6b1e4",
                            name = "King of Hearts",
                            shortName = "KH",
                            suit = 3,
                            value = 13
                        },
                        new
                        {
                            id = "a90ffedd-4027-4af4-80c3-9207601706dd",
                            name = "Ace of Clubs",
                            shortName = "AC",
                            suit = 0,
                            value = 14
                        },
                        new
                        {
                            id = "7bb2e01b-a41e-4008-a207-3b6cd189600f",
                            name = "Ace of Diamonds",
                            shortName = "AD",
                            suit = 1,
                            value = 14
                        },
                        new
                        {
                            id = "e26b0fa4-904a-485f-9074-fc4bae28d7f9",
                            name = "Ace of Spades",
                            shortName = "AS",
                            suit = 2,
                            value = 14
                        },
                        new
                        {
                            id = "6717d777-708a-47b1-99bf-ead962ca2ba7",
                            name = "Ace of Hearts",
                            shortName = "AH",
                            suit = 3,
                            value = 14
                        });
                });

            modelBuilder.Entity("WarGame.Entities.Deck", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.HasKey("id");

                    b.ToTable("Deck");
                });

            modelBuilder.Entity("WarGame.Entities.DeckCards", b =>
                {
                    b.Property<string>("deckId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("cardId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("order")
                        .HasColumnType("int");

                    b.HasKey("deckId", "cardId");

                    b.HasIndex("cardId");

                    b.ToTable("DeckCards");
                });

            modelBuilder.Entity("WarGame.Entities.Event", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("action")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("cardId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("gameId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("playerId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("cardId");

                    b.HasIndex("gameId");

                    b.HasIndex("playerId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("WarGame.Entities.Game", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("winnerId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("winnerId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("WarGame.Entities.GamePlayers", b =>
                {
                    b.Property<string>("gameId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("playerId")
                        .HasColumnType("int");

                    b.Property<string>("deckId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("score")
                        .HasColumnType("int");

                    b.HasKey("gameId", "playerId");

                    b.HasIndex("deckId");

                    b.HasIndex("playerId");

                    b.ToTable("GamePlayers");
                });

            modelBuilder.Entity("WarGame.Entities.Player", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("id");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("WarGame.Entities.DeckCards", b =>
                {
                    b.HasOne("WarGame.Entities.Card", "card")
                        .WithMany("deckCards")
                        .HasForeignKey("cardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarGame.Entities.Deck", "deck")
                        .WithMany("deckCards")
                        .HasForeignKey("deckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("card");

                    b.Navigation("deck");
                });

            modelBuilder.Entity("WarGame.Entities.Event", b =>
                {
                    b.HasOne("WarGame.Entities.Card", "card")
                        .WithMany()
                        .HasForeignKey("cardId");

                    b.HasOne("WarGame.Entities.Game", "game")
                        .WithMany("events")
                        .HasForeignKey("gameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarGame.Entities.Player", "player")
                        .WithMany()
                        .HasForeignKey("playerId");

                    b.Navigation("card");

                    b.Navigation("game");

                    b.Navigation("player");
                });

            modelBuilder.Entity("WarGame.Entities.Game", b =>
                {
                    b.HasOne("WarGame.Entities.Player", "winner")
                        .WithMany()
                        .HasForeignKey("winnerId");

                    b.Navigation("winner");
                });

            modelBuilder.Entity("WarGame.Entities.GamePlayers", b =>
                {
                    b.HasOne("WarGame.Entities.Deck", "deck")
                        .WithMany()
                        .HasForeignKey("deckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarGame.Entities.Game", "game")
                        .WithMany("gamePlayers")
                        .HasForeignKey("gameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WarGame.Entities.Player", "player")
                        .WithMany("gamePlayers")
                        .HasForeignKey("playerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("deck");

                    b.Navigation("game");

                    b.Navigation("player");
                });

            modelBuilder.Entity("WarGame.Entities.Card", b =>
                {
                    b.Navigation("deckCards");
                });

            modelBuilder.Entity("WarGame.Entities.Deck", b =>
                {
                    b.Navigation("deckCards");
                });

            modelBuilder.Entity("WarGame.Entities.Game", b =>
                {
                    b.Navigation("events");

                    b.Navigation("gamePlayers");
                });

            modelBuilder.Entity("WarGame.Entities.Player", b =>
                {
                    b.Navigation("gamePlayers");
                });
#pragma warning restore 612, 618
        }
    }
}
