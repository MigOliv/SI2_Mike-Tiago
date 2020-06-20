use TP1
set nocount on
set xact_abort on
begin tran

if OBJECT_ID('Inscricao') is not null
	drop table Inscricao

if OBJECT_ID('ConclusaoCurso') is not null
	drop table ConclusaoCurso

if OBJECT_ID('Matricula') is not null
	drop table Matricula

if OBJECT_ID('SemestreLetivo') is not null
	drop table SemestreLetivo

if OBJECT_ID('UC_Semestre') is not null
	drop table UC_Semestre

if OBJECT_ID('Semestre') is not null
	drop table Semestre

if OBJECT_ID('RegenteUC') is not null
	drop table RegenteUC

if OBJECT_ID('Professor_UC') is not null
	drop table Professor_UC

if OBJECT_ID('UnidadeCurricular') is not null
	drop table UnidadeCurricular

if OBJECT_ID('CoordenadorSeccao') is not null
	drop table CoordenadorSeccao

if OBJECT_ID('Professor') is not null
	drop table Professor

if OBJECT_ID('Curso') is not null
	drop table Curso

if OBJECT_ID('Seccao') is not null
	drop table Seccao

if OBJECT_ID('Ano') is not null
	drop table Ano

if OBJECT_ID('Aluno') is not null
	drop table Aluno

if OBJECT_ID('Departamento') is not null
	drop table Departamento

go

create table Departamento(
	sigla char(6) primary key,
	descricao VARCHAR(2500)
)

create table Aluno(
	num int primary key,
	cc numeric(8) not null unique,
	nome varchar(255) not null,
	rua varchar(255),
	n varchar(10),
	andar varchar(10),
	codPostal char(8),
	dataNascimento date
)

create table Ano(
	ano numeric(4) primary key
)

create table Seccao(
	sigla char(6),
	siglaDepartamento char(6),
	descricao varchar(2500),
	primary key(siglaDepartamento, sigla),
	foreign key (siglaDepartamento) references Departamento(sigla) ON DELETE CASCADE
)

create table Curso(
	sigla char(6) primary key,
	descricao varchar(255),
	siglaDepartamento char(6),
	totalCreditos numeric(3),
	foreign key (siglaDepartamento) references Departamento(sigla) ON DELETE CASCADE
)

create table Professor(
	cc numeric(8) primary key,
	nome varchar(255) not null,
	areaEspecializacao varchar(255),
	categoria varchar(255),
	siglaDepartamento char(6),
	siglaSeccao char(6),
	foreign key (siglaDepartamento, siglaSeccao) references Seccao(siglaDepartamento, sigla) ON DELETE CASCADE
)

create table CoordenadorSeccao(
	siglaSeccao char(6),
	ccProfessor numeric(8) references Professor(cc),
	siglaDepartamento char(6),
	primary key(ccProfessor),
	foreign key (siglaDepartamento, siglaSeccao) references Seccao(siglaDepartamento, sigla) ON DELETE CASCADE,
	
)

create table UnidadeCurricular(
	sigla char(6) primary key,
	descricao varchar(255),
	numCreditos numeric(3,1),
	Versio RowVersion
)

create table Semestre(
	numSemestre numeric(1) not null check(numSemestre >= 1 AND numSemestre <= 6),
	siglaCurso char(6) not null references Curso(sigla) ON DELETE CASCADE,
	unique(numSemestre, siglaCurso)
)

create table UC_Semestre(
	numSemestre numeric(1) not null check(numSemestre >= 1 AND numSemestre <= 6),
	siglaCurso char(6) not null references Curso(sigla) ON DELETE CASCADE,
	siglaUC char(6) not null references UnidadeCurricular(sigla) ON DELETE CASCADE,
	ano numeric(4) not null references Ano(ano) ON DELETE CASCADE,
	primary key(siglaCurso, siglaUC, ano)
)

create table Professor_UC(
	ccProfessor numeric(8) not null references Professor(cc) ON DELETE CASCADE,
	siglaUC char(6) not null references UnidadeCurricular(sigla) ON DELETE CASCADE,
	ano numeric(4) not null references Ano(ano) ON DELETE CASCADE,
	primary key(ccProfessor, siglaUC, ano)
)

create table RegenteUC(
	ccProfessor numeric(8) not null references Professor(cc) ON DELETE CASCADE,
	siglaUC char(6) not null references UnidadeCurricular(sigla) ON DELETE CASCADE,
	ano numeric(4) not null references Ano(ano) ON DELETE CASCADE,
	primary key(siglaUC, ano)
)

create table SemestreLetivo(
	sigla char(6) not null,
	ano numeric(4) not null references Ano(ano) ON DELETE CASCADE,
	descricao varchar(255),
	primary key(sigla, ano)
)

create table Matricula(
	numAluno int not null references Aluno(num) ON DELETE CASCADE,
	siglaCurso char(6) not null references Curso(sigla) ON DELETE CASCADE,
	ano numeric(4) not null references Ano(ano) ON DELETE CASCADE,
	unique(numAluno, ano)
)

create table ConclusaoCurso(
	numAluno int not null,
	siglaCurso char(6) not null references Curso(sigla),
	notaFinal numeric(3,1),
	ano numeric(4) not null,
	foreign key (numAluno, ano) references Matricula(numAluno, ano) ON DELETE CASCADE,
	primary key(numAluno, siglaCurso)
)

create table Inscricao(
	numAluno int,
	siglaCurso char(6) references Curso(sigla),
	siglaSemestreLetivo char(6),
	ano numeric(4),
	siglaUC char(6) references UnidadeCurricular(sigla),
	nota numeric(3,1) check(nota >= 0 AND nota <= 20),
	foreign key (numALuno, ano) references Matricula(numAluno, ano) ON DELETE CASCADE,
	foreign key (siglaSemestreLetivo, ano) references SemestreLetivo(sigla, ano),
	primary key(numAluno, siglaCurso, siglaSemestreLetivo, ano, siglaUC)
)


-- inserir Departamentos
insert into Departamento values ('ADEC', 'Area Departamental de Engenharia Civil')
insert into Departamento values ('ADEETC', 'Area Departamental de Engenharia Eletronica e Telecomunicacoes e de Computadores')
insert into Departamento values ('ADEEEA', 'Area Departamental de Engenharia Eletrotecnica de Energia e Automacao')
insert into Departamento values ('ADEM', 'Area Departamental de Engenharia Mecanica')
insert into Departamento values ('ADEQ', 'Area Departamental de Engenharia Quimica')
insert into Departamento values ('ADF', 'Area Departamental de Fisica')
insert into Departamento values ('ADM', 'Area Departamental de Matematica')

-- inserir Alunos
insert into Aluno values (39156, 16278473, 'Miguel Oliveira', 'Rua do Mike', 3, '1D', '1234-123', '1990-01-16')
insert into Aluno values (40623, 95837284, 'Tiago Fernandes', 'Rua do Tigas', 23, '9D', '4837-223', '1995-09-22')
insert into Aluno values (40606, 57687980, 'Goncalo Antunes', 'Rua do Esgonca', 42, '5A', '1937-557', '1993-10-05')
insert into Aluno values (22656, 38573299, 'Jose Carlos', 'Rua do Zeca', 9, '4B', '1234-123', '1986-01-24')
insert into Aluno values (45938, 83738272, 'Jorge Jesus', 'Avenida do Jorginho', 36, '2C', '6734-664', '1995-11-29')
insert into Aluno values (38285, 12345678, 'Tiago Dias', 'Rua Dr. Tiago Flores', 4, '6E', '7374-222', '1993-07-22')

-- inserir Ano
insert into Ano values (1617)
insert into Ano values (1718)
insert into Ano values (1819)
insert into Ano values (1920)

-- inserir Seccao
insert into Seccao values ('SEC', 'ADEC', 'Secção de Estruturas e Construção')
insert into Seccao values ('SGTVH', 'ADEC', 'Secção de Geotecnia, Transportes, Vias de Comunicação e Hidráulica')
insert into Seccao values ('SETC', 'ADEETC', 'Secção de Electrónica e Telecomunicações e de Computadores')
insert into Seccao values ('SECS', 'ADEM', 'Secção de Energia e Controlo de Sistemas')
insert into Seccao values ('SPMPMI', 'ADEM', 'Secção de Projecto Mecanico, Producao e Manutencao Industrial')
insert into Seccao values ('SAE', 'ADEQ', 'Secção de Ambiente e Energia')
insert into Seccao values ('SB', 'ADEQ', 'Secção de Bioengenharia')
insert into Seccao values ('SQFA', 'ADEQ', 'Secção de Química Física e Análise')
insert into Seccao values ('SQOI', 'ADEQ', 'Secção de Química Orgânica e Inorgânica')
insert into Seccao values ('SSG', 'ADEQ', 'Secção de Sistemas e Gestão')
insert into Seccao values ('STQ', 'ADEQ', 'Secção de Tecnologia Química')
insert into Seccao values ('SA', 'ADM', 'Secção de Algebra')
insert into Seccao values ('SAMAN', 'ADM', 'Secção de Análise Matemática e Análise numérica')
insert into Seccao values ('SPEIO', 'ADM', 'Secção de Probabilidades, Estatística e Investigação operacional ')

-- inserir Curso
insert into Curso values ('LEC', 'Licenciatura em Engenharia Civil', 'ADEC', 180)
insert into Curso values ('LTGM', 'Licenciatura em Tecnologias e Gestão Municipal', 'ADEC', 180)
insert into Curso values ('LEETC', 'Licenciatura em Engenharia Electrónica e Telecomunicações e de Computadores', 'ADEETC', 180)
insert into Curso values ('LEIC', 'Licenciatura em Engenharia Informática e de Computadores', 'ADEETC', 180)
insert into Curso values ('LEIM', 'Licenciatura em Engenharia Informática e Multimédia', 'ADEETC', 180)
insert into Curso values ('LEIRT', 'Licenciatura em Engenharia Informática, Redes e Telecomunicações', 'ADEETC', 180)
insert into Curso values ('LEE', 'Licenciatura em Engenharia Eletrotécnica', 'ADEEEA', 180)
insert into Curso values ('LEM', 'Licenciatura em Engenharia Mecânica', 'ADEM', 180)
insert into Curso values ('LEB', 'Licenciatura em Engenharia Biomédica', 'ADEQ', 180)
insert into Curso values ('LEQB', 'Licenciatura em Engenharia Química e Biológica', 'ADEQ', 180)
insert into Curso values ('CPF', 'Curso Preparatório de Física', 'ADF', 180)
insert into Curso values ('LMATE', 'Matemática Aplicada à Tecnologia e à Empresa', 'ADM', 180)

-- inserir Professor
insert into Professor values (28493827, 'Afonso Remedios', 'Sistemas de Informacao', 'Professor Universitario', 'ADEETC', 'SETC')
insert into Professor values (77338842, 'Nuno Leite', 'Ambientes Virtuais', 'Professor Universitario', 'ADEETC', 'SETC')
insert into Professor values (66337281, 'Jorge Martins', 'Sistemas Operativos', 'Professor Universitario', 'ADEETC', 'SETC')
insert into Professor values (74837829, 'Carlos Martins', 'Sistemas Computacionais', 'Professor Universitario', 'ADEETC', 'SETC')

-- inserir Coordenador de Seccao
insert into CoordenadorSeccao values ('SETC', 28493827, 'ADEETC')

--inserir Unidade Curricular
insert into UnidadeCurricular (sigla, descricao, numCreditos) values ('PG', 'Programacao', 6)
insert into UnidadeCurricular (sigla, descricao, numCreditos) values ('POO', 'Programacao Orientada por Objectos', 6)
insert into UnidadeCurricular (sigla, descricao, numCreditos) values ('PS', 'Projecto e Seminario', 18)
insert into UnidadeCurricular (sigla, descricao, numCreditos) values ('SI2', 'Sistemas de Informacao 2', 6)
insert into UnidadeCurricular (sigla, descricao, numCreditos) values ('AVE', 'Ambientes Virtuais de Execucao', 6)
insert into UnidadeCurricular (sigla, descricao, numCreditos) values ('SO', 'Sistemas Operativos', 6)
insert into UnidadeCurricular (sigla, descricao, numCreditos) values ('PSC', 'Programacao em Sistemas Computacionais', 6)
insert into UnidadeCurricular (sigla, descricao, numCreditos) values ('PC', 'Programacao Concorrente', 6)
insert into UnidadeCurricular (sigla, descricao, numCreditos) values ('LS', 'Laboratorio de Software', 6)

-- inserir Regente da Unidade Curricular
insert into RegenteUC values (28493827, 'SI2', 1920)
insert into RegenteUC values (77338842, 'AVE', 1920)
insert into RegenteUC values (77338842, 'AVE', 1819)
insert into RegenteUC values (77338842, 'SI2', 1819)

-- inserir Semestre
insert into Semestre values (1, 'LEIC')
insert into Semestre values (2, 'LEIC')
insert into Semestre values (3, 'LEIC')
insert into Semestre values (4, 'LEIC')
insert into Semestre values (5, 'LEIC')
insert into Semestre values (6, 'LEIC')

-- inserir UC_Semestre
insert into UC_Semestre values (1, 'LEIC', 'PG', 1920)
insert into UC_Semestre values (2, 'LEIC', 'POO', 1920)
insert into UC_Semestre values (3, 'LEIC', 'PSC', 1920)
insert into UC_Semestre values (4, 'LEIC', 'SO', 1920)
insert into UC_Semestre values (4, 'LEIC', 'AVE', 1920)
insert into UC_Semestre values (5, 'LEIC', 'SI2', 1920)
insert into UC_Semestre values (6, 'LEIC', 'PS', 1920)

-- inserir SemestreLetivo
insert into SemestreLetivo values ('SI', 1920, 'Semestre de Inverno')
insert into SemestreLetivo values ('SV', 1920, 'Semestre de Verao')
insert into SemestreLetivo values ('SI', 1819, 'Semestre de Inverno')
insert into SemestreLetivo values ('SV', 1819, 'Semestre de Verao')

-- inserir Matricula
insert into Matricula values (39156, 'LEIC', 1920)
insert into Matricula values (40623, 'LEIC', 1920)
insert into Matricula values (40606, 'LEIC', 1920)
insert into Matricula values (40623, 'LEIC', 1819)
insert into Matricula values (40606, 'LEIC', 1819)



-- inserir Inscricao
insert into Inscricao values (39156, 'LEIC', 'SV', 1920, 'SI2', null)
insert into Inscricao values (40623, 'LEIC', 'SV', 1920, 'SI2', null)
insert into Inscricao values (40606, 'LEIC', 'SV', 1920, 'SI2', null)
insert into Inscricao values (40606, 'LEIC', 'SV', 1819, 'SI2', null)
insert into Inscricao values (39156, 'LEIC', 'SV', 1920, 'SO', null)




select * from UnidadeCurricular

commit