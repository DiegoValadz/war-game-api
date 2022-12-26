using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WarGame.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    shortName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    suit = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Deck",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DeckCards",
                columns: table => new
                {
                    deckId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cardId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeckCards", x => new { x.deckId, x.cardId });
                    table.ForeignKey(
                        name: "FK_DeckCards_Card_cardId",
                        column: x => x.cardId,
                        principalTable: "Card",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeckCards_Deck_deckId",
                        column: x => x.deckId,
                        principalTable: "Deck",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    winnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.id);
                    table.ForeignKey(
                        name: "FK_Game_Player_winnerId",
                        column: x => x.winnerId,
                        principalTable: "Player",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    playerId = table.Column<int>(type: "int", nullable: true),
                    gameId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cardId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    action = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.id);
                    table.ForeignKey(
                        name: "FK_Event_Card_cardId",
                        column: x => x.cardId,
                        principalTable: "Card",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Event_Game_gameId",
                        column: x => x.gameId,
                        principalTable: "Game",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Player_playerId",
                        column: x => x.playerId,
                        principalTable: "Player",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GamePlayers",
                columns: table => new
                {
                    gameId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    playerId = table.Column<int>(type: "int", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    deckId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayers", x => new { x.gameId, x.playerId });
                    table.ForeignKey(
                        name: "FK_GamePlayers_Deck_deckId",
                        column: x => x.deckId,
                        principalTable: "Deck",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Game_gameId",
                        column: x => x.gameId,
                        principalTable: "Game",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayers_Player_playerId",
                        column: x => x.playerId,
                        principalTable: "Player",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Card",
                columns: new[] { "id", "name", "shortName", "suit", "value" },
                values: new object[,]
                {
                    { "00669b2a-7f27-4d2c-ad10-098db6cf3505", "6 of Diamonds", "6D", 1, 6 },
                    { "07ad7ccb-8d02-4752-afde-3936c9e94493", "6 of Spades", "6S", 2, 6 },
                    { "13e0fe1d-38df-4bbb-b469-3afdc8f13021", "4 of Diamonds", "4D", 1, 4 },
                    { "163b9eea-4cc7-4bd2-81d9-d64da0292b73", "Queen of Hearts", "QH", 3, 12 },
                    { "196c748a-ce97-4d8a-a8d1-f24539611687", "King of Clubs", "KC", 0, 13 },
                    { "24e0f083-1232-4b38-b306-86cc1b6d5e37", "10 of Diamonds", "10D", 1, 10 },
                    { "25264fc8-830b-4572-a62b-42b5a85dce9a", "7 of Clubs", "7C", 0, 7 },
                    { "3367e925-b248-4f20-b4b8-37ad057da92c", "9 of Spades", "9S", 2, 9 },
                    { "3ee85136-ec78-4721-8b6e-86087fcd2b1a", "4 of Clubs", "4C", 0, 4 },
                    { "41f1d6ef-42ad-4bb2-a2db-8365eb4917fc", "10 of Clubs", "10C", 0, 10 },
                    { "427a1dd8-7ca1-40cd-bb6d-651566e4c2eb", "2 of Hearts", "2H", 3, 2 },
                    { "4432a694-45c6-4838-9607-7d5ba6dc2806", "7 of Hearts", "7H", 3, 7 },
                    { "461cec90-05b9-4f6f-832c-b2ab826904bd", "6 of Hearts", "6H", 3, 6 },
                    { "4ac777a3-3eba-4776-86b1-a17389338c98", "3 of Clubs", "3C", 0, 3 },
                    { "54e7311b-80c6-49e9-b0ff-9f54c55cfc1d", "9 of Clubs", "9C", 0, 9 },
                    { "595f564e-7b2e-493e-9995-16ba2fe832cf", "9 of Diamonds", "9D", 1, 9 },
                    { "5d6a15d1-37ab-44ba-b8f3-8ad0c1e05bc6", "7 of Spades", "7S", 2, 7 },
                    { "5e2107ac-5bde-4d48-9dc7-2fa48f41be94", "Queen of Spades", "QS", 2, 12 },
                    { "6717d777-708a-47b1-99bf-ead962ca2ba7", "Ace of Hearts", "AH", 3, 14 },
                    { "675ddade-378a-484a-be37-2e328290eadf", "5 of Hearts", "5H", 3, 5 },
                    { "6d082c7a-f7b2-4192-b9a2-bf1565e4b4e4", "4 of Hearts", "4H", 3, 4 },
                    { "6d4114bb-b247-4053-8a56-1120974fd0ff", "5 of Diamonds", "5D", 1, 5 },
                    { "71c31c60-0db6-49a4-ac0a-34024b8bf2d2", "8 of Diamonds", "8D", 1, 8 },
                    { "7621da79-2c58-47c5-8acc-c4101e07b378", "2 of Clubs", "2C", 0, 2 },
                    { "7bb2e01b-a41e-4008-a207-3b6cd189600f", "Ace of Diamonds", "AD", 1, 14 },
                    { "7cbdc913-e452-4b52-a1a2-e0127da6461f", "3 of Diamonds", "3D", 1, 3 },
                    { "7ec50039-b8ef-49fd-8f29-2b260da62b02", "2 of Spades", "2S", 2, 2 },
                    { "7f08b82c-9ae4-488c-9df2-b58a2a69c03a", "3 of Hearts", "3H", 3, 3 },
                    { "861e49e7-2167-4b46-9459-93d5aad208ec", "9 of Hearts", "9H", 3, 9 },
                    { "876812c8-cc10-4a9d-a50b-05389616134f", "Jack of Hearts", "JH", 3, 11 },
                    { "97cb781b-605a-4edb-96be-6357dca9b562", "8 of Clubs", "8C", 0, 8 },
                    { "984b361a-7bf1-4731-b17e-44cf1672b862", "King of Diamonds", "KD", 1, 13 },
                    { "9acdeb61-1812-4537-b564-0a4dc9bc30fd", "Jack of Diamonds", "JD", 1, 11 },
                    { "a90ffedd-4027-4af4-80c3-9207601706dd", "Ace of Clubs", "AC", 0, 14 },
                    { "b0499e23-970d-4668-8a2b-0752ea907637", "3 of Spades", "3S", 2, 3 },
                    { "b39daf24-0afa-4bcd-9327-16393912f3f0", "Jack of Clubs", "JC", 0, 11 },
                    { "b4af125e-6f82-4339-9ab7-f7f692588d7f", "5 of Clubs", "5C", 0, 5 },
                    { "b5c7aa9f-016b-4ed6-b1e2-740099cc8b3d", "10 of Spades", "10S", 2, 10 },
                    { "b9827dc9-25ae-4e66-ad78-a12b14fad0da", "8 of Hearts", "8H", 3, 8 },
                    { "d625df12-0151-4c36-b1c7-1483e023edf1", "Queen of Diamonds", "QD", 1, 12 },
                    { "d65dd6ab-dd41-4a85-b4b6-58b3dfbd6afa", "King of Spades", "KS", 2, 13 },
                    { "d8e4ec63-6f18-4c96-a8eb-549ec7df6b45", "2 of Diamonds", "2D", 1, 2 },
                    { "d9b9a50e-2f1b-44c3-9ef5-addc490e1baa", "7 of Diamonds", "7D", 1, 7 },
                    { "dd52509b-3308-43f2-b407-853a54f3d9b0", "10 of Hearts", "10H", 3, 10 },
                    { "e104a0da-c10e-442f-a578-28a0b2d91987", "5 of Spades", "5S", 2, 5 },
                    { "e223c5ad-9ecd-4de8-852e-ce7febc12f90", "4 of Spades", "4S", 2, 4 },
                    { "e26b0fa4-904a-485f-9074-fc4bae28d7f9", "Ace of Spades", "AS", 2, 14 },
                    { "ea6d9751-bf57-4f38-969a-976358d3405e", "Queen of Clubs", "QC", 0, 12 },
                    { "eac5ad91-6f7f-409a-87de-caf73502c53d", "Jack of Spades", "JS", 2, 11 },
                    { "eec1aff8-81ad-4761-b502-72183a9aa62f", "8 of Spades", "8S", 2, 8 },
                    { "f20968c0-61ae-482f-8931-a94d75b21ced", "6 of Clubs", "6C", 0, 6 },
                    { "f59dec2b-dd89-41e2-a748-e3bd35a6b1e4", "King of Hearts", "KH", 3, 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeckCards_cardId",
                table: "DeckCards",
                column: "cardId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_cardId",
                table: "Event",
                column: "cardId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_gameId",
                table: "Event",
                column: "gameId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_playerId",
                table: "Event",
                column: "playerId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_winnerId",
                table: "Game",
                column: "winnerId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_deckId",
                table: "GamePlayers",
                column: "deckId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayers_playerId",
                table: "GamePlayers",
                column: "playerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeckCards");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "GamePlayers");

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "Deck");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Player");
        }
    }
}
