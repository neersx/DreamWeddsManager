using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamWeddsManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DreamWeddsEntityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BlogSubject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Quote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AuthorName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BlogType = table.Column<int>(type: "int", nullable: false),
                    SpecialNote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsMainQue = table.Column<bool>(type: "bit", nullable: false),
                    ParentQuestionId = table.Column<int>(type: "int", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BillingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CGST = table.Column<int>(type: "int", nullable: true),
                    SGST = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceivedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentMode = table.Column<int>(type: "int", nullable: true),
                    PaymentTerms = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OderNote = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubsType = table.Column<int>(type: "int", nullable: false),
                    SubsName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubsCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Days = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TemplateUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TemplateFolderPath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ThumbnailImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TagLine = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: true),
                    AuthorName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    AboutTemplate = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Features = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TemplateCode = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wedding",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeddingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    WeddingStyle = table.Column<int>(type: "int", nullable: false),
                    IconUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TemplateID = table.Column<int>(type: "int", nullable: true),
                    IsLoveMarriage = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    BackgroundImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Quote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FbPageUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wedding", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    TemplateID = table.Column<int>(type: "int", nullable: false),
                    SubscrptionID = table.Column<int>(type: "int", nullable: true),
                    OrderMasterId = table.Column<int>(type: "int", nullable: true),
                    SubscriptionMasterId = table.Column<int>(type: "int", nullable: true),
                    TemplateMasterId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_OrderMaster_OrderMasterId",
                        column: x => x.OrderMasterId,
                        principalTable: "OrderMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetail_SubscriptionMaster_SubscriptionMasterId",
                        column: x => x.SubscriptionMasterId,
                        principalTable: "SubscriptionMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetail_TemplateMaster_TemplateMasterId",
                        column: x => x.TemplateMasterId,
                        principalTable: "TemplateMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TemplateImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    TagLine = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FolderPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsBannerImage = table.Column<bool>(type: "bit", nullable: false),
                    TemplateID = table.Column<int>(type: "int", nullable: false),
                    ImageType = table.Column<int>(type: "int", nullable: true),
                    TemplateMasterId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateImage_TemplateMaster_TemplateMasterId",
                        column: x => x.TemplateMasterId,
                        principalTable: "TemplateMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TemplateMergeField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MERGEFIELDNAME = table.Column<string>(name: "MERGEFIELD_NAME", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SRCFIELD = table.Column<string>(name: "SRC_FIELD", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SRCFIELDVALUE = table.Column<string>(name: "SRC_FIELD_VALUE", type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TemplateID = table.Column<int>(type: "int", nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: true),
                    TemplateCode = table.Column<int>(type: "int", nullable: true),
                    TemplateMasterId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateMergeField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateMergeField_TemplateMaster_TemplateMasterId",
                        column: x => x.TemplateMasterId,
                        principalTable: "TemplateMaster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BrideAndMaid",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WeddingID = table.Column<int>(type: "int", nullable: false),
                    IsBride = table.Column<bool>(type: "bit", nullable: false),
                    RelationWithBride = table.Column<int>(type: "int", nullable: true),
                    About = table.Column<string>(type: "nvarchar(1250)", maxLength: 1250, nullable: true),
                    FbUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GoogleUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrideAndMaid", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrideAndMaid_Wedding_WeddingID",
                        column: x => x.WeddingID,
                        principalTable: "Wedding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroomAndMan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WeddingID = table.Column<int>(type: "int", nullable: false),
                    IsGroom = table.Column<bool>(type: "bit", nullable: false),
                    RelationWithGroom = table.Column<int>(type: "int", nullable: true),
                    Imageurl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    About = table.Column<string>(type: "nvarchar(1250)", maxLength: 1250, nullable: true),
                    FbUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GoogleUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroomAndMan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroomAndMan_Wedding_WeddingID",
                        column: x => x.WeddingID,
                        principalTable: "Wedding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RsvpDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsComing = table.Column<bool>(type: "bit", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GuestCount = table.Column<int>(type: "int", nullable: true),
                    PreferredFood = table.Column<byte>(type: "tinyint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    SpecialNote = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WeddingID = table.Column<int>(type: "int", nullable: false),
                    ParticipatingInEvents = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ComingFromCity = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    PreferredStayIn = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RsvpDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RsvpDetail_Wedding_WeddingID",
                        column: x => x.WeddingID,
                        principalTable: "Wedding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeLine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Story = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WeddingID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeLine_Wedding_WeddingID",
                        column: x => x.WeddingID,
                        principalTable: "Wedding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWeddingSubscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TemplateID = table.Column<int>(type: "int", nullable: false),
                    InvoiceNo = table.Column<int>(type: "int", nullable: true),
                    WeddingID = table.Column<int>(type: "int", nullable: true),
                    SubscriptionType = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonOfUpdate = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubscriptionStatus = table.Column<int>(type: "int", nullable: false),
                    OrderMasterId = table.Column<int>(type: "int", nullable: true),
                    SubscriptionMasterId = table.Column<int>(type: "int", nullable: true),
                    TemplateMasterId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWeddingSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWeddingSubscription_OrderMaster_OrderMasterId",
                        column: x => x.OrderMasterId,
                        principalTable: "OrderMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserWeddingSubscription_SubscriptionMaster_SubscriptionMasterId",
                        column: x => x.SubscriptionMasterId,
                        principalTable: "SubscriptionMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserWeddingSubscription_TemplateMaster_TemplateMasterId",
                        column: x => x.TemplateMasterId,
                        principalTable: "TemplateMaster",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserWeddingSubscription_Wedding_WeddingID",
                        column: x => x.WeddingID,
                        principalTable: "Wedding",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WeddingEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    WeddingID = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aboutevent = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    BackGroundImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeddingEvent_Wedding_WeddingID",
                        column: x => x.WeddingID,
                        principalTable: "Wedding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeddingImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WeddingID = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DateTaken = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Place = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeddingImages_Wedding_WeddingID",
                        column: x => x.WeddingID,
                        principalTable: "Wedding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BannerImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    WeddingEventID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    GoogleMapUrl = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venue_WeddingEvent_WeddingEventID",
                        column: x => x.WeddingEventID,
                        principalTable: "WeddingEvent",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrideAndMaid_WeddingID",
                table: "BrideAndMaid",
                column: "WeddingID");

            migrationBuilder.CreateIndex(
                name: "IX_GroomAndMan_WeddingID",
                table: "GroomAndMan",
                column: "WeddingID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderMasterId",
                table: "OrderDetail",
                column: "OrderMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_SubscriptionMasterId",
                table: "OrderDetail",
                column: "SubscriptionMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_TemplateMasterId",
                table: "OrderDetail",
                column: "TemplateMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_RsvpDetail_WeddingID",
                table: "RsvpDetail",
                column: "WeddingID");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateImage_TemplateMasterId",
                table: "TemplateImage",
                column: "TemplateMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateMergeField_TemplateMasterId",
                table: "TemplateMergeField",
                column: "TemplateMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLine_WeddingID",
                table: "TimeLine",
                column: "WeddingID");

            migrationBuilder.CreateIndex(
                name: "IX_UserWeddingSubscription_OrderMasterId",
                table: "UserWeddingSubscription",
                column: "OrderMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWeddingSubscription_SubscriptionMasterId",
                table: "UserWeddingSubscription",
                column: "SubscriptionMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWeddingSubscription_TemplateMasterId",
                table: "UserWeddingSubscription",
                column: "TemplateMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWeddingSubscription_WeddingID",
                table: "UserWeddingSubscription",
                column: "WeddingID");

            migrationBuilder.CreateIndex(
                name: "IX_Venue_WeddingEventID",
                table: "Venue",
                column: "WeddingEventID");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingEvent_WeddingID",
                table: "WeddingEvent",
                column: "WeddingID");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingImages_WeddingID",
                table: "WeddingImages",
                column: "WeddingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "BrideAndMaid");

            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropTable(
                name: "GroomAndMan");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "RsvpDetail");

            migrationBuilder.DropTable(
                name: "TemplateImage");

            migrationBuilder.DropTable(
                name: "TemplateMergeField");

            migrationBuilder.DropTable(
                name: "TimeLine");

            migrationBuilder.DropTable(
                name: "UserWeddingSubscription");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropTable(
                name: "WeddingImages");

            migrationBuilder.DropTable(
                name: "OrderMaster");

            migrationBuilder.DropTable(
                name: "SubscriptionMaster");

            migrationBuilder.DropTable(
                name: "TemplateMaster");

            migrationBuilder.DropTable(
                name: "WeddingEvent");

            migrationBuilder.DropTable(
                name: "Wedding");
        }
    }
}
