USE [master]
GO
/****** Object:  Database [QLNhaTro]    Script Date: 6/15/2022 6:40:11 PM ******/
CREATE DATABASE [QLNhaTro]
GO
ALTER DATABASE [QLNhaTro] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLNhaTro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLNhaTro] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLNhaTro] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLNhaTro] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLNhaTro] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLNhaTro] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLNhaTro] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLNhaTro] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLNhaTro] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLNhaTro] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLNhaTro] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLNhaTro] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLNhaTro] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLNhaTro] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLNhaTro] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLNhaTro] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLNhaTro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLNhaTro] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLNhaTro] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLNhaTro] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLNhaTro] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLNhaTro] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLNhaTro] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLNhaTro] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLNhaTro] SET  MULTI_USER 
GO
ALTER DATABASE [QLNhaTro] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLNhaTro] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLNhaTro] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLNhaTro] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QLNhaTro] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLNhaTro', N'ON'
GO
ALTER DATABASE [QLNhaTro] SET QUERY_STORE = OFF
GO
USE [QLNhaTro]
GO
/****** Object:  Table [dbo].[BangGia]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangGia](
	[MaBG] [varchar](6) NOT NULL,
	[Gia] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHopDongThuePhong]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHopDongThuePhong](
	[SoHDThue] [varchar](6) NOT NULL,
	[MaPhong] [varchar](6) NOT NULL,
	[TienDatCoc] [int] NOT NULL,
	[NgayGioDK] [datetime] NOT NULL,
	[NgayDonVao] [datetime] NOT NULL,
	[NgayDonRa] [datetime] NULL,
 CONSTRAINT [PK_ChiTietHopDongThuePhong_1] PRIMARY KEY CLUSTERED 
(
	[SoHDThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietSuDungDV]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietSuDungDV](
	[SoHDThue] [varchar](6) NOT NULL,
	[MaDV] [varchar](6) NOT NULL,
	[NgayGioDK] [datetime] NOT NULL,
	[NgayGioHuy] [datetime] NULL,
 CONSTRAINT [PK_ChiTietSuDungDV] PRIMARY KEY CLUSTERED 
(
	[SoHDThue] ASC,
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDV] [varchar](6) NOT NULL,
	[MaLoaiDV] [varchar](6) NOT NULL,
	[TenDV] [nvarchar](50) NOT NULL,
	[GiaDV] [int] NOT NULL,
	[ChiTietDV] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HopDongThuePhong]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HopDongThuePhong](
	[SoHDThue] [varchar](6) NOT NULL,
	[MaKH] [varchar](6) NOT NULL,
	[MaNV] [varchar](6) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SoHDThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [varchar](6) NOT NULL,
	[MaLoaiKH] [varchar](6) NOT NULL,
	[HovaTenKH] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](3) NOT NULL,
	[NamSinh] [varchar](4) NOT NULL,
	[CCCD] [varchar](12) NOT NULL,
	[QueQuan] [nvarchar](50) NOT NULL,
	[SDT] [nchar](11) NULL,
	[NgheNghiep] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__KhachHan__2725CF1E617566B3] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiDichVu]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiDichVu](
	[MaLoaiDV] [varchar](6) NOT NULL,
	[TenLoaiDV] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiKhachHang]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiKhachHang](
	[MaLoaiKH] [varchar](6) NOT NULL,
	[TenLoaiKH] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiPhong]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiPhong](
	[MaLoaiPhong] [varchar](6) NOT NULL,
	[TenLoaiPhong] [nvarchar](50) NOT NULL,
	[DienTichPhong] [int] NULL,
	[MaBG] [varchar](6) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiThietBi]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiThietBi](
	[MaLoaiTB] [varchar](6) NOT NULL,
	[TenLoaiTB] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaLoaiTB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [varchar](6) NOT NULL,
	[HovaTenNV] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](3) NOT NULL,
	[NamSinh] [date] NOT NULL,
	[CCCD] [varchar](12) NOT NULL,
	[QueQuan] [nvarchar](50) NOT NULL,
	[Luong] [int] NOT NULL,
 CONSTRAINT [PK__NhanVien__2725D70A7EC56599] PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongTro]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongTro](
	[MaPhong] [varchar](6) NOT NULL,
	[MaLoaiPhong] [varchar](6) NOT NULL,
	[TenPhong] [varchar](10) NOT NULL,
	[DayPhong] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SoThuTien]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoThuTien](
	[MaPhieuThu] [varchar](6) NOT NULL,
	[SoHDThue] [varchar](6) NOT NULL,
	[SoTienThu] [int] NOT NULL,
	[NgayThu] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieuThu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenNguoiDung] [nchar](20) NOT NULL,
	[MatKhau] [nchar](20) NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[TenNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThietBi]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThietBi](
	[MaTB] [varchar](6) NOT NULL,
	[MaLoaiTB] [varchar](6) NOT NULL,
	[TenTB] [nvarchar](50) NOT NULL,
	[Gia] [int] NOT NULL,
	[ThoiGianBaoHanh] [int] NULL,
 CONSTRAINT [PK__ThietBi__2725006FCD87B961] PRIMARY KEY CLUSTERED 
(
	[MaTB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrangBi]    Script Date: 6/19/2022 6:40:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangBi](
	[MaTB] [varchar](6) NOT NULL,
	[MaPhong] [varchar](6) NOT NULL,
	[NgayTrangBi] [date] NOT NULL,
 CONSTRAINT [PK_TrangBi] PRIMARY KEY CLUSTERED 
(
	[MaTB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[BangGia] ([MaBG], [Gia]) VALUES (N'BG1', 2000000)
INSERT [dbo].[BangGia] ([MaBG], [Gia]) VALUES (N'BG2', 3000000)
INSERT [dbo].[BangGia] ([MaBG], [Gia]) VALUES (N'BG3', 5000000)
GO
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT001', N'P02', 1000000, CAST(N'2020-09-30T00:00:00.000' AS DateTime), CAST(N'2020-10-09T00:00:00.000' AS DateTime), CAST(N'2021-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT002', N'P02', 1000000, CAST(N'2019-08-05T00:00:00.000' AS DateTime), CAST(N'2019-09-07T00:00:00.000' AS DateTime), CAST(N'2019-08-05T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT003', N'P03', 1000000, CAST(N'2019-10-25T00:00:00.000' AS DateTime), CAST(N'2019-11-27T00:00:00.000' AS DateTime), CAST(N'2021-11-27T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT004', N'P04', 1000000, CAST(N'2018-07-15T00:00:00.000' AS DateTime), CAST(N'2018-08-17T00:00:00.000' AS DateTime), CAST(N'2021-08-17T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT005', N'P05', 1000000, CAST(N'2021-04-11T00:00:00.000' AS DateTime), CAST(N'2021-05-13T00:00:00.000' AS DateTime), CAST(N'2021-04-11T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT006', N'P06', 2000000, CAST(N'2020-05-18T00:00:00.000' AS DateTime), CAST(N'2020-06-20T00:00:00.000' AS DateTime), CAST(N'2022-04-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT007', N'P07', 2000000, CAST(N'2019-03-04T00:00:00.000' AS DateTime), CAST(N'2019-04-06T00:00:00.000' AS DateTime), CAST(N'2019-03-04T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT008', N'P08', 2000000, CAST(N'2016-04-02T00:00:00.000' AS DateTime), CAST(N'2016-04-04T00:00:00.000' AS DateTime), CAST(N'2021-05-04T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT009', N'P09', 2000000, CAST(N'2021-06-05T00:00:00.000' AS DateTime), CAST(N'2021-07-07T00:00:00.000' AS DateTime), CAST(N'2021-06-05T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT010', N'P10', 2000000, CAST(N'2016-11-05T00:00:00.000' AS DateTime), CAST(N'2016-11-05T00:00:00.000' AS DateTime), CAST(N'2019-12-07T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT011', N'P11', 3000000, CAST(N'2016-10-17T00:00:00.000' AS DateTime), CAST(N'2016-11-19T00:00:00.000' AS DateTime), CAST(N'2016-10-17T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT012', N'P12', 3000000, CAST(N'2018-07-27T00:00:00.000' AS DateTime), CAST(N'2018-07-27T00:00:00.000' AS DateTime), CAST(N'2021-08-29T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT013', N'P03', 1000000, CAST(N'2020-05-01T00:00:00.000' AS DateTime), CAST(N'2020-05-01T00:00:00.000' AS DateTime), CAST(N'2020-05-01T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT014', N'P01', 1000000, CAST(N'2020-05-01T00:00:00.000' AS DateTime), CAST(N'2020-10-05T00:00:00.000' AS DateTime), CAST(N'2020-05-01T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT015', N'P04', 1000000, CAST(N'2019-06-10T00:00:00.000' AS DateTime), CAST(N'2019-06-10T00:00:00.000' AS DateTime), CAST(N'2019-06-10T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT016', N'P13', 3000000, CAST(N'2022-06-08T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), CAST(N'2022-06-08T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT017', N'P06', 2000000, CAST(N'2022-04-21T00:00:00.000' AS DateTime), CAST(N'2020-04-21T00:00:00.000' AS DateTime), CAST(N'2022-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT018', N'P15', 3000000, CAST(N'2020-02-14T00:00:00.000' AS DateTime), CAST(N'2020-02-14T00:00:00.000' AS DateTime), CAST(N'2020-02-14T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT019', N'P10', 2000000, CAST(N'2020-02-20T00:00:00.000' AS DateTime), CAST(N'2020-02-20T00:00:00.000' AS DateTime), CAST(N'2020-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietHopDongThuePhong] ([SoHDThue], [MaPhong], [TienDatCoc], [NgayGioDK], [NgayDonVao], [NgayDonRa]) VALUES (N'HDT020', N'P12', 3000000, CAST(N'2020-08-16T00:00:00.000' AS DateTime), CAST(N'2020-08-16T00:00:00.000' AS DateTime), CAST(N'2022-05-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT001', N'DV02', CAST(N'2020-09-30T00:00:00.000' AS DateTime), CAST(N'2021-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT001', N'DV06', CAST(N'2020-09-30T00:00:00.000' AS DateTime), CAST(N'2021-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT001', N'DV07', CAST(N'2020-09-30T00:00:00.000' AS DateTime), CAST(N'2021-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT001', N'DV08', CAST(N'2020-09-30T00:00:00.000' AS DateTime), CAST(N'2021-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT002', N'DV02', CAST(N'2019-08-05T00:00:00.000' AS DateTime), CAST(N'2019-08-05T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT002', N'DV06', CAST(N'2019-08-05T00:00:00.000' AS DateTime), CAST(N'2019-08-05T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT002', N'DV07', CAST(N'2019-08-05T00:00:00.000' AS DateTime), CAST(N'2019-08-05T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT002', N'DV08', CAST(N'2019-08-05T00:00:00.000' AS DateTime), CAST(N'2019-08-05T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT003', N'DV02', CAST(N'2019-10-25T00:00:00.000' AS DateTime), CAST(N'2019-10-25T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT003', N'DV03', CAST(N'2019-10-25T00:00:00.000' AS DateTime), CAST(N'2019-10-25T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT003', N'DV06', CAST(N'2019-10-25T00:00:00.000' AS DateTime), CAST(N'2019-10-25T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT003', N'DV07', CAST(N'2019-10-25T00:00:00.000' AS DateTime), CAST(N'2019-10-25T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT003', N'DV08', CAST(N'2019-10-25T00:00:00.000' AS DateTime), CAST(N'2019-10-25T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT004', N'DV06', CAST(N'2018-07-15T00:00:00.000' AS DateTime), CAST(N'2021-08-17T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT004', N'DV07', CAST(N'2018-07-15T00:00:00.000' AS DateTime), CAST(N'2021-08-17T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT004', N'DV08', CAST(N'2018-07-15T00:00:00.000' AS DateTime), CAST(N'2021-08-17T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT005', N'DV06', CAST(N'2021-04-11T00:00:00.000' AS DateTime), CAST(N'2021-04-11T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT005', N'DV07', CAST(N'2021-04-11T00:00:00.000' AS DateTime), CAST(N'2021-04-11T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT005', N'DV08', CAST(N'2021-04-11T00:00:00.000' AS DateTime), CAST(N'2021-04-11T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT006', N'DV06', CAST(N'2020-05-18T00:00:00.000' AS DateTime), CAST(N'2022-04-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT006', N'DV07', CAST(N'2020-05-18T00:00:00.000' AS DateTime), CAST(N'2022-04-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT006', N'DV08', CAST(N'2020-05-18T00:00:00.000' AS DateTime), CAST(N'2022-04-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT007', N'DV06', CAST(N'2019-03-04T00:00:00.000' AS DateTime), CAST(N'2019-03-04T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT007', N'DV07', CAST(N'2020-03-04T00:00:00.000' AS DateTime), CAST(N'2019-03-04T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT008', N'DV06', CAST(N'2016-04-02T00:00:00.000' AS DateTime), CAST(N'2021-05-04T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT008', N'DV07', CAST(N'2016-04-02T00:00:00.000' AS DateTime), CAST(N'2021-04-05T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT008', N'DV08', CAST(N'2016-04-02T00:00:00.000' AS DateTime), CAST(N'2021-05-04T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT009', N'DV05', CAST(N'2020-06-05T00:00:00.000' AS DateTime), CAST(N'2020-06-05T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT009', N'DV06', CAST(N'2020-06-05T00:00:00.000' AS DateTime), CAST(N'2020-06-05T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT009', N'DV07', CAST(N'2020-06-05T00:00:00.000' AS DateTime), CAST(N'2020-06-05T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT009', N'DV08', CAST(N'2016-04-02T00:00:00.000' AS DateTime), CAST(N'2021-05-04T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT010', N'DV05', CAST(N'2016-11-05T00:00:00.000' AS DateTime), CAST(N'2019-12-07T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT010', N'DV06', CAST(N'2016-11-05T00:00:00.000' AS DateTime), CAST(N'2019-12-07T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT010', N'DV07', CAST(N'2016-11-05T00:00:00.000' AS DateTime), CAST(N'2019-12-07T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT011', N'DV05', CAST(N'2016-10-17T00:00:00.000' AS DateTime), CAST(N'2016-10-17T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT011', N'DV06', CAST(N'2016-10-17T00:00:00.000' AS DateTime), CAST(N'2016-10-17T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT011', N'DV07', CAST(N'2016-10-17T00:00:00.000' AS DateTime), CAST(N'2016-10-17T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT012', N'DV05', CAST(N'2018-07-27T00:00:00.000' AS DateTime), CAST(N'2021-08-29T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT012', N'DV06', CAST(N'2018-07-27T00:00:00.000' AS DateTime), CAST(N'2021-08-29T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT012', N'DV07', CAST(N'2018-07-27T00:00:00.000' AS DateTime), CAST(N'2021-08-29T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT012', N'DV08', CAST(N'2016-04-02T00:00:00.000' AS DateTime), CAST(N'2021-05-04T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT013', N'DV05', CAST(N'2020-05-01T00:00:00.000' AS DateTime), CAST(N'2020-05-01T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT013', N'DV06', CAST(N'2020-05-01T00:00:00.000' AS DateTime), CAST(N'2020-05-01T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT013', N'DV07', CAST(N'2020-05-01T00:00:00.000' AS DateTime), CAST(N'2020-05-01T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT013', N'DV08', CAST(N'2020-05-01T00:00:00.000' AS DateTime), CAST(N'2020-05-01T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT014', N'DV06', CAST(N'2020-01-05T00:00:00.000' AS DateTime), CAST(N'2020-01-05T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT014', N'DV07', CAST(N'2020-01-05T00:00:00.000' AS DateTime), CAST(N'2020-01-05T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT015', N'DV01', CAST(N'2019-06-10T00:00:00.000' AS DateTime), CAST(N'2019-06-10T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT015', N'DV06', CAST(N'2019-06-10T00:00:00.000' AS DateTime), CAST(N'2019-06-10T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT015', N'DV07', CAST(N'2019-06-10T00:00:00.000' AS DateTime), CAST(N'2019-06-10T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT015', N'DV08', CAST(N'2019-06-10T00:00:00.000' AS DateTime), CAST(N'2019-06-10T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT016', N'DV06', CAST(N'2022-06-08T00:00:00.000' AS DateTime), CAST(N'2022-06-08T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT016', N'DV07', CAST(N'2022-06-08T00:00:00.000' AS DateTime), CAST(N'2022-06-08T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT017', N'DV01', CAST(N'2022-04-21T00:00:00.000' AS DateTime), CAST(N'2022-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT017', N'DV04', CAST(N'2022-04-21T00:00:00.000' AS DateTime), CAST(N'2022-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT017', N'DV06', CAST(N'2022-04-21T00:00:00.000' AS DateTime), CAST(N'2022-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT017', N'DV07', CAST(N'2022-04-21T00:00:00.000' AS DateTime), CAST(N'2022-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT017', N'DV08', CAST(N'2022-04-21T00:00:00.000' AS DateTime), CAST(N'2022-04-21T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT018', N'DV04', CAST(N'2020-02-14T00:00:00.000' AS DateTime), CAST(N'2020-02-14T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT018', N'DV06', CAST(N'2020-02-14T00:00:00.000' AS DateTime), CAST(N'2020-02-14T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT018', N'DV07', CAST(N'2020-02-14T00:00:00.000' AS DateTime), CAST(N'2020-02-14T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT018', N'DV08', CAST(N'2020-02-14T00:00:00.000' AS DateTime), CAST(N'2020-02-14T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT019', N'DV01', CAST(N'2020-02-20T00:00:00.000' AS DateTime), CAST(N'2020-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT019', N'DV02', CAST(N'2020-02-20T00:00:00.000' AS DateTime), CAST(N'2020-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT019', N'DV03', CAST(N'2020-02-20T00:00:00.000' AS DateTime), CAST(N'2020-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT019', N'DV06', CAST(N'2020-02-20T00:00:00.000' AS DateTime), CAST(N'2020-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT019', N'DV07', CAST(N'2020-02-20T00:00:00.000' AS DateTime), CAST(N'2020-02-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT020', N'DV06', CAST(N'2020-06-18T00:00:00.000' AS DateTime), CAST(N'2022-05-30T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT020', N'DV07', CAST(N'2020-06-18T00:00:00.000' AS DateTime), CAST(N'2025-05-30T00:00:00.000' AS DateTime))
INSERT [dbo].[ChiTietSuDungDV] ([SoHDThue], [MaDV], [NgayGioDK], [NgayGioHuy]) VALUES (N'HDT020', N'DV08', CAST(N'2020-06-18T00:00:00.000' AS DateTime), CAST(N'2022-05-30T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[DichVu] ([MaDV], [MaLoaiDV], [TenDV], [GiaDV], [ChiTietDV]) VALUES (N'DV01', N'LDV01', N'Dọn dẹp ', 30000, N'Một tháng')
INSERT [dbo].[DichVu] ([MaDV], [MaLoaiDV], [TenDV], [GiaDV], [ChiTietDV]) VALUES (N'DV02', N'LDV01', N'Vứt rác', 20000, N'Một ngày')
INSERT [dbo].[DichVu] ([MaDV], [MaLoaiDV], [TenDV], [GiaDV], [ChiTietDV]) VALUES (N'DV03', N'LDV01', N'Giặt quần áo ướt', 5000, N'Một ngày, một kg')
INSERT [dbo].[DichVu] ([MaDV], [MaLoaiDV], [TenDV], [GiaDV], [ChiTietDV]) VALUES (N'DV04', N'LDV01', N'Giặt quần áo, sấy khô', 12000, N'Một ngày, một kg')
INSERT [dbo].[DichVu] ([MaDV], [MaLoaiDV], [TenDV], [GiaDV], [ChiTietDV]) VALUES (N'DV05', N'LDV01', N'WiFi', 15000, N'Một tháng')
INSERT [dbo].[DichVu] ([MaDV], [MaLoaiDV], [TenDV], [GiaDV], [ChiTietDV]) VALUES (N'DV06', N'LDV02', N'Điện', 4000, N'Một KWh')
INSERT [dbo].[DichVu] ([MaDV], [MaLoaiDV], [TenDV], [GiaDV], [ChiTietDV]) VALUES (N'DV07', N'LDV02', N'Nước', 15000, N'Một khối')
INSERT [dbo].[DichVu] ([MaDV], [MaLoaiDV], [TenDV], [GiaDV], [ChiTietDV]) VALUES (N'DV08', N'LDV01', N'Gửi xe', 55000, N'Một tháng')
GO
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT001', N'KH001', N'NV001')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT002', N'KH002', N'NV001')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT003', N'KH003', N'NV001')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT004', N'KH004', N'NV001')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT005', N'KH005', N'NV001')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT006', N'KH006', N'NV001')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT007', N'KH007', N'NV001')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT008', N'KH008', N'NV001')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT009', N'KH009', N'NV002')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT010', N'KH010', N'NV002')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT011', N'KH011', N'NV002')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT012', N'KH012', N'NV002')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT013', N'KH013', N'NV002')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT014', N'KH014', N'NV003')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT015', N'KH015', N'NV003')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT016', N'KH016', N'NV003')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT017', N'KH017', N'NV003')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT018', N'KH018', N'NV003')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT019', N'KH019', N'NV003')
INSERT [dbo].[HopDongThuePhong] ([SoHDThue], [MaKH], [MaNV]) VALUES (N'HDT020', N'KH020', N'NV002')
GO
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH001', N'LKH01', N'Nguyễn Văn Tùng', N'Nam', N'2001', N'089221345672', N'Phú Yên', N'0325478952 ', N'Bán Hàng')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH002', N'LKH01', N'Trần Tuyết Như', N'Nữ', N'1994', N'078923117569', N'Bình Thuận', N'0879451325 ', N'Công Nhân (Thợ May)')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH003', N'LKH01', N'Phan Tấn Lợi', N'Nam', N'1997', N'089235671662', N'Bến Tre', N'0987541254 ', N'Shipper')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH004', N'LKH01', N'Nguyễn Thị Tú Bình', N'Nữ', N'1987', N'089745619905', N'Tiền Giang', N'0985213465 ', N'Công Nhân (Giày, Dép)')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH005', N'LKH01', N'Nguyễn Thiên Hoàng', N'Nữ', N'1998', N'072347629187', N'Tây Ninh', N'0354689751 ', N'Công Nhân (Thời Vụ)')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH006', N'LKH01', N'Lê Trương Quang Tài', N'Nam', N'1991', N'075929312865', N'Cà Mau', N'0389452178 ', N'Công Nhân (Xây Dựng)')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH007', N'LKH01', N'Võ Thị Châu', N'Nữ', N'1993', N'087225698451', N'Kom Tom', N'0589754812 ', N'Bán Hàng ')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH008', N'LKH01', N'Lê Minh Tuấn Anh', N'Nam', N'1985', N'066901572648', N'Đắk Lắk', N'0784512697 ', N'Công Nhân (Kỹ Thuật)')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH009', N'LKH02', N'Nguyễn Quốc Triều', N'Nam', N'2001', N'070145678992', N'Bình Phước', N'0354879215 ', N'Sinh Viên')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH010', N'LKH02', N'Trần Thị Nguyên', N'Nữ', N'1999', N'042675455122', N'Hà Tĩnh', N'0358974512 ', N'Sinh Viên')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH011', N'LKH02', N'Nguyễn Lâm Nhã Hằng', N'Nữ', N'2003', N'052117642983', N'Bình Định', N'0987415234 ', N'Sinh Viên')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH012', N'LKH02', N'Võ Thị Thúy ', N'Nữ', N'2002', N'036990671245', N'Nam Định', N'0987512468 ', N'Sinh Viên')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH013', N'LKH02', N'Trần Văn Nguyên', N'Nam', N'2001', N'093147823443', N'Hậu Giang', N'0923547895 ', N'Sinh Viên')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH014', N'LKH03', N'Phạm Thanh Anh', N'Nữ', N'1992', N'091255678124', N'Kiên Giang', N'0368794512 ', N'Kế Toán')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH015', N'LKH03', N'Huỳnh Quang Thắng', N'Nam', N'1990', N'086901354734', N'Vĩnh Long', N'0897845135 ', N'Kinh Doanh Bất Động Sản')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH016', N'LKH03', N'Đặng Thị Diễm', N'Nữ', N'1995', N'095153365682', N'Bạc Liêu', N'0987541325 ', N'Quan Hệ Công Chúng')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH017', N'LKH03', N'Trương Da Hân', N'Nữ', N'1989', N'051435425633', N'Quãng Ngãi', N'0541268952 ', N'Marketing')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH018', N'LKH03', N'Phan Uy Lĩnh', N'Nam', N'1983', N'048234645854', N'Đà Nẵng', N'0579247987 ', N'Luật Sư')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH019', N'LKH03', N'Đặng Quốc Toàn', N'Nam', N'1991', N'056365479697', N'Khánh Hòa', N'0231458972 ', N'Lập Trình Viên')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH020', N'LKH03', N'Huỳnh Tấn Phước', N'Nam', N'1993', N'068585626339', N'Lâm Đồng', N'0325418792 ', N'Giáo Viên Thanh Nhạc')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH021', N'LKH03', N'Phan Văn Minh', N'Nam', N'1998', N'023587945123', N'An Giang', N'0389512452 ', N'Sinh viên')
INSERT [dbo].[KhachHang] ([MaKH], [MaLoaiKH], [HovaTenKH], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [SDT], [NgheNghiep]) VALUES (N'KH022', N'LKH03', N'Trần Minh Đức', N'Nam', N'1989', N'021358497521', N'An Giang', N'0397584213 ', N'Kỹ sư điện ')
GO
INSERT [dbo].[LoaiDichVu] ([MaLoaiDV], [TenLoaiDV]) VALUES (N'LDV01', N'Tuỳ chọn')
INSERT [dbo].[LoaiDichVu] ([MaLoaiDV], [TenLoaiDV]) VALUES (N'LDV02', N'Cơ bản')
GO
INSERT [dbo].[LoaiKhachHang] ([MaLoaiKH], [TenLoaiKH]) VALUES (N'LKH01', N'Bình Dân')
INSERT [dbo].[LoaiKhachHang] ([MaLoaiKH], [TenLoaiKH]) VALUES (N'LKH02', N'Sinh Viên')
INSERT [dbo].[LoaiKhachHang] ([MaLoaiKH], [TenLoaiKH]) VALUES (N'LKH03', N'Cao Cấp')
GO
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [DienTichPhong], [MaBG]) VALUES (N'LP01', N'Phòng Bình Dân', 15, N'BG1')
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [DienTichPhong], [MaBG]) VALUES (N'LP02', N'Phòng Sinh Viên', 20, N'BG2')
INSERT [dbo].[LoaiPhong] ([MaLoaiPhong], [TenLoaiPhong], [DienTichPhong], [MaBG]) VALUES (N'LP03', N'Phòng Cao Cấp', 30, N'BG3')
GO
INSERT [dbo].[LoaiThietBi] ([MaLoaiTB], [TenLoaiTB]) VALUES (N'LTB01 ', N'Thiết bị điện, điện tử ')
INSERT [dbo].[LoaiThietBi] ([MaLoaiTB], [TenLoaiTB]) VALUES (N'LTB02 ', N'Thiết bị gia dụng bếp ')
INSERT [dbo].[LoaiThietBi] ([MaLoaiTB], [TenLoaiTB]) VALUES (N'LTB03', N'Thiết bị nội thất ')
GO
INSERT [dbo].[NhanVien] ([MaNV], [HovaTenNV], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [Luong]) VALUES (N'NV001', N'Trần Tuấn Anh', N'Nam', CAST(N'1995-10-25' AS Date), N'074455787133', N'Tây Ninh', 7500000)
INSERT [dbo].[NhanVien] ([MaNV], [HovaTenNV], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [Luong]) VALUES (N'NV002', N'Nguyễn Thị Bích Tuyền', N'Nữ', CAST(N'1996-01-13' AS Date), N'079326541446', N'Hồ Chí Minh', 6000000)
INSERT [dbo].[NhanVien] ([MaNV], [HovaTenNV], [GioiTinh], [NamSinh], [CCCD], [QueQuan], [Luong]) VALUES (N'NV003', N'Lê Thị Thanh Trúc', N'Nữ', CAST(N'1991-05-25' AS Date), N'080455221971', N'Long An', 7000000)
GO
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P01', N'LP01', N'A1', N'A')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P02', N'LP01', N'A2', N'A')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P03', N'LP01', N'A3', N'A')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P04', N'LP01', N'A4', N'A')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P05', N'LP01', N'A5', N'A')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P06', N'LP02', N'B1', N'B')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P07', N'LP02', N'B2', N'B')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P08', N'LP02', N'B3', N'B')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P09', N'LP02', N'B4', N'B')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P10', N'LP02', N'B5', N'B')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P11', N'LP03', N'C1', N'C')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P12', N'LP03', N'C2', N'C')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P13', N'LP03', N'C3', N'C')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P14', N'LP03', N'C4', N'C')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P15', N'LP03', N'C5', N'C')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P16', N'LP03', N'C6', N'C')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P17', N'LP03', N'B6', N'B')
INSERT [dbo].[PhongTro] ([MaPhong], [MaLoaiPhong], [TenPhong], [DayPhong]) VALUES (N'P18', N'LP01', N'A6', N'A')
GO
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT001', N'HDT001', 2750000, CAST(N'2021-02-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT002', N'HDT002', 2954000, CAST(N'2021-02-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT003', N'HDT003', 2765000, CAST(N'2021-02-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT004', N'HDT004', 2840000, CAST(N'2021-02-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT005', N'HDT005', 2845000, CAST(N'2021-02-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT006', N'HDT006', 3840000, CAST(N'2021-02-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT007', N'HDT007', 4010000, CAST(N'2021-02-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT008', N'HDT008', 4200000, CAST(N'2021-02-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT009', N'HDT009', 3978000, CAST(N'2021-02-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT010', N'HDT010', 4100000, CAST(N'2019-02-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT011', N'HDT011', 5890000, CAST(N'2021-02-03T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT012', N'HDT012', 6010000, CAST(N'2021-02-03T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT013', N'HDT001', 2860000, CAST(N'2021-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT014', N'HDT002', 3015000, CAST(N'2021-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT015', N'HDT003', 2801000, CAST(N'2021-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT016', N'HDT004', 2751000, CAST(N'2021-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT017', N'HDT005', 2825000, CAST(N'2021-03-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT018', N'HDT006', 3707000, CAST(N'2021-03-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT019', N'HDT007', 3978000, CAST(N'2021-03-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT020', N'HDT008', 4061000, CAST(N'2021-03-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT021', N'HDT009', 3867000, CAST(N'2021-03-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT022', N'HDT010', 4055000, CAST(N'2019-03-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT023', N'HDT011', 5980000, CAST(N'2021-03-03T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT024', N'HDT012', 6036000, CAST(N'2021-03-03T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT025', N'HDT001', 2953000, CAST(N'2021-04-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT026', N'HDT002', 2945000, CAST(N'2021-04-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT027', N'HDT003', 2705000, CAST(N'2021-04-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT028', N'HDT004', 2732000, CAST(N'2021-04-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT029', N'HDT005', 2878000, CAST(N'2021-04-05T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT030', N'HDT006', 3542000, CAST(N'2021-04-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT031', N'HDT007', 3958000, CAST(N'2021-04-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT032', N'HDT008', 4072000, CAST(N'2021-04-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT033', N'HDT009', 3869000, CAST(N'2021-04-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT034', N'HDT010', 4038000, CAST(N'2019-04-04T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT035', N'HDT011', 5460000, CAST(N'2021-04-03T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT036', N'HDT012', 6083000, CAST(N'2021-04-03T00:00:00.000' AS DateTime))
INSERT [dbo].[SoThuTien] ([MaPhieuThu], [SoHDThue], [SoTienThu], [NgayThu]) VALUES (N'PT037', N'HDT008', 3400000, CAST(N'2021-05-04T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[TaiKhoan] ([TenNguoiDung], [MatKhau]) VALUES (N'admin               ', N'123456              ')
INSERT [dbo].[TaiKhoan] ([TenNguoiDung], [MatKhau]) VALUES (N'nhatro              ', N'123456              ')
INSERT [dbo].[TaiKhoan] ([TenNguoiDung], [MatKhau]) VALUES (N'th123               ', N'123456              ')
GO
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB001', N'LTB01 ', N'Quạt trần KDX', 1350000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB002', N'LTB01', N'Quạt trần KDX', 1350000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB003', N'LTB01', N'Quạt trần KDX', 1350000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB004', N'LTB01', N'Quạt trần KDX', 1350000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB005', N'LTB01', N'Quat trần KDX', 1350000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB006', N'LTB01', N'Quạt đứng Sharp', 999000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB007', N'LTB01', N'Quạt đứng Sharp', 999000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB008', N'LTB01', N'Quạt đứng Sharp', 999000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB009', N'LTB01', N'Quạt đứng Sharp', 999000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB010', N'LTB01', N'Quạt đứng Sharp', 999000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB011', N'LTB01', N'Smart TV Samsung', 14190000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB012', N'LTB01', N'Smart TV Samsung', 14190000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB013', N'LTB01', N'Smart TV Samsung', 14190000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB014', N'LTB01', N'Smart TV Samsung', 14190000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB015', N'LTB01', N'Smart TV Samsung', 14190000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB016', N'LTB01', N'TV LED DARKLING', 3060000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB017', N'LTB01', N'TV LED DARKLING', 3060000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB018', N'LTB01', N'TV LED DARKLING', 3060000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB019', N'LTB01', N'TV LED DARKLING', 3060000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB020', N'LTB01', N'TV LED DARKLING', 3060000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB021', N'LTB01', N'Máy lạnh AQUA Inverter', 9990000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB022', N'LTB01', N'Máy lạnh AQUA Inverter', 9990000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB023', N'LTB01', N'Máy lạnh AQUA Inverter', 9990000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB024', N'LTB01', N'Máy lạnh AQUA Inverter', 9990000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB025', N'LTB01', N'Máy lạnh AQUA Inverter', 9990000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB026', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB027', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB028', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB029', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB030', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB031', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB032', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB033', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB034', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB035', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB036', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB037', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB038', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB039', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB040', N'LTB01', N'Đèn huỳnh quang DDROYAL', 390000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB041', N'LTB01', N'Máy giặt AQUA', 3790000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB042', N'LTB01', N'Máy giặt AQUA', 3790000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB043', N'LTB01', N'Máy giặt AQUA', 3790000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB044', N'LTB01', N'Máy giặt AQUA', 3790000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB045', N'LTB01', N'Máy giặt AQUA', 3790000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB046', N'LTB02', N'Bếp ga đôi Sunhouse', 509000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB047', N'LTB02', N'Bếp ga đôi Sunhouse', 509000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB048', N'LTB02', N'Bếp ga đôi Sunhouse', 509000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB049', N'LTB02', N'Bếp ga đôi Sunhouse', 509000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB050', N'LTB02', N'Bếp ga đôi Sunhouse', 509000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB051', N'LTB02', N'Bếp ga đơn Kiwa', 350000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB052', N'LTB02', N'Bếp ga đơn Kiwa', 350000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB053', N'LTB02', N'Bếp ga đơn Kiwa', 350000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB054', N'LTB02', N'Bếp ga đơn Kiwa', 350000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB055', N'LTB02', N'Bếp ga đơn Kiwa', 350000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB056', N'LTB02', N'Bếp hồng ngoại Sunhouse', 3663000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB057', N'LTB02', N'Bếp hồng ngoại Sunhouse', 3663000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB058', N'LTB02', N'Bếp hồng ngoại Sunhouse', 3663000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB059', N'LTB02', N'Bếp hồng ngoại Sunhouse', 3663000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB060', N'LTB02', N'Bếp hồng ngoại Sunhouse', 3663000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB061', N'LTB02', N'Tủ lạnh AQUA 90L', 2990000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB062', N'LTB02', N'Tủ lạnh AQUA 90L', 2990000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB063', N'LTB02', N'Tủ lạnh AQUA 90L', 2990000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB064', N'LTB02', N'Tủ lạnh AQUA 90L', 2990000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB065', N'LTB02', N'Tủ lạnh AQUA 90L', 2990000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB066', N'LTB02', N'Tủ lạnh Sharp Inverter 150L', 4790000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB067', N'LTB02', N'Tủ lạnh Sharp Inverter 150L', 4790000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB068', N'LTB02', N'Tủ lạnh Sharp Inverter 150L', 4790000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB069', N'LTB02', N'Tủ lạnh Sharp Inverter 150L', 4790000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB070', N'LTB02', N'Tủ lạnh Sharp Inverter 150L', 4790000, 24)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB071', N'LTB03', N'Nệm bông ép', 585000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB072', N'LTB03', N'Nệm bông ép', 585000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB073', N'LTB03', N'Nệm bông ép', 585000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB074', N'LTB03', N'Nệm bông ép', 585000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB075', N'LTB03', N'Nệm bông ép', 585000, 36)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB076', N'LTB03', N'Giường gỗ', 3740000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB077', N'LTB03', N'Giường gỗ', 3740000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB078', N'LTB03', N'Giường gỗ', 3740000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB079', N'LTB03', N'Giường gỗ', 3740000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB080', N'LTB03', N'Giường gỗ', 3740000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB081', N'LTB03', N'Giường sắt đơn', 8500000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB082', N'LTB03', N'Giường sắt đơn', 8500000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB083', N'LTB03', N'Giường sắt đơn', 8500000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB084', N'LTB03', N'Giường sắt đơn', 8500000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB085', N'LTB03', N'Giường sắt đơn', 8500000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB086', N'LTB03', N'Kệ sách gỗ', 699000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB087', N'LTB03', N'Kệ sách gỗ', 699000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB088', N'LTB03', N'Kệ sách gỗ', 699000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB089', N'LTB03', N'Kệ sách gỗ', 699000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB090', N'LTB03', N'Kệ sách gỗ', 699000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB091', N'LTB03', N'Tủ sắt quần áo', 700000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB092', N'LTB03', N'Tủ sắt quần áo', 700000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB093', N'LTB03', N'Tủ sắt quần áo', 700000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB094', N'LTB03', N'Tủ sắt quần áo', 700000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB095', N'LTB03', N'Tủ sắt quần áo', 700000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB096', N'LTB03', N'Tủ gỗ quần áo', 1700000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB097', N'LTB03', N'Tủ gỗ quần áo', 1700000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB098', N'LTB03', N'Tủ gỗ quần áo', 1700000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB099', N'LTB03', N'Tủ gỗ quần áo', 1700000, 12)
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB100', N'LTB03', N'Tủ gỗ quần áo', 1700000, 12)
GO
INSERT [dbo].[ThietBi] ([MaTB], [MaLoaiTB], [TenTB], [Gia], [ThoiGianBaoHanh]) VALUES (N'TB101', N'LTB02 ', N'Ấm đun siêu tốc', 250000, 15)
GO
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB001', N'P15', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB002', N'P07', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB003', N'P08', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB004', N'P09', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB005', N'P01', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB006', N'P02', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB007', N'P03', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB008', N'P04', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB009', N'P05', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB010', N'P10', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB011', N'P12', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB012', N'P13', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB013', N'P14', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB014', N'P15', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB015', N'P01', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB016', N'P02', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB017', N'P03', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB018', N'P04', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB019', N'P05', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB020', N'P11', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB021', N'P12', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB022', N'P13', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB023', N'P14', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB024', N'P15', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB025', N'P01', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB026', N'P02', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB027', N'P03', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB028', N'P04', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB029', N'P05', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB030', N'P06', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB031', N'P07', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB032', N'P08', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB033', N'P09', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB034', N'P10', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB035', N'P11', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB036', N'P12', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB037', N'P13', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB038', N'P14', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB039', N'P15', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB040', N'P11', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB041', N'P12', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB042', N'P13', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB043', N'P14', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB044', N'P15', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB045', N'P01', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB046', N'P02', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB047', N'P03', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB048', N'P04', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB049', N'P05', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB050', N'P06', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB051', N'P07', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB052', N'P08', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB053', N'P09', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB054', N'P10', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB055', N'P11', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB056', N'P12', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB057', N'P13', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB058', N'P14', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB059', N'P15', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB060', N'P01', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB061', N'P02', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB062', N'P03', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB063', N'P04', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB064', N'P05', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB065', N'P11', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB066', N'P12', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB067', N'P13', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB068', N'P14', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB069', N'P15', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB070', N'P01', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB071', N'P02', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB072', N'P03', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB073', N'P04', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB074', N'P05', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB075', N'P11', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB076', N'P12', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB077', N'P13', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB078', N'P14', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB079', N'P15', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB080', N'P06', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB081', N'P07', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB082', N'P08', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB083', N'P09', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB084', N'P10', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB085', N'P06', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB086', N'P07', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB087', N'P08', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB088', N'P09', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB089', N'P10', CAST(N'2020-02-02' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB090', N'P01', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB091', N'P02', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB092', N'P03', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB093', N'P04', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB094', N'P05', CAST(N'2020-02-01' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB095', N'P11', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB096', N'P12', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB097', N'P13', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB098', N'P14', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB099', N'P15', CAST(N'2020-02-03' AS Date))
INSERT [dbo].[TrangBi] ([MaTB], [MaPhong], [NgayTrangBi]) VALUES (N'TB100', N'P11', CAST(N'2020-02-03' AS Date))
GO
ALTER TABLE [dbo].[ChiTietHopDongThuePhong]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHo__MaPho__52593CB8] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PhongTro] ([MaPhong])
GO
ALTER TABLE [dbo].[ChiTietHopDongThuePhong] CHECK CONSTRAINT [FK__ChiTietHo__MaPho__52593CB8]
GO
ALTER TABLE [dbo].[ChiTietHopDongThuePhong]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietHo__SoHDT__534D60F1] FOREIGN KEY([SoHDThue])
REFERENCES [dbo].[HopDongThuePhong] ([SoHDThue])
GO
ALTER TABLE [dbo].[ChiTietHopDongThuePhong] CHECK CONSTRAINT [FK__ChiTietHo__SoHDT__534D60F1]
GO
ALTER TABLE [dbo].[ChiTietSuDungDV]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietSu__SoHDT__6C190EBB] FOREIGN KEY([SoHDThue])
REFERENCES [dbo].[ChiTietHopDongThuePhong] ([SoHDThue])
GO
ALTER TABLE [dbo].[ChiTietSuDungDV] CHECK CONSTRAINT [FK__ChiTietSu__SoHDT__6C190EBB]
GO
ALTER TABLE [dbo].[ChiTietSuDungDV]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietSuD__MaDV__6B24EA82] FOREIGN KEY([MaDV])
REFERENCES [dbo].[DichVu] ([MaDV])
GO
ALTER TABLE [dbo].[ChiTietSuDungDV] CHECK CONSTRAINT [FK__ChiTietSuD__MaDV__6B24EA82]
GO
ALTER TABLE [dbo].[DichVu]  WITH CHECK ADD FOREIGN KEY([MaLoaiDV])
REFERENCES [dbo].[LoaiDichVu] ([MaLoaiDV])
GO
ALTER TABLE [dbo].[HopDongThuePhong]  WITH CHECK ADD  CONSTRAINT [FK__HopDongThu__MaKH__571DF1D5] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[HopDongThuePhong] CHECK CONSTRAINT [FK__HopDongThu__MaKH__571DF1D5]
GO
ALTER TABLE [dbo].[HopDongThuePhong]  WITH CHECK ADD  CONSTRAINT [FK__HopDongThu__MaNV__5812160E] FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[HopDongThuePhong] CHECK CONSTRAINT [FK__HopDongThu__MaNV__5812160E]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK__KhachHang__MaLoa__59063A47] FOREIGN KEY([MaLoaiKH])
REFERENCES [dbo].[LoaiKhachHang] ([MaLoaiKH])
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK__KhachHang__MaLoa__59063A47]
GO
ALTER TABLE [dbo].[LoaiPhong]  WITH CHECK ADD FOREIGN KEY([MaBG])
REFERENCES [dbo].[BangGia] ([MaBG])
GO
ALTER TABLE [dbo].[PhongTro]  WITH CHECK ADD FOREIGN KEY([MaLoaiPhong])
REFERENCES [dbo].[LoaiPhong] ([MaLoaiPhong])
GO
ALTER TABLE [dbo].[SoThuTien]  WITH CHECK ADD FOREIGN KEY([SoHDThue])
REFERENCES [dbo].[HopDongThuePhong] ([SoHDThue])
GO
ALTER TABLE [dbo].[ThietBi]  WITH CHECK ADD  CONSTRAINT [FK__ThietBi__MaLoaiT__5CD6CB2B] FOREIGN KEY([MaLoaiTB])
REFERENCES [dbo].[LoaiThietBi] ([MaLoaiTB])
GO
ALTER TABLE [dbo].[ThietBi] CHECK CONSTRAINT [FK__ThietBi__MaLoaiT__5CD6CB2B]
GO
ALTER TABLE [dbo].[TrangBi]  WITH CHECK ADD FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PhongTro] ([MaPhong])
GO
ALTER TABLE [dbo].[TrangBi]  WITH CHECK ADD  CONSTRAINT [FK__TrangBi__MaTB__5EBF139D] FOREIGN KEY([MaTB])
REFERENCES [dbo].[ThietBi] ([MaTB])
GO
ALTER TABLE [dbo].[TrangBi] CHECK CONSTRAINT [FK__TrangBi__MaTB__5EBF139D]
GO
USE [master]
GO
ALTER DATABASE [QLNhaTro] SET  READ_WRITE 
GO
