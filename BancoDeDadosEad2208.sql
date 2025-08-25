CREATE DATABASE CinemaDB;
GO

USE CinemaDB;
GO

CREATE TABLE Filmes (
    IdFilme INT PRIMARY KEY IDENTITY(1,1),
    Titulo NVARCHAR(100) NOT NULL,
    Genero NVARCHAR(50),
    Ano INT
);

CREATE TABLE Sessoes (
    IdSessao INT PRIMARY KEY IDENTITY(1,1),
    IdFilme INT,
    Data DATE,
    Hora TIME,
    FOREIGN KEY (IdFilme) REFERENCES Filmes(IdFilme) ON DELETE CASCADE
);
SELECT * FROM Filmes
