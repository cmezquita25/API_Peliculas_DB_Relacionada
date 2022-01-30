create table Peliculas (
    Id int identity(1,1) not null,
    Titulo VARCHAR(500) not null,
    Puntuacion INT not null,
    Rating DECIMAL(4,1) not null,
    Fecha_Publicacion VARCHAR(50) not null,

 

    CONSTRAINT PK_IDPELICULAS PRIMARY KEY(Id)
);


Create table Genero(
IdGenero int identity(1,1) not null,
Genero varchar(50) not null,
IdPelicula int not null,
 

CONSTRAINT PK_IDGENERO PRIMARY KEY(IdGenero),
CONSTRAINT FK_IDPELICULA FOREIGN KEY(IdPelicula) REFERENCES Peliculas(Id)
);


Create table Director(
IdDirector int identity(1,1) not null,
Nombre varchar(500) not null,
IdPelicula int not null,
 

CONSTRAINT PK_DIRECTOR_ID PRIMARY KEY(IdDirector),
CONSTRAINT FK_IDPELIDirector FOREIGN KEY(IdPelicula) REFERENCES Peliculas(Id)
);

