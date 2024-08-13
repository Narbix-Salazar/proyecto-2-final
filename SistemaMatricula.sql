CREATE DATABASE SistemaMatricula;
USE SistemaMatricula;

CREATE TABLE Admini (
    usuario VARCHAR(100) PRIMARY KEY,
    contrase�a VARCHAR(100) NOT NULL UNIQUE,
);
GO

CREATE TABLE Estudiantes (
    usuario INT PRIMARY KEY,
    contrase�a VARCHAR(255)
);
GO

CREATE TABLE ExpedienteEstudiantes (
    cedula INT NOT NULL PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    Telefono INT NOT NULL,
    PersonaEmergencia VARCHAR(100) NOT NULL,
    Provincia VARCHAR(50) NOT NULL,
    Canton VARCHAR(50) NOT NULL,
    Distrito VARCHAR(50) NOT NULL,
    Direccion VARCHAR(255) NOT NULL,
    GradoAcademico VARCHAR(50) NOT NULL,
    Institucion VARCHAR(50) NOT NULL,
    NivelEducacion VARCHAR(50) NOT NULL,
    FacultadBachiller VARCHAR(100) NOT NULL,
    Carreras VARCHAR(255) NOT NULL,
    FOREIGN KEY (cedula) REFERENCES Estudiantes(usuario)
);
GO

CREATE TABLE Materias (
    MateriaID INT PRIMARY KEY ,
    NombreMateria VARCHAR(100),
    Hora TIME,
    Profesor VARCHAR(100),
    Modalidad VARCHAR(50) NOT NULL,
    DireccionAcademica VARCHAR(255),
    InicioLecciones DATE
);
GO

CREATE TABLE Matriculas (
    MatriculaID INT PRIMARY KEY IDENTITY(1,1),
    cedula INT,
    MateriaID INT,
    FechaMatricula DATE NOT NULL,
    FOREIGN KEY (cedula) REFERENCES Estudiantes(usuario),
    FOREIGN KEY (MateriaID) REFERENCES Materias(MateriaID)
);
GO

CREATE TRIGGER trg_CheckFechaMatricula
ON Matriculas
AFTER INSERT
AS
BEGIN
    -- Verificar si la fecha de matr�cula es posterior al inicio de lecciones
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN Materias m ON i.MateriaID = m.MateriaID
        WHERE i.FechaMatricula > m.InicioLecciones
    )
    BEGIN
        -- Generar un error si la validaci�n falla
        RAISERROR('La fecha de matr�cula no puede ser posterior al inicio de las lecciones.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;


INSERT INTO Admini (usuario, contrase�a) VALUES
('admin1', 'admin1');
SELECT * FROM Admini;

INSERT INTO Estudiantes (usuario, contrase�a) VALUES
(101, 'juan1'),
(102, 'ana2');
SELECT * FROM Estudiantes;

INSERT INTO ExpedienteEstudiantes (cedula, Nombre, Apellido, FechaNacimiento, Telefono, PersonaEmergencia, Provincia, Canton, Distrito, Direccion, GradoAcademico, Institucion, NivelEducacion, FacultadBachiller, Carreras) VALUES
(101, 'Juan', 'P�rez', '2000-01-15', 12345678, 'Maria P�rez', 'San Jos�', 'Central', 'Carmen', 'Calle 1, Avenida 2', 'Bachillerato', 'Colegio Nacional', 'Bachiller', 'Facultad de Ciencias', 'Administracion'),
(102, 'Ana', 'G�mez', '1999-05-22', 87654321, 'Luis G�mez', 'Alajuela', 'Alajuela', 'San Jos�', 'Calle 3, Avenida 4', 'Licenciatura', 'Universidad Estatal', 'Tecnico', 'Facultad de Humanidades', 'Humanidades');
SELECT * FROM ExpedienteEstudiantes;


INSERT INTO Materias (MateriaID, NombreMateria, Hora, Profesor, Modalidad, DireccionAcademica, InicioLecciones) VALUES
(10101, 'Matem�ticas', '08:00:00', 'Prof. Rodr�guez', 'Presencial', 'Facultad de Ciencias', '2024-09-01'),
(10102, 'Comunicaci�n', '10:00:00', 'Prof. Garc�a', 'Virtual', 'Facultad de Humanidades', '2024-09-05');
SELECT * FROM Materias;


INSERT INTO Matriculas (cedula, MateriaID, FechaMatricula) VALUES
(101, 10101, '2024-08-20'), -- Matr�cula antes del inicio de clases
(102, 10102, '2024-08-22'); 

INSERT INTO Matriculas (cedula, MateriaID, FechaMatricula)
VALUES (101, 10101, '2024-09-21');

SELECT 
    Estudiantes.usuario, 
    ExpedienteEstudiantes.Nombre, 
    Materias.NombreMateria, 
    Matriculas.FechaMatricula
FROM 
    Matriculas
JOIN 
    Estudiantes ON Matriculas.cedula = Estudiantes.usuario
JOIN 
    Materias ON Matriculas.MateriaID = Materias.MateriaID
JOIN 
    ExpedienteEstudiantes ON Estudiantes.usuario = ExpedienteEstudiantes.cedula;

