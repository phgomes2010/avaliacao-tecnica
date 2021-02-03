CREATE TABLE Departamento (
    Id INT PRIMARY KEY,
    Nome varchar(255)
);

CREATE TABLE Pessoa (
    Id INT PRIMARY KEY,
    Nome varchar(255),
    Salario NUMERIC(10, 2),
    DeptId INT,
	FOREIGN KEY (DeptId) REFERENCES Departamento(Id)
);

insert into Departamento values (1, 'TI')
insert into Departamento values (2, 'Vendas')

insert into Pessoa(Id, Nome, Salario, DeptId) values (1, 'Joe', 70000, 1)
insert into Pessoa(Id, Nome, Salario, DeptId) values (2, 'Henry', 80000, 2)
insert into Pessoa(Id, Nome, Salario, DeptId) values (3, 'Sam', 60000, 2)
insert into Pessoa(Id, Nome, Salario, DeptId) values (4, 'Max', 90000, 1)

SELECT d.Nome as Departamento, p.Nome as Pessoa, MaxSalaries.Salario
FROM Pessoa p
JOIN (
	SELECT DeptId, MAX(Salario) AS Salario
	FROM Pessoa
	GROUP BY DeptId
) AS MaxSalaries ON p.DeptId = MaxSalaries.DeptId AND p.Salario = MaxSalaries.Salario
JOIN Departamento d on d.Id = p.DeptId
ORDER BY MaxSalaries.Salario DESC