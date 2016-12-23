drop table member cascade constraint;
drop table hakakses cascade constraint;
drop table barang cascade constraint;
drop table harga cascade constraint;
drop table transaksi cascade constraint;
drop table mesin cascade constraint;
drop table historymesin cascade constraint;
drop table stok cascade constraint;


create table member
(
 idmember VARCHAR2(50) CONSTRAINT PK_MEMBER PRIMARY KEY,
 nama VARCHAR2(20),
 alamat VARCHAR2(30),
 telp VARCHAR2(7),
 tgllahir date,
 jk VARCHAR2(7)
);

create table hakakses
(
 iduser VARCHAR2(20) CONSTRAINT PK_HAKAKSES PRIMARY KEY,
 fitur VARCHAR2(10)
);

create table barang(
	idbarang VARCHAR2(10) CONSTRAINT PK_ID_BARANG PRIMARY KEY,
	namabarang VARCHAR2(15)
);

create table stok(
	idstok VARCHAR2(10) CONSTRAINT PK_STOK PRIMARY KEY,
	nama VARCHAR2(20),
	jenisstok VARCHAR2(30),
	jumlahstok number(10)
);

create table harga(
	cb number(10),
	ck number(10),
	cs number(10),
	laundry number(10),
	disc number(10)
);
create table transaksi(
	kodetrans varchar2(25),
	iduser varchar2(50),
	idmember varchar2(20),
	idbarang varchar2(10),
	tglmasuk date,
	kategorilaundry varchar2(15),
	tipelaundry varchar2(15),
	namacucian varchar2(50),
	berat number(5),
	pewangi varchar2(15),
	tglselesai date,
	lainnya varchar2(200),
	total number(10),
	bayar number(10),
	status_bayar varchar2(25),
	status_cucian varchar2(25),
	statustrans varchar2(50),
	constraint pk_transaksi primary key(kodetrans),
	constraint fk1_transaksi_member foreign key (idmember) references member(idmember) deferrable initially deferred,
	constraint fk2_transaksi_hakakses foreign key (iduser) references hakakses(iduser)
);
CREATE TABLE mesin(
	idmesin varchar(10) CONSTRAINT PK_MESIN PRIMARY KEY,
	nama varchar(20),
	nomermesin varchar(20),
	jenis varchar(20),
	catatan varchar(20)
);

CREATE TABLE historymesin(
	idperbaikan varchar(20) CONSTRAINT PK_HISTORYMESIN PRIMARY KEY,
	idmesin varchar(10),
	masalah varchar(20),
	tanggalperbaikan varchar(20),
	perbaikan varchar(20),
	biaya number(20),
	lokasi varchar(20),
	constraint fk1_mesin_history foreign key (idmesin) references mesin(idmesin) deferrable initially deferred
);

INSERT INTO BARANG VALUES ('D01', 'RINSO MATIC');
INSERT INTO BARANG VALUES ('PWG01', 'LAVENDER');
INSERT INTO BARANG VALUES ('PWG02', 'ROSE');
INSERT INTO BARANG VALUES ('PWG03', 'GREEN TEA');

INSERT INTO HARGA VALUES (6000,9000,12000,15000,20);

INSERT INTO hakakses VALUES ('adminlaundry','admin');
INSERT INTO hakakses VALUES ('userlaundry1','user');
INSERT INTO hakakses VALUES ('userlaundry2','user');

INSERT INTO MEMBER VALUES ('Non Member','Non Member','Non Member',12345,TO_DATE('25-11-2010','dd/mm/yyyy'),'PRIA');
INSERT INTO historymesin (idperbaikan, idmesin, masalah, tanggalperbaikan, perbaikan, biaya, lokasi) values ('16121101', 'SA001', 'tes',TO_DATE('25-11-2010','dd/mm/yyyy'),'tes', '123', 'sby' )

commit;