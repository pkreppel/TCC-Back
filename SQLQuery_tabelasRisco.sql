
create TABLE TipoRisco(
	TipoRiscoID int identity,
	NomeTipoRisco varchar(max) not null,
	Criticidade varchar(max) not null,
	LocalTipoRisco varchar(max) not null,
	constraint PK_TIPORISCO primary key (TipoRiscoID)
)
insert into TipoRisco(NomeTipoRisco, Criticidade, LocalTipoRisco)
values('Tipo Risco 1', 'Criticidade 1', 'Local 1' )
insert into TipoRisco(NomeTipoRisco, Criticidade, LocalTipoRisco)
values('Tipo Risco 2', 'Criticidade 2', 'Local 2' )
insert into TipoRisco(NomeTipoRisco, Criticidade, LocalTipoRisco)
values('Tipo Risco 3', 'Criticidade 3', 'Local 3' )

create TABLE Risco(
	RiscoID int identity,
	TipoRiscoID int not null,
	DescricaoRisco varchar(max) not null,
	DataCadastro datetime not null constraint DF_RISCO default getdate()
	constraint PK_RISCO primary key (RiscoID)
	CONSTRAINT [FK_RISCO_TIPORISCO] FOREIGN KEY (TipoRiscoID) REFERENCES TipoRisco (TipoRiscoID)
)

insert into Risco(TipoRiscoID, DescricaoRisco)
values(1,'Infiltração na barragem')
insert into Risco(TipoRiscoID, DescricaoRisco)
values(2,'Sensores de vídeo parados')
insert into Risco(TipoRiscoID, DescricaoRisco)
values(2,'Sensor A permanece parado')
insert into Risco(TipoRiscoID, DescricaoRisco)
values(1,'Sirene quebrada')
insert into Risco(TipoRiscoID, DescricaoRisco)
values(2,'Teste Risco')


create table SensoresBarragem(
	SensorID int identity,
	TipoSensor int not null,
	ValorSensor float not null,
	HoraMonitoramento datetime not null default getdate()
	constraint PK_SENSORES primary key (SensorID)
)

