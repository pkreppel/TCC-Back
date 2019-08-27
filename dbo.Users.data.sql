
create table [dbo].[Users] 
([Id] int identity, 
[FirstName] varchar(100) not null, 
[LastName] varchar(100) not null, 
[Username] varchar(100) not null, 
[PasswordHash] binary not null, 
[PasswordSalt] binary not null
constraint pk_users primary key (Id)) 

