CREATE TABLE [User](
    [userId]        [INT]        IDENTITY(1,1),
    [name]          [VARCHAR]            (50)     NOT NULL,
    [lastName]      [VARCHAR]            (50)     NOT NULL,
    [email]         [VARCHAR]            (100)    NOT NULL UNIQUE,
    [status]        [TINYINT]                     NOT NULL DEFAULT 1,
    [dateRegister]  [DATETIME]                    NOT NULL DEFAULT GETDATE(),
    [rolId]         [INT]                         NOT NULL,
    CONSTRAINT PK_user PRIMARY KEY(userId),
    CHECK(status in(1, 0)),
    FOREIGN KEY(rolId) REFERENCES Rol(rolId)
);

CREATE TABLE [Rol](
    rolId INT IDENTITY(1,1),
    name VARCHAR(50) NOT NULL UNIQUE,
    CONSTRAINT PK_rol PRIMARY KEY(rolId)
);

select * from [Rol];

INSERT INTO [Rol]
VALUES('admin'),('usuario');

INSERT INTO [User](name, lastName,email,rolId)
VALUES('juan','perez','juan.com', 4);

select * from [User];

select us.name , ro.name from [User] us
INNER JOIN [Rol] ro
on us.rolId = ro.rolId;
