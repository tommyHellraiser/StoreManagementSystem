create table users(
	ID int primary key,
	name varchar(20) not null,
	last_name varchar(20) not null,
	document varchar(15) not null,
	username varchar(20) not null,
	pass varchar(30) not null,
	level tinyint default 0,	/* 0: employee, 1: admin, 2: business owner */
	created_at datetime not null default CURRENT_TIMESTAMP,
	deleted_at datetime default null
);

create table items(
	ID int primary key,
	name varchar(30) not null,
	barcode bigint not null,
	amount int not null,
	price float not null,
	created_at datetime not null default CURRENT_TIMESTAMP,
	deleted_at datetime default null
);

create table sale_logs(
	ID int primary key,
	user_ID int not null,
	total_amount float not null,
	created_at datetime not null default CURRENT_TIMESTAMP,
	deleted_at datetime default null,
	foreign key (user_ID) references users(ID)
);

create table item_sale_logs(
	ID int primary key,
	sale_logs_ID int not null,
	item_ID int not null,
	item_amount int not null,
	created_at datetime not null default CURRENT_TIMESTAMP,
	deleted_at datetime default null,
	foreign key (sale_logs_ID) references sale_logs(ID),
	foreign key (item_ID) references items(ID)
);

create table balances(
	ID int primary key,
	user_ID int not null,
	withdrawal_amount float not null,
	created_at datetime not null default CURRENT_TIMESTAMP,
	deleted_at datetime default null,
	foreign key (user_ID) references users(ID)
);