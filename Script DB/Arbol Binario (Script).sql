Create database ArbolBinario

USE ArbolBinarioDB;
GO

CREATE TABLE Departamento (
    Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    DepartamentoVecino INT NULL,  -- referencia al Id de otro departamento
    Nombre VARCHAR(100) NOT NULL,
    DistanciaCapital INT NOT NULL,
    CantidadMunicipios INT NOT NULL,
    
    CONSTRAINT FK_DepartamentoVecino FOREIGN KEY (DepartamentoVecino) REFERENCES Departamento(Id)
);



CREATE TABLE Municipio (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DepartamentoId INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Poblacion INT NOT NULL,
    DistanciaCabecera INT NOT NULL,
    
    FOREIGN KEY (DepartamentoId) REFERENCES Departamento(Id)
);