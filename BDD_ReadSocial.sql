-- Crear la base de datos
CREATE DATABASE ReadSocialForum;

USE ReadSocialForum;

-- Crear tabla para Threads
CREATE TABLE Threads (
    ThreadId INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Crear tabla para Posts
CREATE TABLE Posts (
    PostId INT PRIMARY KEY IDENTITY,
    ThreadId INT NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    Author NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ThreadId) REFERENCES Threads(ThreadId) ON DELETE CASCADE
);
