USE [prueba]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 18/06/2023 01:36:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellidos] [nvarchar](50) NULL,
	[Curp] [nvarchar](50) NULL,
 CONSTRAINT [PK_Alumnos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maestros]    Script Date: 18/06/2023 01:36:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maestros](
	[maestroId] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Maestros__07C1FA10FA7D9FEE] PRIMARY KEY CLUSTERED 
(
	[maestroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materias]    Script Date: 18/06/2023 01:36:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materias](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[maestroId] [int] NULL,
 CONSTRAINT [PK_Materias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[elimina]    Script Date: 18/06/2023 01:36:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create procedure [dbo].[elimina](
@Id int
)
as begin

delete from Alumnos where Id = @Id

end

GO
/****** Object:  StoredProcedure [dbo].[nuevo]    Script Date: 18/06/2023 01:36:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[nuevo](
@Nombre varchar(50),
@Apellidos varchar(50),
@Curp varchar(50)
)
as begin 
insert into Alumnos(Nombre, Apellidos, Curp) 
values
(
@Nombre,
@Apellidos,
@Curp)
end

GO
