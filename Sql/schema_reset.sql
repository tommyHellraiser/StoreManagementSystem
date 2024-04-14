/* Delete tables */
drop table if exists balances;
drop table if exists item_sale_logs;
drop table if exists sale_logs;
drop table if exists items;
drop table if exists users;


/* Create tables */
create table users(
	ID int identity primary key,
	name varchar(20) not null,
	last_name varchar(20) not null,
	document varchar(15) not null,
	username varchar(20) not null,
	pass varchar(70) not null,
	level tinyint default 0,	/* 0: employee, 1: admin, 2: business owner */
	created_at datetime not null default CURRENT_TIMESTAMP,
	deleted_at datetime default null
);

create table items(
	ID int identity primary key,
	name varchar(50) not null,
	barcode bigint not null,
	amount int not null,
	price float not null,
	created_at datetime not null default CURRENT_TIMESTAMP,
	deleted_at datetime default null
);

create table sale_logs(
	ID int identity primary key,
	user_ID int not null,
	total_amount float not null,
	created_at datetime not null default CURRENT_TIMESTAMP,
	deleted_at datetime default null,
	foreign key (user_ID) references users(ID)
);

create table item_sale_logs(
	ID int identity primary key,
	sale_logs_ID int not null,
	item_ID int not null,
	item_amount int not null,
	created_at datetime not null default CURRENT_TIMESTAMP,
	deleted_at datetime default null,
	foreign key (sale_logs_ID) references sale_logs(ID),
	foreign key (item_ID) references items(ID)
);

create table balances(
	ID int identity primary key,
	user_ID int not null,
	withdrawal_amount float not null,
	created_at datetime not null default CURRENT_TIMESTAMP,
	deleted_at datetime default null,
	foreign key (user_ID) references users(ID)
);


/* Insert initial data */
insert into users(name, last_name, document, username, pass, level)
values('Tomas', 'Ponce', '38416584', 'tommyHellraiser', 'e28781dfc2c31e36257efb7ea8f1d3923dedabe74a566b908fac38292a0ceb04', 2);

insert into items(name, barcode, amount, price)
values
('Kelloggs Corn Flakes', '123456789012', 50, 3.99),
('Heinz Tomato Ketchup', '234567890123', 30, 2.49),
('Barilla Spaghetti', '345678901234', 40, 1.79),
('Coca-Cola', '456789012345', 50, 1.99),
('Philadelphia Cream Cheese', '567890123456', 20, 4.29),
('Quaker Oats', '678901234567', 25, 5.49),
('Tropicana Orange Juice', '789012345678', 30, 3.49),
('Bumble Bee Tuna', '890123456789', 40, 1.99),
('Hellmanns Mayonnaise', '901234567890', 20, 3.29),
('Kraft Macaroni & Cheese', '012345678901', 50, 0.99),
('Nestle Chocolate Chips', '123456789012', 30, 2.79),
('Campbells Tomato Soup', '234567890123', 40, 1.29),
('Dove Bar Soap', '345678901234', 50, 4.99),
('Johnsonville Sausages', '456789012345', 30, 5.49),
('Folgers Coffee', '567890123456', 20, 6.99),
('Green Giant Frozen Vegetables', '678901234567', 40, 2.19),
('Haagen-Dazs Ice Cream', '789012345678', 20, 4.99),
('Lipton Green Tea Bags', '890123456789', 30, 3.79),
('Colgate Toothpaste', '901234567890', 40, 2.99),
('Del Monte Canned Pineapple', '012345678901', 50, 1.49),
('Pillsbury Cookie Dough', '123456789012', 30, 3.49),
('Prego Pasta Sauce', '234567890123', 40, 2.89),
('Pepperidge Farm Goldfish Crackers', '345678901234', 50, 1.99),
('Skippy Peanut Butter', '456789012345', 30, 3.99),
('Snyders Pretzels', '567890123456', 40, 2.29),
('Ocean Spray Cranberry Juice', '678901234567', 30, 2.99),
('Bar-S Hot Dogs', '789012345678', 50, 1.79),
('Kelloggs Pop-Tarts', '890123456789', 30, 2.99),
('V8 Vegetable Juice', '901234567890', 20, 4.49),
('Welchs Grape Jelly', '012345678901', 40, 2.49),
('Lays Potato Chips', '123456789012', 50, 2.99),
('Hellmanns Real Mayonnaise', '234567890123', 30, 3.79),
('Kelloggs Frosted Flakes', '345678901234', 40, 4.29),
('Newmans Own Pasta Sauce', '456789012345', 30, 2.69),
('Pepperidge Farm Goldfish Crackers', '567890123456', 50, 1.99),
('Minute Maid Orange Juice', '678901234567', 40, 3.49),
('Aunt Jemima Pancake Mix', '789012345678', 50, 2.99),
('Campbells Chicken Noodle Soup', '890123456789', 40, 1.29),
('Jif Peanut Butter', '901234567890', 30, 3.49),
('Cheerios Cereal', '012345678901', 50, 3.99),
('Nutella Hazelnut Spread', '123456789012', 20, 4.99),
('Gatorade Sports Drink', '234567890123', 50, 1.49),
('Nature Valley Granola Bars', '345678901234', 40, 2.79),
('Bounty Paper Towels', '456789012345', 30, 3.99),
('Charmin Toilet Paper', '567890123456', 40, 5.49),
('Red Bull Energy Drink', '678901234567', 50, 2.99),
('Dove Body Wash', '789012345678', 30, 4.79),
('Clorox Disinfecting Wipes', '890123456789', 50, 3.99),
('Huggies Diapers', '901234567890', 40, 9.99),
('Purina Dog Food', '012345678901', 50, 15.99);